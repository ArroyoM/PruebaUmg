//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PruebaUmg.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class alumno_curso
    {
        public int Id { get; set; }
        public int Curso_id { get; set; }
        public int alumno_id { get; set; }
    
        public virtual Curso Curso { get; set; }
        public virtual alumno alumno { get; set; }
    }
}
