using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace AppGestionEMS.Models
{
    public class GrupoPracticas
    {

        [Key]
        public string GrupoPracticasId { get; set; }
        public Boolean activo { get; set; }
    }
}