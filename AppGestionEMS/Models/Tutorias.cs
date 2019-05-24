using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
namespace AppGestionEMS.Models
{
    public class Tutorias
    {
        [Key]
        [Column(Order = 1)]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        [Key]
        [Column(Order = 2)]
        public string GrupoPracticasId { get; set; }
        public virtual GrupoPracticas GrupoPractica { get; set; }
        [Key]
        [Column(Order = 3)]
        public int CursoId { get; set; }
        public virtual Cursos Curso { get; set; }
        [Key]
        [Column(Order = 4)]
        public string ConvocatoriaId { get; set; }
        public virtual Convocatorias Convocatoria { get; set; }

        public string IdTutoria { get; set; }
        public string IdAsignatura { get; set; }
        public DateTime fecha { get; set; }
    }
}