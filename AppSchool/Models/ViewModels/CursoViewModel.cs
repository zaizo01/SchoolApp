using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppSchool.Models.ViewModels
{
    public class CursoViewModel
    {
        
        public int IdCurso { get; set; }
        public string Grado { get; set; }
        public string Seccion { get; set; }
        public int? CantDeEstudiantes { get; set; }
        public string ProfesorEncargado { get; set; }
    }
}