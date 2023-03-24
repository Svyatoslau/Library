using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Library.Core.Attributes;
internal class IsbnNumberValidationAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        string isbn = value as string;
        Console.WriteLine(isbn);
        if (string.IsNullOrEmpty(isbn))
        {
            return new ValidationResult("ISBN is required");
        }
        
        if (isbn.Length !=13 && isbn.Length != 17 )
        {
            return new ValidationResult("Not valid isbn");
        }

        if (!IsIsbn13Valid(isbn) && !IsIsbn10Valid(isbn))
        {
            return new ValidationResult("Not valid isbn");
        }

        return ValidationResult.Success;
    }

    private bool IsIsbn13Valid(string input)
    {
        input = String.Join("", input.Split("-"));
        Console.WriteLine(input);
        string pattern = "^[0-9]{13}$";
        return Regex.IsMatch(input, pattern);
    }
    private bool IsIsbn10Valid(string input)
    {
        input = String.Join(" ", input.Split("-"));
        string pattern = "^[0-9]{10}$";
        return Regex.Match(input, pattern).Success;
    }
}
