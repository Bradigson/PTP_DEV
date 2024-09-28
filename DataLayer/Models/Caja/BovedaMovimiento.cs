﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models.Caja
{
    public class BovedaMovimiento
    {
        [Key]
        public int Id { get; set; }
        public int idMoneda { get; set; }
        public int idTipoOperacionBoveda { get; set; }
        public string Descripcion { get; set; }
        public string Entrada_Salida { get; set; }
        public int idDesgloseXcajero { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int UsuarioIDCrea { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public int UsuarioIDActualiza { get; set; }
        public long idEmpresa { get; set; }
        public long IdSucursal { get; set; }
    }
}
