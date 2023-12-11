using System;
using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;

namespace tp9.Errors
{
	public interface IBizAction<in TIn,out TOut>
	{

       // IImmutableList<ValidationResult> Errors { get; }
        //bool HasErrors { get; }
       
        TOut Action(TIn dto);
    }

    //This interface ensures that this business logic class conforms to a standard 
    //interface that you use across all your business logic.
}

