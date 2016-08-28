using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dade.Dms.Website.Controllers
{
    public class MonitorController : Controller
    {
        // GET: Monitor
        /// <summary>
        /// 实时监控
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 运行参数
        /// </summary>
        /// <returns></returns>
        public ActionResult RuntimeParam()
        {
            return View();
        }

        /// <summary>
        /// 移动率
        /// </summary>
        /// <returns></returns>
        public ActionResult MoveRate()
        {
            return View();
        }

        /// <summary>
        /// 能耗管理
        /// </summary>
        /// <returns></returns>
        public ActionResult PowerControl()
        {
            return View();
        }


        /// <summary>
        /// 异常报警
        /// </summary>
        /// <returns></returns>
        public ActionResult Alert()
        {
            return View();
        }

        /// <summary>
        /// 异常处理
        /// </summary>
        /// <returns></returns>
        public ActionResult Handle()
        {
            return View();
        }
    }
}