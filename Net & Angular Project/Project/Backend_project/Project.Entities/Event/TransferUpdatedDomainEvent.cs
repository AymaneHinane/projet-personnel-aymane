using System;
using Project.Entities.Models;

namespace Project.Entities.Event
{
	public class TransferUpdatedDomainEvent:IDomainEvent
	{
		public Transfer? transfer { get; }
		
		public TransferUpdatedDomainEvent(Transfer transfer)
		{
			this.transfer = transfer;
		}
	}
}

