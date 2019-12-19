using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppSchool.Models;
using AppSchool.Models.ViewModels;

namespace AppSchool.Controllers
{
    public class EstudianteController : Controller
    {
        // GET: Curso
        public ActionResult Index()
        {
            List<ListEstudianteViewModel> lst;
            using (SchoolAppEntities db = new SchoolAppEntities())
            {
                lst = (from d in db.Estudiantes
                       select new ListEstudianteViewModel
                       {
                           IdEstudiantes = d.ID_estudiantes,
                           IdCurso = d.ID_curso,
                           Nombre = d.Nombre,
                           Apellido = d.Apellido,
                           Sexo = d.Sexo,
                           Edad = d.Edad,
                           Codigo = d.Codigo,
                           Telefono = d.Telefono,
                           Direccion = d.Direccion
                       }).ToList();
            }
            return View(lst);
        }

        public ActionResult agregarEstudiante()
        {
            List<ListCursoViewModel> lst;
            using (SchoolAppEntities db = new SchoolAppEntities())
            {
                lst = (from d in db.Curso
                       select new ListCursoViewModel
                       {
                           IdCurso = d.ID_curso,
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
        public ActionResult agregarEstudiante(EstudianteViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (SchoolAppEntities db = new SchoolAppEntities())
                    {
                        var oTabla = new Estudiantes();
                        oTabla.ID_curso = model.IdCurso;
                        oTabla.Nombre = model.Nombre;
                        oTabla.Apellido = model.Apellido;
                        oTabla.Sexo = model.Sexo;
                        oTabla.Edad = model.Edad;
                        oTabla.Codigo = model.Codigo;
                        oTabla.Telefono = model.Telefono;
                        oTabla.Direccion = model.Direccion;

                        db.Estudiantes.Add(oTabla);
                        db.SaveChanges();
                    }
                    return Redirect("~/Estudiante/");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ActionResult EditarEstudiante(int id)
        {
            EstudianteViewModel model = new EstudianteViewModel();
            using (SchoolAppEntities db = new SchoolAppEntities())
            {
                var oTabla = db.Estudiantes.Find(id);
                model.IdCurso = oTabla.ID_curso;
                model.Nombre = oTabla.Nombre;
                model.Apellido = oTabla.Apellido;
                model.Sexo = oTabla.Sexo;
                model.Edad = oTabla.Edad;
                model.Codigo = oTabla.Codigo;
                model.Telefono = oTabla.Telefono;
                model.Direccion = oTabla.Direccion;
                model.IdEstudiantes = oTabla.ID_estudiantes;

            }
            return View(model);
        }

        [HttpPost]
        public ActionResult EditarEstudiante(EstudianteViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (SchoolAppEntities db = new SchoolAppEntities())
                    {
                        var oTabla = db.Estudiantes.Find(model.IdEstudiantes);
                        oTabla.ID_curso = model.IdCurso;
                        oTabla.Nombre = model.Nombre;
                        oTabla.Apellido = model.Apellido;
                        oTabla.Sexo = model.Sexo;
                        oTabla.Edad = model.Edad;
                        oTabla.Codigo = model.Codigo;
                        oTabla.Telefono = model.Telefono;
                        oTabla.Direccion = model.Direccion;
                   


                        db.Entry(oTabla).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("~/Estudiante/");
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
                var oTabla = db.Estudiantes.Find(id);
                db.Estudiantes.Remove(oTabla);
                db.SaveChanges();
            }
            return Redirect("~/Estudiante/");
        }
    }
}