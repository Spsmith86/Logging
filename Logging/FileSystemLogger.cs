using System;
using System.Collections.Generic;
using System.Text;

namespace Logging
{
	public class FileSystemLogger : ILogger
	{
		private readonly IFileSystem fileSystem;
		private readonly string logFilePath;
		private readonly string datetimeFormat;

		public FileSystemLogger(IFileSystem fileSystem, string logDirectoryPath, string logFileName, string datetimeFormat = "MM-dd-yyyy HH:mm:ss.fff tt")
		{
			if (fileSystem == null)
				throw new ArgumentException("FileSystem implementation must be provided.");

			this.fileSystem = fileSystem;

			if (!fileSystem.DirectoryExists(logDirectoryPath))
				throw new ArgumentException("Specified log file directory does not exist.");
			

			logFilePath = fileSystem.CombineDirectoryPathAndFileName(logDirectoryPath, logFileName);
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
				fileSystem.WriteToFile(logFilePath, formattedMessage, true);
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
	}
}
