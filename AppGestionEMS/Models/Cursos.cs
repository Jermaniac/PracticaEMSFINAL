using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace AppGestionEMS.Models
{
    public class Cursos
    {
        [Key]
        public int CursoId { get; set; }
        public Boolean actual { get; set; }
        public int maxMatriculados { get; set; }
    }
}