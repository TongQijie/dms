using System;
using System.Web.Mvc;
using System.Collections.Generic;

using Dade.Dms.Rest.ServiceModel;
using Dade.Dms.Website.Configuration;

namespace Dade.Dms.Website.Controllers
{
    public class DeviceInfoController : ControllerBase
    {
        public ActionResult Index()
        {
            var result = RestProxy.DeviceInfoServiceProxy.Query(new Paging(1, RestConfiguraionManager.PageSize), null, null);
            ViewData.Add("devicenum", "");
            ViewData.Add("devicename", "");
            ViewData.Add("TotalPage", result.Paging.TotalPages);
            ViewData.Add("CurrentPage", 1);
            return View(new List<DeviceInfoBase>(result.Body ?? new DeviceInfoBase[0]));
        }

        /// <summary>
        /// 条件查询
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(string devicenum, string devicename, string pagenum)
        {
            int currentpage = 1;
            int.TryParse(pagenum, out currentpage);

            var result = RestProxy.DeviceInfoServiceProxy.Query(new Paging(currentpage, RestConfiguraionManager.PageSize), devicenum, devicename);
            ViewData.Add("devicenum", devicenum);
            ViewData.Add("devicename", devicename);
            ViewData.Add("TotalPage", result.Paging.TotalPages);
            ViewData.Add("CurrentPage", currentpage);
            return View(new List<DeviceInfoBase>(result.Body ?? new DeviceInfoBase[0]));
        }


        /// <summary>
        /// 添加设备
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public string AddDevice(DeviceInfoBase device)
        {
            try
            {
                var result = RestProxy.DeviceInfoServiceProxy.Add(device);
                if (!result.HasError)
                {
                    return "添加成功";
                }
                else
                {
                    return "添加失败:" + result.Errors[0].ErrorMessage;
                }
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult QuerySingleDevice(string devicenum)
        {
            var result = RestProxy.DeviceInfoServiceProxy.Query(new Paging(1, RestConfiguraionManager.PageSize), devicenum, null);
            if(result.Body==null)
            {
                throw new System.Exception("数据异常！");
            }
            else
            {
                if(!string.IsNullOrEmpty(result.Body[0].DateOfManufacture))
                {
                    result.Body[0].DateOfManufacture = Convert.ToDateTime(result.Body[0].DateOfManufacture).ToShortDateString();
                }
                return Json(result.Body, JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// 编辑设备
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        [HttpPost]
        public string EditDevice(DeviceInfoBase device)
        {
            try
            {
                var result = RestProxy.DeviceInfoServiceProxy.Edit(device);
                if (!result.HasError)
                {
                    return "修改成功";
                }
                else
                {
                    return "修改失败" + result.Errors[0].ErrorMessage;
                }
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
        }


        /// <summary>
        /// 删除一条设备
        /// </summary>
        /// <param name="devicenum"></param>
        /// <returns></returns>
        [HttpPost]
        public string DeleteDevice(string[] devicenums)
        {
            if(devicenums==null)
            {
                return "数据异常，请重试!";
            }
            else
            {
                foreach (var device in devicenums)
                {
                    if (!string.IsNullOrEmpty(device))
                    {
                        try
                        {
                            var result = RestProxy.DeviceInfoServiceProxy.Delete(device);
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
                            return "错误!"+ex.Message;
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
        /// 设备运行状态
        /// </summary>
        /// <returns></returns>
        public ActionResult DeviceStatus()
        {
            return View();
        }

        /// <summary>
        /// 设备统计
        /// </summary>
        /// <returns></returns>
        public ActionResult DeviceStatistics()
        {
            return View();
        }

    }
}