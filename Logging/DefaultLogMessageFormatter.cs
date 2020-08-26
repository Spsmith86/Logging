using System;
using System.Collections.Generic;
using System.Text;

namespace Logging
{
	public class DefaultLogMessageFormatter : ILogMessageFormatter
	{
		private readonly string datetimeFormat = "MM-dd-yyyy HH:mm:ss.fff tt";
		public string FormatLogMessage(LogMessage logMessage)
		{
			return $"{logMessage.EventDateTime.ToString(datetimeFormat)} [{logMessage.LogLevel}] - EventId: {logMessage.EventId} - {logMessage.Message}";
		}
	}
}
