using System;
using System.Collections.Generic;
using System.Text;

namespace Logging
{
	public class LogMessage
	{
		public readonly string Message;
		public readonly Guid EventId;
		public readonly DateTime EventDateTime;

		public LogMessage(string message, DateTime? eventDateTime = null, Guid eventId = new Guid())
		{
			this.Message = message;

			if (!eventDateTime.HasValue)
				eventDateTime = DateTime.Now;

			this.EventDateTime = (DateTime)eventDateTime;

			if (eventId == Guid.Empty)
				eventId = Guid.NewGuid();

			this.EventId = eventId;
		}
	}
}
