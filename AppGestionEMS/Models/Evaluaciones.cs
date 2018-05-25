using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AppGestionEMS.Models
{
    public class Evaluaciones
    {
        public enum ConvocatoriaType
        {
            Ordinaria,
            Extraordinaria
        }

        public int Id { get; set; }

        [Display(Name = "Curso")]
        public int CursoId { get; set; }
        public virtual Cursos Curso { get; set; }

        [Display(Name = "Alumno")]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public ConvocatoriaType Convocatoria { get; set; }
        public int Trabajo1 { get; set; }
        public int Trabajo2 { get; set; }
        public int Trabajo3 { get; set; }
        public int Test { get; set; }
        public int Practica { get; set; }

    }
}