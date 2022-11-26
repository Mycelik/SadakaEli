using FluentValidation.Results;
using InfraStructure;
using InfraStructure.Utilities.Helpers;
using SadakaEli.Business.AbstractStructure;
using SadakaEli.Business.ValidationRules.FluentValidation;
using SadakaEli.Model.ComplexTypes.Yonetim.Admin;
using SadakaEli.Model.Domain;
using SadakaEli.MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SadakaEli.MvcWebUI.Areas.Yonetim.Controllers
{
    public class AdminController : Controller
    {
        IAdminBs _bs;
        IRoleBs _roleBs;
        public AdminController(IAdminBs bs,IRoleBs roleBs)
        {
            _bs = bs;
            _roleBs = roleBs;
        }
        public ActionResult LogIn()
        {
            if (Request.Cookies["ckKullaniciAdi"]!=null&&Request.Cookies["ckSifre"]!=null)
            {
                string cryptoSalt = MagicStrings.AES_CRYPTO_SALT;
                string userNameHash = HashHelper.AESDecrypt(Request.Cookies["ckKullaniciAdi"].Value, cryptoSalt);
                string passwordHash = HashHelper.AESDecrypt(Request.Cookies["ckSifre"].Value, MagicStrings.AES_CRYPTO_SALT);
                Admin admin = _bs.LogIn(userNameHash, passwordHash);
                if (admin!=null)
                {
                    SessionManager.ActiveAdmin = admin;
                    return RedirectToAction("Index", "Home");
                }
            }

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  JsonResult LogIn(LogInVm vm)
        {
            Admin admin = _bs.LogIn(vm.Email, HashHelper.AESEncrypt(vm.Password, MagicStrings.AES_CRYPTO_SALT));
            if (admin !=null)
            {
                SessionManager.ActiveAdmin = admin;
                if (vm.RememberMe)
                {
                    HttpCookie ckAdminName = new HttpCookie("ckKullaniciADi", HashHelper.AESEncrypt(admin.Email, MagicStrings.AES_CRYPTO_SALT));
                    ckAdminName.Expires = DateTime.Now.AddDays(2);
                    HttpCookie ckPassword = new HttpCookie("ckSifre", HashHelper.AESEncrypt(admin.Password, MagicStrings.AES_CRYPTO_SALT));
                    ckPassword.Expires = DateTime.Now.AddDays(2);
                    Response.Cookies.Add(ckAdminName);
                    Response.Cookies.Add(ckPassword);
                }
                return Json(new { Operation = true });
            }
            return Json(new { Operation = false, Message = "Kullanıcı Bulunamadı" });
        }
        public ActionResult LogOut()
        {
            SessionManager.ActiveAdmin = null;

            Response.Cookies["ckKullaniciAdi"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["ckSifre"].Expires = DateTime.Now.AddDays(-1);


            return RedirectToAction("LogIn");
        }
        public ViewResult AdminList()
        {
            List<Admin> admins = _bs.GetAllActive();

            return View(admins);
        }
        public ViewResult AdminNew()
        {
            NewAdminVm vm = new NewAdminVm();
            vm.Roles = _roleBs.GetAllActive().Select(x => new SelectListItem()
            {
                Text = x.RoleName,
                Value = x.Id.ToString(),

            }).ToList();

            return View(vm);
        }
        [HttpPost]
        public JsonResult AdminNew(NewAdminVm vm)
        {
            NewAdminValidator val = new NewAdminValidator();
            ValidationResult valResult = val.Validate(vm);

            if (valResult.IsValid)
            {
                Admin admin = new Admin();
                admin.Created = DateTime.Now;
                admin.Email = vm.Email;
                admin.IsActive = true;
                admin.Password = vm.Password;
                admin.Photo = vm.FileName;
                admin.RoleId = vm.RoleId;
                admin.Modified = DateTime.Now;
                admin.FullName = vm.FullName;

                _bs.Insert(admin);
                return Json(new { Result = true, Message = "Kayıt Başarılı" });
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

                string path = "~/Areas/Yonetim/Content/img/AdminImages/" + fileName;


                file.SaveAs(Server.MapPath(path));

                return Json(new { Result = true, FileName = fileName });

            }

            return Json(new { Result = false, Message = "Lütfen fotoğraf seçiniz" });
        }

        public ActionResult AdminUpdate(int id)
        {
            var admin = _bs.GetById(id);
            return View(admin);
        }
        [HttpPost]
        public JsonResult AdminUpdateJson(UpdateAdminVm vm)
        {
            Admin admin = _bs.Get(x => x.Id == vm.Id);

            admin.Modified = DateTime.Now;
            admin.Password = HashHelper.AESEncrypt(vm.Password, MagicStrings.AES_CRYPTO_SALT);
            admin.IsActive = true;
            admin.Email = vm.Email;
            admin.FullName = vm.FullName;
            _bs.Update(admin);
           
            return Json(new { Operation = true });
            
        }
        public JsonResult AdminRoleUpdateJson(int adminId, int yetkiId)
        {
            var admin = _bs.GetById(adminId);
            admin.RoleId = yetkiId;
            _bs.Update(admin);
            return Json(new { Operation = true });
        }
        public JsonResult AdminDeleteJson(int id)
        {
            var admin = _bs.Get(x => x.Id == id);
            int result = _bs.Delete(admin);
            if (result>0)
                return Json(new { Operation = true, Message = "Silme İşlemi Başarıyla Gerçekleşti." });
            return Json(new { Operation = false, Message = "Silme İşlemi Başarısız Gerçekleşti." });

        }
    }
}