using PersonelMvc.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PersonelMvc.Controllers;
using System.Data.Entity;
using PersonelMvc.ViewModels;

namespace PersonelMvc.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        MvcEntities1 db = new MvcEntities1();
        public ActionResult Index()
        {
            var model = db.Personel.Include(x=>x.Departman).ToList();
            return View(model);
        }
        public ActionResult Yeni()
        {
            var model = new PersonelFormViewModel()
            {
                Departmanlar = db.Departman.ToList()
            };
            return View("PersonelForm",model);
        }
        public ActionResult Kaydet(Personel personel)
        {
            if (personel.id == 0) // id 0 ise yeni kayıt
            {
                db.Personel.Add(personel);
            }
            else // id si olan kaydı güncelle 
            {
                // bu satırda id bilgisini almadan o an ki kayıdın güncellemesini sağluyoruz.
                db.Entry(personel).State=System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
            return RedirectToAction("Index");  // index sayfasına yönlerdiriyor.
        }
        public ActionResult Guncelle(int id)
        {
            var model = new PersonelFormViewModel()
            {
                Departmanlar =db.Departman.ToList(),
                Personel=db.Personel.Find(id)
            };
            return View("PersonelForm", model);
        }
        public ActionResult Sil(int id)
        {
            var silpersonel = db.Personel.Find(id);
            if (silpersonel == null)
            {
                return HttpNotFound();
            }
            db.Personel.Remove(silpersonel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}