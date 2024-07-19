using Microsoft.AspNetCore.Mvc;
using NPCIL.Models;
using System.Collections.Generic;
using System.Data;

namespace NPCIL.Controllers
{
    public class TenderPositionController : Controller
    {
        CmnDBWork cmn = new CmnDBWork();
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment;

        public TenderPositionController(Microsoft.AspNetCore.Hosting.IHostingEnvironment environment)
        {
            hostingEnvironment = environment;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddTenderPosition()
        {
            return View();
        }

        public IActionResult TenderPositionList()
        {
            List<TenderPositionModel> tenderPositionList = new List<TenderPositionModel>();
            DataTable dt = cmn.GetDatatable("exec PRC_TenderPosition @qtype=2");
            foreach (DataRow dr in dt.Rows)
            {
                TenderPositionModel tenderPositionModel = new TenderPositionModel()
                {
                    TPid = int.Parse(dr["TP_id"].ToString()),
                    TPtitle = dr["TP_Title"].ToString()
                };
                tenderPositionList.Add(tenderPositionModel);
            }
            return View(tenderPositionList);
        }

        [HttpPost]
        public IActionResult AddTenderPosition(TenderPositionModel tenderPositionModel)
        {
            string ret = cmn.AddDelMod("exec PRC_TenderPosition @qtype='1'," +
                "@title='" + tenderPositionModel.TPtitle + "'");
            if (ret == "1")
            {
                return RedirectToAction("TenderPositionList");
            }
            else
            {
                return View();
            }
        }

        public IActionResult EditTenderPosition(int id = 0)
        {
            TenderPositionModel obj = new TenderPositionModel();
            DataTable dt = cmn.GetDatatable("exec PRC_TenderPosition @qtype='3', " +
                            "@id='" + id + "'");

            if (dt.Rows.Count > 0)
            {
                obj.TPid = int.Parse(dt.Rows[0]["TP_id"].ToString());
                obj.TPtitle = dt.Rows[0]["TP_Title"].ToString();
            }
            return View(obj);
        }

        [HttpPost]
        public IActionResult UpdateTenderPosition(TenderPositionModel tenderPositionModel)
        {
            string ret = cmn.AddDelMod("exec PRC_TenderPosition @qtype='4'," +
                "@id='" + tenderPositionModel.TPid + "'," +
                "@title='" + tenderPositionModel.TPtitle + "'");
            if (ret == "4")
            {
                return RedirectToAction("TenderPositionList");
            }
            else
            {
                return View();
            }
        }

        public IActionResult DeleteTenderPosition(int id)
        {
            string ret = cmn.AddDelMod("exec PRC_TenderPosition @qtype='5'," +
                            "@id='" + id + "'");
            if (ret == "5")
            {
                return RedirectToAction("TenderPositionList");
            }
            else
            {
                return View();
            }
        }
    }
}
