using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PersonelMvc.Models.EntityFramework;

namespace PersonelMvc.Controllers
{
    public class DepartmanController : Controller
    {
        // GET: Departman
        MvcEntities1 db = new MvcEntities1();
        public ActionResult Index()
        {
            var model = db.Departman.ToList();
            return View(model);
        }
        [HttpGet] //veriyi okuma öz nitelik
        public ActionResult Yeni()
        {
            return View("DepartmanFrom");
        }
        [HttpPost]
        public ActionResult Kaydet(Departman departman)
        {
            if (departman.id==0) // id 0 ise yeni kayıt
            {
                db.Departman.Add(departman);
            }
            else // id si olan kaydı güncelle 
            {
                var guncellenecekdepartman = db.Departman.Find(departman.id);
                if (guncellenecekdepartman==null)
                {
                    return HttpNotFound();
                }
                guncellenecekdepartman.Ad = departman.Ad;
            }
            db.SaveChanges();
            return RedirectToAction("Index","Departman");
        }
        public ActionResult Guncelle(int id)
        {
            var model = db.Departman.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View("DepartmanFrom", model);
        }
        public ActionResult Sil(int id)
        {
            var sildepartman = db.Departman.Find(id);
            if (sildepartman==null)
            {
                return HttpNotFound();
            }
            db.Departman.Remove(sildepartman);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}