using Microsoft.AspNetCore.Mvc;
using NPCIL.Models;
using System.Collections.Generic;
using System.Data;

namespace NPCIL.Controllers
{
    public class VideoCategoryController : Controller
    {
        CmnDBWork cmn = new CmnDBWork();
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment;

        public VideoCategoryController(Microsoft.AspNetCore.Hosting.IHostingEnvironment environment)
        {
            hostingEnvironment = environment;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddVideoCategory()
        {
            return View();
        }

        public IActionResult VideoCategoryList()
        {
            List<VideoCategoryModel> videoList = new List<VideoCategoryModel>();
            DataTable dt = cmn.GetDatatable("exec PRC_VideoCategory @qtype=2");
            foreach (DataRow dr in dt.Rows)
            {
                VideoCategoryModel videoCategoryModel = new VideoCategoryModel()
                {
                    VCid = int.Parse(dr["VC_id"].ToString()),
                    VCtitle = dr["VC_Title"].ToString()
                };
                videoList.Add(videoCategoryModel);
            }
            return View(videoList);
        }

        [HttpPost]
        public IActionResult AddVideoCategory(VideoCategoryModel videoCategoryModel)
        {
            string ret = cmn.AddDelMod("exec PRC_VideoCategory @qtype='1'," +
                "@title='" + videoCategoryModel.VCtitle + "'");
            if (ret == "1")
            {
                return RedirectToAction("VideoCategoryList");
            }
            else
            {
                return View();
            }
        }

        public IActionResult EditVideoCategory(int id = 0)
        {
            VideoCategoryModel obj = new VideoCategoryModel();
            DataTable dt = cmn.GetDatatable("exec PRC_VideoCategory @qtype='3', " +
                            "@id='" + id + "'");

            if (dt.Rows.Count > 0)
            {
                obj.VCid = int.Parse(dt.Rows[0]["VC_id"].ToString());
                obj.VCtitle = dt.Rows[0]["VC_Title"].ToString();
            }
            return View(obj);
        }

        [HttpPost]
        public IActionResult UpdateVideoCategory(VideoCategoryModel videoCategoryModel)
        {
            string ret = cmn.AddDelMod("exec PRC_VideoCategory @qtype='4'," +
                "@id='" + videoCategoryModel.VCid + "'," +
                "@title='" + videoCategoryModel.VCtitle + "'");
            if (ret == "4")
            {
                return RedirectToAction("VideoCategoryList");
            }
            else
            {
                return View();
            }
        }

        public IActionResult DeleteVideoCategory(int id)
        {
            string ret = cmn.AddDelMod("exec PRC_VideoCategory @qtype='5'," +
                            "@id='" + id + "'");
            if (ret == "5")
            {
                return RedirectToAction("VideoCategoryList");
            }
            else
            {
                return View();
            }
        }
    }
}
