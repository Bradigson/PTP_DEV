using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using DataLayer.PDbContex;

namespace DataLayer.Validations
{
    public class NombreMarcaValido : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            using (var context = new PDbContext())
            {
                if (value == null) return new ValidationResult("Nombre de Marca Requerido");
                var result = context.Marcas.AnyAsync(x => x.Nombre.Equals(value.ToString()) && x.IdEmpresa==long.Parse(value.ToString())).Result;
                return result ? new ValidationResult("Nombre de Marca debe ser unico") : ValidationResult.Success;
            }
        }
    }
}
