﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PruebaUmg.Models;
using PruebaUmg.Models.ViewModel;
using Rotativa;

namespace PruebaUmg.Controllers
{
    public class DocentesController : Controller
    {
        private TestUmgEntities db = new TestUmgEntities();

        // GET: Docentes
        public ActionResult Index()
        {
            return View(db.Docentes.ToList());
        }

        // GET: Docentes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Docente docente = db.Docentes.Find(id);
            if (docente == null)
            {
                return HttpNotFound();
            }
            return View(docente);
        }

        // GET: Docentes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Docentes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,nombre")] Docente docente)
        {
            if (ModelState.IsValid)
            {
                db.Docentes.Add(docente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(docente);
        }

        // GET: Docentes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Docente docente = db.Docentes.Find(id);
            if (docente == null)
            {
                return HttpNotFound();
            }
            return View(docente);
        }

        // POST: Docentes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,nombre")] Docente docente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(docente).State = EntityState.Modified;
               // db.Entry(docente).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(docente);
        }

        // GET: Docentes/Delete/5
        public ActionResult Delete(int? id)
        {
            var dt = new DataTable();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("nombre", typeof(int));

            dt.Rows.Add(1, "pedro");
            dt.Rows.Add(2, "maria");
            var parametros = new SqlParameter("@lst", SqlDbType.Structured);
            parametros.Value = dt;
            parametros.TypeName = "dbo.DatasPersona"; //tipo de dato

            using( var dd = new TestUmgEntities())
            {
                dd.Database.ExecuteSqlCommand("exec sqlInsertPersona @sql", parametros);
            }


            /*
             create type{
                id int,
                nombre varchar(50)
            }

            create procedure sqlInsertPersona(
                @lst DatosPersona READONLY
            )as begin
                inset into persona (name,cp)
                select * from @sql
            fin
             */
            return View();
        }

        // POST: Docentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Docente docente = db.Docentes.Find(id);
            db.Docentes.Remove(docente);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


        public ActionResult dropList()
        {
            List<Docente> ll = null;
            using ( var ddd = new TestUmgEntities())
            {
                ll = (from d in ddd.docente
                      select new Docente
                      {
                          Id = d.id,
                          nombre = d.nombre
                      }).ToList();

            }

            List<SelectListItem> items = ll.ConvertAll(d =>
           {
               return new SelectListItem
               {
                   Text = d.nombre.ToString(),
                   Value = d.Id.ToString(),
                   Selected = true
               };
           }).ToList();

            ViewBag.ll = items;
            return View();
        }

        public ActionResult Printdd()
        {
            return new ActionAsPdf("report")
            {
                FileName = "test.pdf"
            };
        }
    }
}
