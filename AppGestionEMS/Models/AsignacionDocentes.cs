using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AppGestionEMS.Models
{
    public class AsignacionDocentes
    {
        [Key]
        [Column(Order = 1)]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        [Key]
        [Column(Order = 2)]
        public int CursoId { get; set; }
        public virtual Cursos Curso { get; set; }
        [Key]
        [Column(Order = 3)]
        public string GrupoId { get; set; }
        public virtual Grupos Grupo { get; set; }

        public string Asignatura { get; set; }

    }
}