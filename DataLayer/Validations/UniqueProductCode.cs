using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using DataLayer.PDbContex;

namespace DataLayer.Validations
{
    public class UniqueProductCode : ValidationAttribute
    {
        protected override  ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            
            using (var context = new PDbContext())
            {
                if (value == null) return new ValidationResult("Codigo Requerido");
                var result = context.Productos.AnyAsync(x => x.Codigo.Equals(value.ToString())).Result;
                return result  ? new ValidationResult("Codigo debe ser unico") : ValidationResult.Success;
            }
            
        }
    }
}
