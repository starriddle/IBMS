using System;

namespace IBMS_Personal.Entity
{
	internal class IBMSException : Exception
	{
		public IBMSException() { }

		public IBMSException(string message) : base(message) { }

		public IBMSException(string message, Exception innerException) : base(message, innerException) { }
	}
}
