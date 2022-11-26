using InfraStructure.Utilities.Helpers;
using SadakaEli.Business.AbstractStructure;
using SadakaEli.Model.ComplexTypes.Yonetim.Slider;
using SadakaEli.Model.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SadakaEli.MvcWebUI.Areas.Yonetim.Controllers
{
    public class SliderController : Controller
    {

        ISliderBs _bs;


        public SliderController(ISliderBs bs)
        {
            _bs = bs;

        }
        public ViewResult SliderList()
        {
            List<Slider> sliders = _bs.GetAllActive();

            return View(sliders);
        }
        public ActionResult NewSlider()
        {
            NewSliderVm vm = new NewSliderVm();




            return View(vm);

        }

        [HttpPost]
        public JsonResult NewSlider(NewSliderVm vm)
        {

            Slider slider = new Slider();
            slider.Created = DateTime.Now;
            slider.ImagePath = vm.ImagePath;
            slider.IsActive = true;
            slider.Modified = DateTime.Now;
            slider.Title = vm.Title;

            _bs.Insert(slider);


            return Json(new { Result = true, Message = "Slider Başarıyla Yayınlandı." });


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

                string path = "~/Areas/Yonetim/Content/img/SliderImages/" + fileName;


                file.SaveAs(Server.MapPath(path));

                return Json(new { Result = true, FileName = fileName });

            }

            return Json(new { Result = false, Message = "Lütfen fotoğraf seçiniz" });
        }
        public ActionResult SliderUpdate(int id)
        {
            var slider = _bs.GetById(id);
            return View(slider);
        }

        [HttpPost]
        [ValidateInput(false)]
        public JsonResult SliderUpdateJson(NewSliderVm vm)
        {
            Slider slider = _bs.Get(x => x.Id == vm.Id);
            slider.ImagePath = vm.ImagePath;
            slider.Title = vm.Title;



            _bs.Update(slider);
            return Json(new { Operation = true, });
        }
        public JsonResult Delete(int id)
        {
            Slider slider = _bs.Get(x => x.Id == id);
            int result = _bs.Delete(slider);
            if (result > 0)
                return Json(new { Operation = true, Message = "Silme İşlemi Başarıyla Gerçekleşti." });
            return Json(new { Operation = false, Message = "Silme İşleminiz Başarısız." });




        }
    }
}
