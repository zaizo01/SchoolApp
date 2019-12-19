using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppSchool.Models;
using AppSchool.Models.ViewModels;

namespace AppSchool.Controllers
{
    public class CursoController : Controller
    {
        // GET: Curso
        public ActionResult Index()
        {
            List<ListCursoViewModel> lst;
            using (SchoolAppEntities db = new SchoolAppEntities())
            {
                lst = (from d in db.Curso
                       select new ListCursoViewModel
                       {
                           IdCurso = d.ID_curso,
                           Grado = d.Grado,
                           Seccion = d.Seccion,
                           CantDeEstudiantes = d.Cant_de_Estudiantes,
                           ProfesorEncargado = d.Profesor_encargado
                       }).ToList();
            }
            return View(lst);
        }

        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(CursoViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (SchoolAppEntities db = new SchoolAppEntities())
                    {
                        var oTabla = new Curso();
                        oTabla.Grado = model.Grado;
                        oTabla.Seccion = model.Seccion;
                        oTabla.Cant_de_Estudiantes = model.CantDeEstudiantes;
                        oTabla.Profesor_encargado = model.ProfesorEncargado;

                        db.Curso.Add(oTabla);
                        db.SaveChanges();
                    }
                    return Redirect("~/Curso/");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ActionResult Editar(int id)
        {
            CursoViewModel model = new CursoViewModel();
            using (SchoolAppEntities db = new SchoolAppEntities())
            {
                var oTabla = db.Curso.Find(id);
                model.Grado = oTabla.Grado;
                model.Seccion = oTabla.Seccion;
                model.CantDeEstudiantes = oTabla.Cant_de_Estudiantes;
                model.ProfesorEncargado = oTabla.Profesor_encargado;
                model.IdCurso = oTabla.ID_curso;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Editar(CursoViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (SchoolAppEntities db = new SchoolAppEntities())
                    {
                        var oTabla = db.Curso.Find(model.IdCurso);
                        oTabla.Grado = model.Grado;
                        oTabla.Seccion = model.Seccion;
                        oTabla.Cant_de_Estudiantes = model.CantDeEstudiantes;
                        oTabla.Profesor_encargado = model.ProfesorEncargado;

                        db.Entry(oTabla).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("~/Curso/");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            using (SchoolAppEntities db = new SchoolAppEntities())
            {
                var oTabla = db.Curso.Find(id);
                db.Curso.Remove(oTabla);
                db.SaveChanges();
            }
            return Redirect("~/Curso/");
        }
    } 
}