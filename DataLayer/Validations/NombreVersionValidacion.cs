using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using DataLayer.PDbContex;

namespace DataLayer.Validations
{
    public class NombreVersionValidacion : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            using (var context = new PDbContext())
            {
                if (value == null) return new ValidationResult("Nombre de Version Requerido");
                var result = context.Versiones.AnyAsync(x => x.Nombre.Equals(value.ToString())).Result;
                return result ? new ValidationResult("Nombre de Version debe ser unico") : ValidationResult.Success;
            }
        }
    }
}
