﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DataLayer.Validations;

namespace DataLayer.Models
{
    public class Marca:BaseModel
    {
        [StringLength(30),Required(ErrorMessage = "Nombre Requerido")]
       // [NombreMarcaValido]
        public string Nombre  { get; set; }

        public bool Activo { get; set; } = true;

        public DateTime FechaModificacion { get; set; } = DateTime.Now;

        public  virtual ICollection<Versiones> Versiones { get; set; }

    }
}
