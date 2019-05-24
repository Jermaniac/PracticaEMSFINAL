using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppGestionEMS.Models
{
    public class Convocatorias
    {
        [Key]
        public string ConvocatoriaId { get; set; }
        public Boolean actual { get; set; }


    }
}