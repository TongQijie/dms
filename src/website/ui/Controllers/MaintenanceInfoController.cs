using Dade.Dms.Rest.ServiceModel;
using Dade.Dms.Website.Configuration;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Dade.Dms.Website.Controllers
{
    public class MaintenanceInfoController : ControllerBase
    {


        /// <summary>
        /// 保养计划
        /// </summary>
        /// <returns></returns>
        public ActionResult Plan()
        {
            //查询保养计划
            var result = RestProxy.MaintenancePlanServiceProxy.Query(new Paging(1, RestConfiguraionManager.PageSize), 0, "", "");
            ViewData.Add("devicenum", "");
            ViewData.Add("devicename", "");
            ViewData.Add("TotalPage", result.Paging.TotalPages);
            ViewData.Add("CurrentPage", 1);
            return View(new List<MaintenancePlan>(result.Body ?? new MaintenancePlan[0]));
        }
        [HttpPost]
        public ActionResult Plan(string devicenum, string devicename, string pagenum)
        {
            int currentpage = 1;
            int.TryParse(pagenum, out currentpage);

            var result = RestProxy.MaintenancePlanServiceProxy.Query(
             new Paging()
             {
                 PageNumber = currentpage,
                 PageSize = RestConfiguraionManager.PageSize
             },
             0,
             devicenum,
             devicename
                 );

            ViewData.Add("devicenum", devicenum);
            ViewData.Add("devicename", devicename);
            ViewData.Add("TotalPage", result.Paging.TotalPages);
            ViewData.Add("CurrentPage", currentpage);
            return View(new List<MaintenancePlan>(result.Body ?? new MaintenancePlan[0]));
        }

        [HttpPost]
        public string AddPlan(MaintenancePlan plan)
        {
            switch (plan.Flag)
            {
                case Rest.ServiceModel.Enums.MaintenancePlanFlag.Annually:
                    plan.PlanValue = "0001-" + plan.PlanValue.Substring(5, 5); break;
                case Rest.ServiceModel.Enums.MaintenancePlanFlag.Monthly:
                    plan.PlanValue = "0001-00-" + plan.PlanValue.Substring(8, 2); break;
                default: break;
            }
            try
            {
                var result = RestProxy.MaintenancePlanServiceProxy.Add(plan);
                if (result.HasError)
                {
                    return "添加失败:" + result.Errors[0].ErrorMessage;
                }
                else
                {
                    return "添加成功";
                }
            }
            catch (RestException ex)
            {
                return "系统异常:" + ex.Message;
            }

        }

        [HttpPost]
        public string EditPlan(MaintenancePlan plan)
        {
            switch (plan.Flag)
            {
                case Rest.ServiceModel.Enums.MaintenancePlanFlag.Annually:
                    plan.PlanValue = "0001-" + plan.PlanValue.Substring(5, 5); break;
                case Rest.ServiceModel.Enums.MaintenancePlanFlag.Monthly:
                    plan.PlanValue = "0001-00-" + plan.PlanValue.Substring(8, 2); break;
                default: break;
            }
            try
            {
                var result = RestProxy.MaintenancePlanServiceProxy.Edit(plan);
                if (result.HasError)
                {
                    return "修改失败:" + result.Errors[0].ErrorMessage;
                }
                else
                {
                    return "修改成功";
                }
            }
            catch (RestException ex)
            {
                return "系统异常:" + ex.Message;
            }

        }


        /// <summary>
        /// 根据行ID查询记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult QuerySinglePlan(string id)
        {
            int lineId = 0;
            if (!int.TryParse(id, out lineId))
            {
                return Json("系统异常！", JsonRequestBehavior.AllowGet);
            }
            var result = RestProxy.MaintenancePlanServiceProxy.Query(
            new Paging()
            {
                PageNumber = 1,
                PageSize = 1,
            },
            lineId,
            "", ""
            );
            if (result.Body == null)
            {
                throw new System.Exception("数据异常！");
            }
            else
            {
                return Json(result.Body, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]

        public string DeletePlan(string[] ids)
        {
            if (ids == null)
            {
                return "数据异常，请重试!";
            }
            else
            {
                foreach (var id in ids)
                {
                    if (!string.IsNullOrEmpty(id))
                    {
                        try
                        {
                            var result = RestProxy.MaintenancePlanServiceProxy.Delete(int.Parse(id));
                            if (!result.HasError)
                            {
                                continue;
                            }
                            else
                            {
                                throw new System.Exception(result.Errors.ToString());
                            }
                        }
                        catch (System.Exception ex)
                        {
                            return "错误!" + ex.Message;
                        }
                    }
                    else
                    {
                        return "数据异常，请重试!";
                    }
                }
                return "删除成功！";
            }

        }


        /// <summary>
        /// 保养记录
        /// </summary>
        /// <returns></returns>
        public ActionResult Record()
        {
            var result = RestProxy.MaintenanceRecordServiceProxy.Query(new Paging(1, RestConfiguraionManager.PageSize), 0, "", 0, "", null, "", "");
            ViewData.Add("devicenum", "");
            ViewData.Add("devicename", "");
            ViewData.Add("TotalPage", result.Paging.TotalPages);
            ViewData.Add("CurrentPage", 1);
            return View(new List<MaintenanceRecord>(result.Body ?? new MaintenanceRecord[0]));
        }

        [HttpPost]
        public ActionResult Record(string devicenum, string pagenum, int? planId, string person, string[] statuses, string startTime, string endTime)
        {
            int currentpage = 1;
            int.TryParse(pagenum, out currentpage);

            var states = new string[statuses==null?0:statuses.Length];
            if (statuses.Length > 0 && statuses[0] == "全部")
            {
                states = null;
            }
            else
            {
                for (int i = 0; i < statuses.Length; i++)
                {
                    var s = statuses[i];
                    if (s.Length > 1)
                    {
                        var state = "";
                        switch (s)
                        {
                            case "未保养": state = "P"; break;
                            case "进行中": state = "O"; break;
                            case "已完成": state = "D"; break;
                            default: state = "N"; break;
                        }
                        states[i] = state;
                    }
                }
            }
            var result = RestProxy.MaintenanceRecordServiceProxy.Query(
             new Paging()
             {
                 PageNumber = currentpage,
                 PageSize = RestConfiguraionManager.PageSize
             },
             0,
             devicenum,
             planId == null ? 0 : (int)planId,
             person,
             states,
             startTime,
             endTime
                 );

            ViewData.Add("devicenum", devicenum);
            ViewData.Add("planId", planId);
            ViewData.Add("TotalPage", result.Paging.TotalPages);
            ViewData.Add("CurrentPage", currentpage);
            ViewData.Add("person", person);
            ViewData.Add("statuses", statuses.Length > 0 ? statuses[0] : "");
            ViewData.Add("startTime", startTime);
            ViewData.Add("endTime", endTime);
            return View(new List<MaintenanceRecord>(result.Body ?? new MaintenanceRecord[0]));
        }

        [HttpPost]
        public string AddRecord(MaintenanceRecord record)
        {
            try
            {
                var result = RestProxy.MaintenanceRecordServiceProxy.Add(record);
                if (result.HasError)
                {
                    return "添加失败:" + result.Errors[0].ErrorMessage;
                }
                else
                {
                    return "添加成功";
                }
            }
            catch (RestException ex)
            {
                return "系统异常:" + ex.Message;
            }
        }

        /// <summary>
        /// 传入的record的状态需要后台做处理，
        /// 
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        [HttpPost]
        public string EditRecord(MaintenanceRecord record)
        {
            try
            {
                if (record.Status == "未保养")
                {
                    record.Status = "O";
                }
                else if (record.Status == "进行中")
                {
                    record.Status = "D";
                }
                else
                {
                    record.Status = "N";
                }
                var result = RestProxy.MaintenanceRecordServiceProxy.Edit(record);
                if (result.HasError)
                {
                    return "修改失败:" + result.Errors[0].ErrorMessage;
                }
                else
                {
                    return "修改成功";
                }
            }
            catch (RestException ex)
            {
                return "系统异常:" + ex.Message;
            }
        }
        [HttpPost]
        public ActionResult QuerySingleRecord(string id)
        {
            int lineId = 0;
            if (!int.TryParse(id, out lineId))
            {
                return Json("系统异常！", JsonRequestBehavior.AllowGet);
            }
            var result = RestProxy.MaintenanceRecordServiceProxy.Query(
             new Paging()
             {
                 PageNumber = 1,
                 PageSize = RestConfiguraionManager.PageSize
             },
             lineId,
             "",
             0,
             "",
             null,
             "",
             ""
                 );
            if (result.Body == null)
            {
                throw new System.Exception("数据异常！");
            }
            else
            {
                return Json(result.Body, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public string DeleteRecord(string[] ids)
        {
            if (ids == null)
            {
                return "数据异常，请重试!";
            }
            else
            {
                foreach (var id in ids)
                {
                    if (!string.IsNullOrEmpty(id))
                    {
                        try
                        {
                            var result = RestProxy.MaintenanceRecordServiceProxy.Delete(int.Parse(id));
                            if (!result.HasError)
                            {
                                continue;
                            }
                            else
                            {
                                throw new System.Exception(result.Errors.ToString());
                            }
                        }
                        catch (System.Exception ex)
                        {
                            return "错误!" + ex.Message;
                        }
                    }
                    else
                    {
                        return "数据异常，请重试!";
                    }
                }
                return "删除成功！";
            }
        }
        /// <summary>
        /// 故障维修
        /// </summary>
        /// <returns></returns>
        public ActionResult Repair()
        {
            var result = RestProxy.RepairRecordServiceProxy.Query(new Paging(1, RestConfiguraionManager.PageSize));
            ViewData.Add("devicenum", "");
            ViewData.Add("devicename", "");
            ViewData.Add("TotalPage", result.Paging.TotalPages);
            ViewData.Add("CurrentPage", 1);
            return View(new List<RepairRecord>(result.Body ?? new RepairRecord[0]));
        }

        [HttpPost]
        public ActionResult Repair(string pagenum, string devicenum, string person, string[] statuses, string startTime, string endTime)
        {
            int currentpage = 1;
            int.TryParse(pagenum, out currentpage);
            var states = new string[statuses.Length];
            if (statuses.Length > 0 && statuses[0] == "全部")
            {
                states = null;
            }
            else
            {
                for (int i = 0; i < statuses.Length; i++)
                {
                    var s = statuses[i];
                    if (s.Length > 1)
                    {
                        var state = "";
                        switch (s)
                        {
                            case "未维修": state = "P"; break;
                            case "进行中": state = "O"; break;
                            case "已完成": state = "D"; break;
                            default: state = "N"; break;
                        }
                        states[i] = state;
                    }
                }
            }
            var result = RestProxy.RepairRecordServiceProxy.Query(
             new Paging()
             {
                 PageNumber = currentpage,
                 PageSize = RestConfiguraionManager.PageSize
             },
             0,
             devicenum,
            
             person,
             states,
             startTime,
             endTime
                 );

            ViewData.Add("devicenum", devicenum);
            ViewData.Add("TotalPage", result.Paging.TotalPages);
            ViewData.Add("CurrentPage", currentpage);
            ViewData.Add("person", person);
            ViewData.Add("statuses", statuses.Length > 0 ? statuses[0] : "");
            ViewData.Add("startTime", startTime);
            ViewData.Add("endTime", endTime);
            return View(new List<RepairRecord>(result.Body ?? new RepairRecord[0]));
        }
        [HttpPost]
        public string AddRepair(RepairRecord repair)
        {
            try
            {
                var result = RestProxy.RepairRecordServiceProxy.Add(repair);
                if (result.HasError)
                {
                    return "添加失败:" + result.Errors[0].ErrorMessage;
                }
                else
                {
                    return "添加成功";
                }
            }
            catch (RestException ex)
            {
                return "系统异常:" + ex.Message;
            }
        }
        [HttpPost]
        public string EditRepair(RepairRecord repair)
        {
            try
            {
                if (repair.Status == "P")
                {
                    repair.Status = "O";
                }
                else if (repair.Status == "O")
                {
                    repair.Status = "D";
                }
                else
                {
                    repair.Status = "N";
                }
                var result = RestProxy.RepairRecordServiceProxy.Edit(repair);
                if (result.HasError)
                {
                    return "修改失败:" + result.Errors[0].ErrorMessage;
                }
                else
                {
                    return "修改成功";
                }
            }
            catch (RestException ex)
            {
                return "系统异常:" + ex.Message;
            }
        }

        [HttpPost]
        public ActionResult QuerySingleRepair(string id)
        {
            int lineId = 0;
            if (!int.TryParse(id, out lineId))
            {
                return Json("系统异常！", JsonRequestBehavior.AllowGet);
            }
            var result = RestProxy.RepairRecordServiceProxy.Query(
             new Paging()
             {
                 PageNumber = 1,
                 PageSize = 3
             },
             lineId,
             "",
             "",
             null,
             "",
             ""
             );
            if (result.Body == null)
            {
                throw new System.Exception("数据异常！");
            }
            else
            {
                return Json(result.Body, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public string DeleteRepair(string[] ids)
        {
            if (ids == null)
            {
                return "数据异常，请重试!";
            }
            else
            {
                foreach (var id in ids)
                {
                    if (!string.IsNullOrEmpty(id))
                    {
                        try
                        {
                            var result = RestProxy.RepairRecordServiceProxy.Delete(int.Parse(id));
                            if (!result.HasError)
                            {
                                continue;
                            }
                            else
                            {
                                throw new System.Exception(result.Errors.ToString());
                            }
                        }
                        catch (System.Exception ex)
                        {
                            return "错误!" + ex.Message;
                        }
                    }
                    else
                    {
                        return "数据异常，请重试!";
                    }
                }
                return "删除成功！";
            }
        }

    }

}