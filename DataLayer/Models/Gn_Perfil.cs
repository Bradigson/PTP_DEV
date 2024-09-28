﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Models
{
   public class Gn_Perfil
    {
       
        public DateTime FechaCreada { get; set; }
        [Key]
        public int IDPerfil { get; set; }
        public string Perfil { get; set; }
        public string Descripcion { get; set; }
        public long IDUsuario { get; set; }
        public int Bloquear { get; set; }
        public long IDEmpresa { get; set; }
        public DateTime UltimaFechaModificacion { get; set; }
    }
}
