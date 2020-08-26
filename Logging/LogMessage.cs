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
		public readonly LogLevel LogLevel;

		public LogMessage(LogLevel logLevel, string message, DateTime? eventDateTime = null, Guid eventId = new Guid())
		{
			this.LogLevel = logLevel;
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
