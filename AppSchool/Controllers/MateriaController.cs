using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppSchool.Models;
using AppSchool.Models.ViewModels;

namespace AppSchool.Controllers
{
    public class MateriaController : Controller
    {
        // GET: Curso
        public ActionResult Index()
        {
            List<ListMateriaViewModel> lst;
            using (SchoolAppEntities db = new SchoolAppEntities())
            {
                lst = (from d in db.Materias
                       select new ListMateriaViewModel
                       {
                           IdMaterias = d.ID_materias,
                           IdCurso = d.ID_curso,
                           Profesor = d.Profesor,
                           Materia = d.Materia,
                           Horario = d.Horario,
                           Duracion = d.Duracion
                       }).ToList();
            }
           

            return View(lst);
        }

        public ActionResult agregarMateria()
        {
            List<ListCursoViewModel> lst;
            using (SchoolAppEntities db = new SchoolAppEntities())
            {
                lst = (from d in db.Curso
                       select new ListCursoViewModel
                       {
                            IdCurso  = d.ID_curso,
                            Grado = d.Grado,
                            Seccion = d.Seccion
                       }).ToList();
            }
            List<SelectListItem> items = lst.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.Grado.ToString() + d.Seccion.ToString(),
                    Value = d.IdCurso.ToString(),
                    Selected = false
                };
            });

            ViewBag.listaID = items;
            return View();
        }

        [HttpPost]
        public ActionResult agregarMateria(MateriaViewModel model)
        {
            List<ListMateriaViewModel> lst;
            try
            {
                if (ModelState.IsValid)
                {
                    using (SchoolAppEntities db = new SchoolAppEntities())
                    {
                        var oTabla = new Materias();
                        oTabla.ID_curso = model.IdCurso;
                        oTabla.Profesor = model.Profesor;
                        oTabla.Materia = model.Materia;
                        oTabla.Horario = model.Horario;
                        oTabla.Duracion = model.Duracion;

                        db.Materias.Add(oTabla);
                        db.SaveChanges();

                    }
                    return Redirect("~/Materia/");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ActionResult EditarMateria(int id)
        {
            MateriaViewModel model = new MateriaViewModel();
            using (SchoolAppEntities db = new SchoolAppEntities())
            {
                var oTabla = db.Materias.Find(id);
                model.IdCurso = oTabla.ID_curso;
                model.Profesor = oTabla.Profesor;
                model.Materia = oTabla.Materia;
                model.Horario = oTabla.Horario;
                model.Duracion = oTabla.Duracion;
                model.IdMaterias = oTabla.ID_materias;

            }
            return View(model);
        }

        [HttpPost]
        public ActionResult EditarMateria(MateriaViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (SchoolAppEntities db = new SchoolAppEntities())
                    {
                        var oTabla = db.Materias.Find(model.IdMaterias);
                        oTabla.ID_curso = model.IdCurso;
                        oTabla.Profesor = model.Profesor;
                        oTabla.Materia = model.Materia;
                        oTabla.Horario = model.Horario;
                        oTabla.Duracion = model.Duracion;

                        db.Entry(oTabla).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("~/Materia/");
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
                var oTabla = db.Materias.Find(id);
                db.Materias.Remove(oTabla);
                db.SaveChanges();
            }
            return Redirect("~/Materia/");
        }
    }
}