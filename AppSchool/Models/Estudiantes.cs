//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AppSchool.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Estudiantes
    {
        public int ID_estudiantes { get; set; }
        public int ID_curso { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Sexo { get; set; }
        public Nullable<int> Edad { get; set; }
        public string Codigo { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
    
        public virtual Curso Curso { get; set; }
    }
}
