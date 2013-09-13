using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using nahamaleo.Models;
using System.IO;

namespace nahamaleo.Controllers
{
    public class PropertyController : Controller
    {
        private PropertyEntitiesContext db = new PropertyEntitiesContext();

        //
        // GET: /Property/

        public ActionResult Index()
        {
            return View(db.PropertyModels.ToList());
        }

        //
        // GET: /Property/Details/5

        public ActionResult Details(int id = 0)
        {
            PropertyModel propertymodel = db.PropertyModels.Find(id);
            if (propertymodel == null)
            {
                return HttpNotFound();
            }
            return View(propertymodel);
        }

        //
        // GET: /Property/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Property/Create

        [HttpPost]
        public ActionResult Create(PropertyModel propertymodel, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if (image != null && image.ContentLength > 0)
                {
                    // extract only the fielname
                    var fileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(image.FileName);
                    // store the file inside ~/uploads folder
                    var path = Path.Combine(Server.MapPath("~/uploads"), fileName);
                    image.SaveAs(path);
                    propertymodel.image = "~/uploads/" + fileName;
                }
                db.PropertyModels.Add(propertymodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(propertymodel);
        }

        //
        // GET: /Property/Edit/5

        public ActionResult Edit(int id = 0)
        {
            PropertyModel propertymodel = db.PropertyModels.Find(id);
            if (propertymodel == null)
            {
                return HttpNotFound();
            }
            return View(propertymodel);
        }

        //
        // POST: /Property/Edit/5

        [HttpPost]
        public ActionResult Edit(PropertyModel propertymodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(propertymodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(propertymodel);
        }

        //
        // GET: /Property/Delete/5

        public ActionResult Delete(int id = 0)
        {
            PropertyModel propertymodel = db.PropertyModels.Find(id);
            if (propertymodel == null)
            {
                return HttpNotFound();
            }
            return View(propertymodel);
        }

        //
        // POST: /Property/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            PropertyModel propertymodel = db.PropertyModels.Find(id);
            db.PropertyModels.Remove(propertymodel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}