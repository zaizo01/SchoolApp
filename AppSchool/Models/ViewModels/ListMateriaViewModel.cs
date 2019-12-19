using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppSchool.Models.ViewModels
{
    public class ListMateriaViewModel
    {
        public int IdMaterias { get; set; }
        public int IdCurso { get; set; }
        public string Profesor { get; set; }
        public string Materia { get; set; }
        public string Horario { get; set; }
        public string Duracion { get; set; }
    }
}