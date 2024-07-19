using Microsoft.AspNetCore.Mvc;
using NPCIL.Models;
using System.Collections.Generic;
using System.Data;

namespace NPCIL.Controllers
{
    public class TenderTypeController : Controller
    {
        CmnDBWork cmn = new CmnDBWork();
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment;

        public TenderTypeController(Microsoft.AspNetCore.Hosting.IHostingEnvironment environment)
        {
            hostingEnvironment = environment;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddTenderType()
        {
            return View();
        }

        public IActionResult TenderTypeList()
        {
            List<TenderTypeModel> tenderTypeList = new List<TenderTypeModel>();
            DataTable dt = cmn.GetDatatable("exec PRC_TenderType @qtype=2");
            foreach (DataRow dr in dt.Rows)
            {
                TenderTypeModel tenderTypeModel = new TenderTypeModel()
                {
                    TTid = int.Parse(dr["TT_id"].ToString()),
                    TTtitle = dr["TT_Title"].ToString()
                };
                tenderTypeList.Add(tenderTypeModel);
            }
            return View(tenderTypeList);
        }

        [HttpPost]
        public IActionResult AddTenderType(TenderTypeModel tenderTypeModel)
        {
            string ret = cmn.AddDelMod("exec PRC_TenderType @qtype='1'," +
                "@title='" + tenderTypeModel.TTtitle + "'");
            if (ret == "1")
            {
                return RedirectToAction("TenderTypeList");
            }
            else
            {
                return View();
            }
        }

        public IActionResult EditTenderType(int id = 0)
        {
            TenderTypeModel obj = new TenderTypeModel();
            DataTable dt = cmn.GetDatatable("exec PRC_TenderType @qtype='3', " +
                            "@id='" + id + "'");

            if (dt.Rows.Count > 0)
            {
                obj.TTid = int.Parse(dt.Rows[0]["TT_id"].ToString());
                obj.TTtitle = dt.Rows[0]["TT_Title"].ToString();
            }
            return View(obj);
        }

        [HttpPost]
        public IActionResult UpdateTenderType(TenderTypeModel tenderTypeModel)
        {
            string ret = cmn.AddDelMod("exec PRC_TenderType @qtype='4'," +
                "@id='" + tenderTypeModel.TTid + "'," +
                "@title='" + tenderTypeModel.TTtitle + "'");
            if (ret == "4")
            {
                return RedirectToAction("TenderTypeList");
            }
            else
            {
                return View();
            }
        }

        public IActionResult DeleteTenderType(int id)
        {
            string ret = cmn.AddDelMod("exec PRC_TenderType @qtype='5'," +
                            "@id='" + id + "'");
            if (ret == "5")
            {
                return RedirectToAction("TenderTypeList");
            }
            else
            {
                return View();
            }
        }
    }
}
