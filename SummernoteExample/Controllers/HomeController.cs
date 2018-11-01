using Aliyun.OSS;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SummernoteExample.Controllers
{
    public class HomeController : Controller
    {
        private static string _accessKeyId = "accessKeyId";
        private static string _accessKeySecret = "accessKeySecret";
        private static string _endpoint = "OSS节点域名";
        private static string _bucketName = "bucketName";
        public static OssClient _client = new OssClient(_endpoint, _accessKeyId, _accessKeySecret);


        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Index(string summernote)
        {
            ViewBag.Summernote = summernote;
            return View();
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        #region SUMMERNOTE UPLOAD IMAGES

        [HttpPost]
        public ActionResult SummernoteUploadImage()
        {
            foreach (var fileKey in Request.Files.AllKeys)
            {
                var file = Request.Files[fileKey];
                try
                {

                    var fileName = Path.GetFileName(file?.FileName);
                    if (fileName != null)
                    {
                        var path = Server.MapPath("~/Uploads/SummernoteImages");
                        if (System.IO.File.Exists(path) == false)
                        {
                            Directory.CreateDirectory(path);
                        }
                        path = Path.Combine(Server.MapPath("~/Uploads/SummernoteImages"), fileName);
                        file.SaveAs(path);
                        //获取当前项目的图片文件夹
                        var str = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + @"Uploads\SummernoteImages\";
                        //上传到OSS
                        bool res = PutObject("Images/" + fileName, str + fileName);
                        if (res)
                        {
                            //Todo:删除项目文件夹中的图片
                        }
                        //返回的URL可以修改为OSS中的路径
                        return Json(new { Url = Url.Content("~/Uploads/SummernoteImages/" + fileName) });
                    }
                }
                catch (Exception ex)
                {
                    return Json(new { Message = $"Error in saving file ({ex.Message})" });
                }
            }
            return Json(new { Message = "File saved" });
        }
        /// <summary>
        /// 上传文件-单个
        /// </summary>
        /// <param name="folderName">文件名(需带上传指定路径)</param>
        /// <param name="filePath">文件路径</param>
        public static bool PutObject(string folderName, string filePath)
        {
            try
            {
                PutObjectResult p = _client.PutObject(_bucketName, folderName, filePath);
                if (p.HttpStatusCode.ToString() == "OK")
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {

                return false;
            }
        }
        #endregion
    }
}