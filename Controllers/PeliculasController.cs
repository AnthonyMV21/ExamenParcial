using ExaParcialMondalgo.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExaParcialMondalgo.Controllers
{
    public class PeliculasController : Controller
    {
        // GET: Peliculas
        public ActionResult Index()
        {
            using (CineplanetEntities contexto = new CineplanetEntities())
            {
                return View(contexto.Peliculas.ToList());
            }
        }

        // GET: Peliculas/Details/5
        public ActionResult Details(int id)
        {
            using (CineplanetEntities contexto = new CineplanetEntities())
            {
                return View(contexto.Peliculas.Where(x => x.PeliculasId == id).FirstOrDefault());
            }
        }

        // GET: Peliculas/Create
        public ActionResult Create()
        {
            using (CineplanetEntities contexto = new CineplanetEntities())
            {
                int maxPeliculasId = contexto.Peliculas.Max(r => r.PeliculasId);
                var model = new Peliculas
                {
                    PeliculasId = maxPeliculasId + 1
                };
                return View(model);
            }
        }

        // POST: Peliculas/Create
        [HttpPost]
        public ActionResult Create(Peliculas peliculas)
        {
            try
            {
                using (CineplanetEntities contexto = new CineplanetEntities())
                {
                    // TODO: Add insert logic here
                    var newPeliculas = new Peliculas
                    {
                        PeliculasId = peliculas.PeliculasId,
                        titulo = peliculas.titulo,
                        duracion = peliculas.duracion,
                        clasificacion = peliculas.clasificacion,
                        estreno = peliculas.estreno,
                    };
                    contexto.Peliculas.Add(newPeliculas);
                    contexto.SaveChanges();
                    return RedirectToAction("/Index");

                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Peliculas/Edit/5
        public ActionResult Edit(int id)
        {
            using (CineplanetEntities contexto = new CineplanetEntities())
            {
                return View(contexto.Peliculas.Where(x => x.PeliculasId == id).FirstOrDefault());
            }
        }

        // POST: Peliculas/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Peliculas peliculas)
        {
            try
            {
                using (CineplanetEntities contexto = new CineplanetEntities())
                {
                    // Usando el espacio de nombres correcto para EF 6
                    contexto.Entry(peliculas).State = EntityState.Modified;
                    contexto.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View("Index");
            }
        }

        // GET: Peliculas/Delete/5
        public ActionResult Delete(int id)
        {
            using (CineplanetEntities contexto = new CineplanetEntities())
            {
                return View(contexto.Peliculas.Where(x => x.PeliculasId == id).FirstOrDefault());
            }
        }

        // POST: Peliculas/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (CineplanetEntities contexto = new CineplanetEntities())
                {
                    Peliculas objPeliculas = contexto.Peliculas.Where(x => x.PeliculasId == id).FirstOrDefault();
                    contexto.Peliculas.Remove(objPeliculas);
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
