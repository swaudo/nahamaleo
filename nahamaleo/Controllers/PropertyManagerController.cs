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
    public class PropertyManagerController : Controller
    {
        private PropertyEntitiesContext db = new PropertyEntitiesContext();

        //
        // GET: /PropertyManager/

        public ActionResult Index()
        {
            return View(db.PropertyModels.ToList());
        }

        //
        // GET: /sale/

        //
        // GET: /PropertyManager/Details/5

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
        // GET: /PropertyManager/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /PropertyManager/Create

        [HttpPost]
        public ActionResult Create(PropertyModel propertymodel, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                //Verify that the user selected a file
                if (file != null && file.ContentLength > 0)
                {
                    // extract only the fielname
                    var fileName = Path.GetFileName(file.FileName);
                    // store the file inside ~/App_Data/uploads folder
                    var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);
                    file.SaveAs(path);
                }
                db.PropertyModels.Add(propertymodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(propertymodel);
        }

        //
        // GET: /PropertyManager/Edit/5

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
        // POST: /PropertyManager/Edit/5

        [HttpPost]
        public ActionResult Edit(PropertyModel propertymodel, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                // Verify that the user selected a file
                if (image != null && image.ContentLength > 0)
                {
                    // extract only the fielname
                    var fileName = Guid.NewGuid().ToString() + "_" +
                        Path.GetFileName(image.FileName);
                    // store the file inside ~/App_Data/uploads folder
                    var path = Path.Combine(Server.MapPath("~/uploads"), fileName);
                    image.SaveAs(path);
                    propertymodel.image = "~/uploads/" + fileName;
                }
                db.Entry(propertymodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(propertymodel);
        }

        //
        // GET: /PropertyManager/Delete/5

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
        // POST: /PropertyManager/Delete/5

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

        public ActionResult sale(string search)
        {
            var properties = from m in db.PropertyModels
                             select m;
            string searchString = search;

            if (!String.IsNullOrEmpty(searchString))
            {
                properties = properties.Where(s => s.rent_or_buy.Contains(searchString));
            }

            return View(properties);
        }

        public ActionResult queryForm(string location, string property, string rooms, string rentorbuy, int? minCost, int? maxCost)
        {
            var properties = from m in db.PropertyModels

                             where ((string.IsNullOrEmpty(location) ? true : m.property_location.Contains(location)) &&
                             (string.IsNullOrEmpty(property) ? true : m.property_type.Contains(property)) &&
                             (string.IsNullOrEmpty(rooms) ? true : m.no_of_rooms.Contains(rooms)) &&
                                 //( ? true : m.rent_or_buy.Contains(rentorbuy))
                                    (minCost == null ? true : minCost < m.property_cost) &&
                                    (maxCost == null ? true : maxCost > m.property_cost) &&
                                    (string.IsNullOrEmpty(rentorbuy) ? true : m.rent_or_buy.Contains(rentorbuy)))
                             select m;

            return View(properties);
        }

    }
}