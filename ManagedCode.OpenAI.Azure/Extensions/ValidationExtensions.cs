﻿using System.ComponentModel.DataAnnotations;

namespace ManagedCode.OpenAI.Extensions;

internal static class ValidationExtensions
{
    public static void Validate(this object obj)
    {
        Validator.ValidateObject(obj, new ValidationContext(obj), true);
    }
}