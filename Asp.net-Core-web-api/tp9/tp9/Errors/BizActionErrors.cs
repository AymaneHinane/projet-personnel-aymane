using System;
using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;

namespace tp9.Errors
{
	public  class BizActionErrors: IBizActionErrors
    {
		private readonly List<ValidationResult> _errors = new List<ValidationResult>();

        public IImmutableList<ValidationResult> Error => _errors.ToImmutableList();

		public bool HasErrors => _errors.Any();

        public void AddError(string errorMessage, params string[] propertyName)
        {
            _errors.Add(new ValidationResult(errorMessage, propertyName));
        }      
    }
}

