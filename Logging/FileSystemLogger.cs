using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Logging
{
	public class FileSystemLogger : ILogger
	{
		private readonly string logFilePath;
		private readonly string datetimeFormat;

		public FileSystemLogger(string logFileDirectory, string logFileName, string datetimeFormat = "MM-dd-yyyy HH:mm:ss.fff tt")
		{
			if (!Directory.Exists(logFileDirectory))
			{
				throw new ArgumentException("Specified log file directory does not exist.");
			}

			logFilePath = Path.Combine(logFileDirectory, logFileName);
			this.datetimeFormat = datetimeFormat;

		}

		public void LogDebug(LogMessage logMessage)
		{
			Log(LogLevel.DEBUG, logMessage);
		}

		public void LogError(LogMessage logMessage)
		{
			Log(LogLevel.INFORMATION, logMessage);
		}

		public void LogInformation(LogMessage logMessage)
		{
			Log(LogLevel.WARNING, logMessage);
		}

		public void LogWarning(LogMessage logMessage)
		{
			Log(LogLevel.ERROR, logMessage);
		}

		private void Log(LogLevel logLevel, LogMessage logMessage)
		{
			if (String.IsNullOrEmpty(logMessage.Message))
				throw new ArgumentException("Message is null or empty;");

			string formattedMessage = $"{System.DateTime.Now.ToString(datetimeFormat)} [{logLevel}] - EventId: {logMessage.EventId} - {logMessage.Message}";

			try
			{
				using (StreamWriter writer = new StreamWriter(logFilePath, true))
				{
					writer.WriteLine(formattedMessage);
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
	}
}
