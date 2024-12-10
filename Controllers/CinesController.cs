using ExaParcialMondalgo.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;


namespace ExaParcialMondalgo.Controllers
{
    public class CinesController : Controller
    {
        // GET: Cine
        public ActionResult Index()
        {
            using (CineplanetEntities contexto = new CineplanetEntities())
            {
                return View(contexto.Cines.ToList());
            }
        }

        // GET: Cine/Details/5
        public ActionResult Details(int id)
        {
            using (CineplanetEntities contexto = new CineplanetEntities())
            {
                return View(contexto.Cines.Where(x => x.CinesId == id).FirstOrDefault());
            }
        }

        // GET: Cine/Create
        public ActionResult Create()
        {
            using (CineplanetEntities contexto = new CineplanetEntities())
            {
                int maxCinesId = contexto.Cines.Max(r => r.CinesId);
                var model = new Cines
                {
                    CinesId = maxCinesId + 1
                };
                return View(model);
            }
        }

        // POST: Cine/Create
        [HttpPost]
        public ActionResult Create(Cines cines)
        {
            try
            {
                using (CineplanetEntities contexto = new CineplanetEntities())
                {
                    // TODO: Add insert logic here
                    var newCines = new Cines
                    {
                        CinesId = cines.CinesId,
                        nombre = cines.nombre,
                        direccion = cines.direccion,
                        telefono = cines.telefono,
                    };
                    contexto.Cines.Add(newCines);
                    contexto.SaveChanges();
                    return RedirectToAction("/Index");

                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Cine/Edit/5
        public ActionResult Edit(int id)
        {
            using (CineplanetEntities contexto = new CineplanetEntities())
            {
                return View(contexto.Cines.Where(x => x.CinesId == id).FirstOrDefault());
            }
        }

        // POST: Cine/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Cines cines)
        {
            try
            {
                using (CineplanetEntities contexto = new CineplanetEntities())
                {
                    // Usando el espacio de nombres correcto para EF 6
                    contexto.Entry(cines).State = EntityState.Modified;
                    contexto.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View("Index");
            }
        }


        // GET: Cine/Delete/5
        public ActionResult Delete(int id)
        {
            using (CineplanetEntities contexto = new CineplanetEntities())
            {
                return View(contexto.Cines.Where(x => x.CinesId == id).FirstOrDefault());
            }
        }

        // POST: Cine/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (CineplanetEntities contexto = new CineplanetEntities())
                {
                    Cines objCines = contexto.Cines.Where(x => x.CinesId == id).FirstOrDefault();
                    contexto.Cines.Remove(objCines);
                    contexto.SaveChanges();
                }
                return RedirectToAction("/Index");
            }
            catch
            {
                return View("/");
            }
        }
    }
}
