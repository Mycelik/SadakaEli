using FluentValidation.Results;
using InfraStructure.Utilities.Helpers;
using SadakaEli.Business.AbstractStructure;
using SadakaEli.Business.ValidationRules.FluentValidation;
using SadakaEli.Model.ComplexTypes.Yonetim.News;
using SadakaEli.Model.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SadakaEli.MvcWebUI.Areas.Yonetim.Controllers
{
    public class NewsController : Controller
    {
        INewsBs _bs;
        public NewsController(INewsBs bs)
        {
            _bs = bs;
        }
        public ViewResult NewsList()
        {
            List<News> news = _bs.GetAllActive();
            return View(news);
        }
       
        public ViewResult NewNews()
        {
            NewNewsVm vm = new NewNewsVm();
            return View(vm);
        }

        [HttpPost]
        [ValidateInput(false)]
        public JsonResult NewNewsJson(NewNewsVm vm)
        {
            NewNewsVmValidator val = new NewNewsVmValidator();
            ValidationResult valResult = val.Validate(vm);

            if (valResult.IsValid)
            {
                News news = new News();
                news.Created = DateTime.Now;
                news.Modified = DateTime.Now;
                news.IsActive = true;
                news.Headline = vm.Headline;
                news.Explanation = vm.Explanation;
                news.Photo = vm.FileName;
                

                _bs.Insert(news);


                return Json(new { Result = true, Message = "Yeni Haberiniz Eklenmiştir." });
            }
            else
            {
                string errorMessagesForClient = "";

                foreach (ValidationFailure failure in valResult.Errors)
                {
                    errorMessagesForClient += failure.ErrorMessage + "<br />";
                }

                return Json(new { Result = false, ErrorMessages = errorMessagesForClient });


            }
        }
        
        [HttpPost]
        public JsonResult UploadPhoto()
        {
            HttpFileCollectionBase files = Request.Files;

            if (files.Count > 0)
            {
                HttpPostedFileBase file = files[0];

                if (!file.ContentType.Contains("image/"))
                    return Json(new { Result = false, Message = "Sadece resim dosyası yükleyebilirsiniz" });



                string fileName = RandomValueGenerator.FileName(Path.GetExtension(file.FileName));

                string path = "~/Areas/Yonetim/Content/img/NewsImages/" + fileName;


                file.SaveAs(Server.MapPath(path));

                return Json(new { Result = true, FileName = fileName });

            }

            return Json(new { Result = false, Message = "Lütfen fotoğraf seçiniz" });
        }

        public ActionResult UpdateNews(int id)
        {
            var news = _bs.GetById(id);
            return View(news);
        }
        public JsonResult UpdateNewsJson(UpdateNewsVm vm)
        {
            News news = _bs.Get(x => x.Id == vm.Id);
            news.IsActive = true;
            news.Modified = DateTime.Now;
            news.Headline = vm.Headline;
            news.Explanation = vm.Explanation;
            _bs.Update(news);

            return Json(new { Operation = true, Message = "Haber Güncellemesi Yapıldı." });
        }
        public JsonResult DeleteNewsJson(int id)
        {
            var news = _bs.Get(x => x.Id == id);
            int result = _bs.Delete(news);
            if (result > 0)
                return Json(new { Operation = true, Message = "Silme İşlemi Başarıyla Gerçekleşti." });
            return Json(new { Operation = false, Message = "Silme İşlemi Başarısız Gerçekleşti." });
        }
    }
    
}