using System;
using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;

namespace tp9.Errors
{
	public interface IBizActionErrors
	{
        IImmutableList<ValidationResult> Error { get; }
        bool HasErrors { get; }
        void AddError(string errorMessage, params string[] propertyName);

    }
}

