using System;
using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;

namespace tp9.Errors
{
	public interface IRunnerWriterDb<TIn,TOut>
	{
        //IImmutableList<ValidationResult> Errors { get; }
       // bool HasError { get; }
        TOut RunAction(TIn dataIn);
    }
}

