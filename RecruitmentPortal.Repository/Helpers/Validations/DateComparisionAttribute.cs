// Custom validation attribute to ensure ApplicationEndDate is greater than ApplicationStartDate
using System.ComponentModel.DataAnnotations;

public class DateGreaterThanAttribute : ValidationAttribute
{
    private readonly string _comparisonProperty;

    public DateGreaterThanAttribute(string comparisonProperty)
    {
        _comparisonProperty = comparisonProperty;
    }

    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
        var comparisonValue = validationContext.ObjectType.GetProperty(_comparisonProperty)?.GetValue(validationContext.ObjectInstance);

        if (value is DateOnly dateValue && comparisonValue is DateOnly comparisonDate)
        {
            if (dateValue <= comparisonDate)
            {
                return new ValidationResult(ErrorMessage);
            }
        }

        return ValidationResult.Success;
    }
}

