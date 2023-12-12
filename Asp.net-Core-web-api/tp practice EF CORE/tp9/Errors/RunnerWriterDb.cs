using System;
using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;
using test8.DB;
using tp9.Library;

namespace tp9.Errors
{
	public class RunnerWriterDb<TIn,TOut>:IRunnerWriterDb<TIn, TOut> where TOut : class
	{
		private readonly IBizAction<TIn,TOut> _bizAction;

        private DBContext _dBContext;
        private readonly IBizActionErrors _bizActionErrors;

        //just for test
        private readonly IBizAction<TIn, TOut> _bizAction2;
        private readonly IBizAction<TIn, TOut> _bizAction3;

        public RunnerWriterDb(IBizAction<TIn, TOut> bizAction,DBContext dBContext,IBizActionErrors bizActionErrors)
		{
			_bizAction = bizAction;
			_dBContext = dBContext;
			_bizActionErrors = bizActionErrors;
		}

		//public IImmutableList<ValidationResult> Errors => _bizAction.Errors;
		//public bool HasError => _bizAction.HasErrors;

		public TOut RunAction(TIn dataIn) 
		{
			//page 121
			//          - PlaceOrderPart1—Creates the Order entity, with no LineItems.
			//          - PlaceOrderPart2—Adds the LineItems for each book bought to the Order
			//             entity that was created by the PlaceOrderPart1 class.

			using (var transaction = _dBContext.Database.BeginTransaction())
			{
				var result1 = _bizAction.Action(dataIn);

				//the data are saved loacly inside the transaction
				//not yet saved in database
				
				if(_bizActionErrors.HasErrors == true)
					return null;
				else
                   _dBContext.SaveChanges();


                //var result2 = _bizAction2.Action(dataIn);

                ////the data are saved loacly inside the transaction
                ////not yet saved in database

                //if (_bizActionErrors.HasErrors == true)
                //    return null;
                //else
                //    _dBContext.SaveChanges();


                //var result2 = _bizAction.Action(dataIn);
                //if (_bizActionErrors.HasErrors != true)
                //{
                //    //the data are saved loacly inside the transaction
                //    //not yet saved in database
                //    _dBContext.SaveChanges();
                //}

                //After each logique action i should call SaveChange
                //all the transaction are dependent of each other
                //if the on of the transaction fail i call rollback



                //the data will be saved in database

                if (_bizActionErrors.HasErrors != true)
				{
					transaction.Commit();
					return result1;
				}
			}

			return null;
		}
	}
}

