using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppGestionEMS.Models
{
    public class Grupos
    {
        [Key]
        public string GrupoId { get; set; }
        public Boolean mañanatarde { get; set; }
    }
}