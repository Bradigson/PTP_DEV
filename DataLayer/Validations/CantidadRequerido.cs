﻿using System.ComponentModel.DataAnnotations;
using DataLayer.ViewModels;

namespace DataLayer.Validations
{
    public class CantidadRequerido : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var product = (ProductoCreateViewModel) validationContext.ObjectInstance;
            if (product.EsLote)
            {
                return value == null || (int)value == 0 ? new ValidationResult("Cantidad por Loto Obligatoria") : ValidationResult.Success;
            }

            return ValidationResult.Success;
        }
    }
}
