using System;
using System.Collections.Generic;
using System.Text;

namespace Logging
{
	public class LogMessage
	{
		public readonly string Message;
		public readonly Guid EventId;

		public LogMessage(string message, Guid eventId = new Guid())
		{
			this.Message = message;

			if (eventId == Guid.Empty)
				eventId = Guid.NewGuid();

			this.EventId = eventId;
		}
	}
}
