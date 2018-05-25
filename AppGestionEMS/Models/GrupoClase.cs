using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace AppGestionEMS.Models
{
    public class GrupoClase
    {
        public int Id { get; set; }

        [DisplayName("Grupo")]
        public string nombre { get; set; }
    }
}