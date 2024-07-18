using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NPCIL.Helper;
using NPCIL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;

namespace NPCIL.Controllers
{
    public class TenderController : Controller
    {
        CmnDBWork cmn = new CmnDBWork();
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment;
        private readonly INPCILHelper _npcilHelper;
        public TenderController(Microsoft.AspNetCore.Hosting.IHostingEnvironment environment, INPCILHelper npcilHelper)
        {
            hostingEnvironment = environment;
            _npcilHelper = npcilHelper;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddTender()
        {
            return View();
        }

        public IActionResult TenderList()
        {
            var tendorList = _npcilHelper.GetTenders();
            return View(tendorList);
        }

        [HttpPost]
        public IActionResult AddTender(TenderModel tenderModel)
        {
            tenderModel.StartDate_Selling = String.Format("{0:MM-dd-yyyy}", tenderModel.StartDate_Selling_Display == null ? "" : tenderModel.StartDate_Selling_Display.Value);
            tenderModel.EndDate_Selling = String.Format("{0:MM-dd-yyyy}", tenderModel.EndDate_Selling_Display == null ? "" : tenderModel.EndDate_Selling_Display.Value);
            tenderModel.DateOpening = String.Format("{0:MM-dd-yyyy}", tenderModel.DateOpening_Display == null ? "" : tenderModel.DateOpening_Display.Value);
            tenderModel.StartDate_Receiving = String.Format("{0:MM-dd-yyyy}", tenderModel.StartDate_Receiving_Display == null ? "" : tenderModel.StartDate_Receiving_Display.Value);
            tenderModel.EndDate_Receiving = String.Format("{0:MM-dd-yyyy}", tenderModel.EndDate_Receiving_Display == null ? "" : tenderModel.EndDate_Receiving_Display.Value);
            tenderModel.Prebid_Date = String.Format("{0:MM-dd-yyyy}", tenderModel.Prebid_Date_Display == null ? "" : tenderModel.Prebid_Date_Display.Value);
    
            string ret = cmn.AddDelMod("exec PRC_Tender @qtype='1'," +
                "@Tendor_no='" + tenderModel.TendorNo + "'," +
                "@Tendor_IssuingAuth_eng='" + tenderModel.TendorAuthEng + "'," +
                "@Tendor_IssuingAuth_hindi='" + tenderModel.TendorAuthHindi + "'," +
                "@Tender_StartDate_SellingTender='" + tenderModel.StartDate_Selling + "'," +
                "@Tender_EndDate_SellingTender='" + tenderModel.EndDate_Selling + "'," +
                "@Tender_DateOpening='" + tenderModel.DateOpening + "'," +
                "@Tender_StartDate_ReceivingTender='" + tenderModel.StartDate_Receiving + "'," +
                "@Tender_EndDate_ReceivingTender='" + tenderModel.EndDate_Receiving + "'," +
                "@Tender_Prebid_Date='" + tenderModel.Prebid_Date + "'," +
                "@Tender_Scope_eng='" + tenderModel.Scope_eng + "'," +
                "@Tender_Scope_hindi='" + tenderModel.Scope_hindi + "'," +
                "@Tender_body_eng='" + tenderModel.body_eng + "'," +
                "@Tender_body_hindi='" + tenderModel.body_hindi + "'," +
                "@Tender_markImportant='" + tenderModel.markImportant + "'," +
                "@Tender_cost='" + tenderModel.cost + "'," +
                "@Tender_EMD='" + tenderModel.EMD + "'");

            if (ret == "1")
            {
                return RedirectToAction("TenderList");
            }
            else
            {
                return View();
            }
        }


        public IActionResult EditTender(int id = 0)
        {
            TenderModel obj = new TenderModel();
            DataTable dt = cmn.GetDatatable("exec PRC_Tender @qtype='3', " +
                            "@Tender_id='" + id + "'");

            if (dt.Rows.Count > 0)
            {
                obj.id = int.Parse(dt.Rows[0]["Tender_id"].ToString());
                obj.TendorNo = dt.Rows[0]["Tendor_no"].ToString();
                obj.TendorAuthEng = dt.Rows[0]["Tendor_IssuingAuth_eng"].ToString();
                obj.TendorAuthHindi = dt.Rows[0]["Tendor_IssuingAuth_hindi"].ToString();
                if (!String.IsNullOrEmpty(dt.Rows[0]["Tender_StartDate_SellingTender"].ToString()))
                {
                    obj.StartDate_Selling_Display = Convert.ToDateTime(dt.Rows[0]["Tender_StartDate_SellingTender"].ToString());
                }
                if (!String.IsNullOrEmpty(dt.Rows[0]["Tender_EndDate_SellingTender"].ToString()))
                {
                    obj.EndDate_Selling_Display = Convert.ToDateTime(dt.Rows[0]["Tender_EndDate_SellingTender"].ToString());
                }
                if (!String.IsNullOrEmpty(dt.Rows[0]["Tender_DateOpening"].ToString()))
                {
                    obj.DateOpening_Display = Convert.ToDateTime(dt.Rows[0]["Tender_DateOpening"].ToString());
                }
                if (!String.IsNullOrEmpty(dt.Rows[0]["Tender_StartDate_ReceivingTender"].ToString()))
                {
                    obj.StartDate_Receiving_Display = Convert.ToDateTime(dt.Rows[0]["Tender_StartDate_ReceivingTender"].ToString());
                }
                if (!String.IsNullOrEmpty(dt.Rows[0]["Tender_EndDate_ReceivingTender"].ToString()))
                {
                    obj.EndDate_Receiving_Display = Convert.ToDateTime(dt.Rows[0]["Tender_EndDate_ReceivingTender"].ToString());
                }
                if (!String.IsNullOrEmpty(dt.Rows[0]["Tender_Prebid_Date"].ToString()))
                {
                    obj.Prebid_Date_Display = Convert.ToDateTime(dt.Rows[0]["Tender_Prebid_Date"].ToString());
                }
                obj.Scope_eng = dt.Rows[0]["Tender_Scope_eng"].ToString();
                obj.Scope_hindi = dt.Rows[0]["Tender_Scope_hindi"].ToString();
                obj.body_eng = dt.Rows[0]["Tender_body_eng"].ToString();
                obj.body_hindi = dt.Rows[0]["Tender_body_hindi"].ToString();
                obj.markImportant = (dt.Rows[0]["Tender_markImportant"].ToString())=="0" ? false : true;
                obj.cost = dt.Rows[0]["Tender_cost"].ToString();
                obj.EMD = dt.Rows[0]["Tender_EMD"].ToString();
            }
            return View(obj);
        }

        [HttpPost]
        public IActionResult UpdateTender(TenderModel tenderModel)
        {
            tenderModel.StartDate_Selling = String.Format("{0:MM-dd-yyyy}", tenderModel.StartDate_Selling_Display == null ? "" : tenderModel.StartDate_Selling_Display.Value);
            tenderModel.EndDate_Selling = String.Format("{0:MM-dd-yyyy}", tenderModel.EndDate_Selling_Display == null ? "" : tenderModel.EndDate_Selling_Display.Value);
            tenderModel.DateOpening = String.Format("{0:MM-dd-yyyy}", tenderModel.DateOpening_Display == null ? "" : tenderModel.DateOpening_Display.Value);
            tenderModel.StartDate_Receiving = String.Format("{0:MM-dd-yyyy}", tenderModel.StartDate_Receiving_Display == null ? "" : tenderModel.StartDate_Receiving_Display.Value);
            tenderModel.EndDate_Receiving = String.Format("{0:MM-dd-yyyy}", tenderModel.EndDate_Receiving_Display == null ? "" : tenderModel.EndDate_Receiving_Display.Value);
            tenderModel.Prebid_Date = String.Format("{0:MM-dd-yyyy}", tenderModel.Prebid_Date_Display == null ? "" : tenderModel.Prebid_Date_Display.Value);

            string ret = cmn.AddDelMod("exec PRC_Tender @qtype='4'," +
                "@Tender_id='" + tenderModel.id + "'," +
                "@Tendor_no='" + tenderModel.TendorNo + "'," +
                "@Tendor_IssuingAuth_eng='" + tenderModel.TendorAuthEng + "'," +
                "@Tendor_IssuingAuth_hindi='" + tenderModel.TendorAuthHindi + "'," +
                "@Tender_StartDate_SellingTender='" + tenderModel.StartDate_Selling + "'," +
                "@Tender_EndDate_SellingTender='" + tenderModel.EndDate_Selling + "'," +
                "@Tender_DateOpening='" + tenderModel.DateOpening + "'," +
                "@Tender_StartDate_ReceivingTender='" + tenderModel.StartDate_Receiving + "'," +
                "@Tender_EndDate_ReceivingTender='" + tenderModel.EndDate_Receiving + "'," +
                "@Tender_Prebid_Date='" + tenderModel.Prebid_Date + "'," +
                "@Tender_Scope_eng='" + tenderModel.Scope_eng + "'," +
                "@Tender_Scope_hindi='" + tenderModel.Scope_hindi + "'," +
                "@Tender_body_eng='" + tenderModel.body_eng + "'," +
                "@Tender_body_hindi='" + tenderModel.body_hindi + "'," +
                "@Tender_markImportant='" + tenderModel.markImportant + "'," +
                "@Tender_cost='" + tenderModel.cost + "'," +
                "@Tender_EMD='" + tenderModel.EMD + "'");

            if (ret == "4")
            {
                return RedirectToAction("TenderList");
            }
            else
            {
                return View();
            }
        }

        public IActionResult DeleteTender(int id)
        {
            string ret = cmn.AddDelMod("exec PRC_Tender @qtype='5'," +
                            "@Tender_id='" + id + "'");
            if (ret == "5")
            {
                return RedirectToAction("TenderList");
            }
            else
            {
                return View();
            }
        }
    }
}
