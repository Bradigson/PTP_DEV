﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models.Caja
{
    public class Caja
    {
        [Key]
        public int Id { get; set; }
        public int numeroCaja { get; set; }
        public string NombreCaja { get; set; }
        public int idUsuarioResposable { get; set; }
        public int UsuarioIDCrea { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public int UsuarioIDActualiza { get; set; }
        public string EstadoCaja { get; set; }
        public long idEmpresa { get; set; }
        public long IdSucursal { get; set; }
        public DateTime FechaUltimoCierre { get; set; }
    }
}
