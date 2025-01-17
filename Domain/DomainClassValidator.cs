using System.ComponentModel.DataAnnotations;

namespace CVB.BL.Domain;

public class DomainClassValidator
{
    public void ValidateEntity<T>(T entity) where T : class
    {
        var validationContext = new ValidationContext(entity);
        var validationResults = new List<ValidationResult>();

        if (!Validator.TryValidateObject(entity, validationContext, validationResults, validateAllProperties: true))
        {
            var errors = validationResults.Select(r => r.ErrorMessage);
            throw new ValidationException($"Validation failed: {string.Join(" ", errors)}");
        }
    }
}