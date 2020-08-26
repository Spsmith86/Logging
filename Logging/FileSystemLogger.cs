using System;
using System.Collections.Generic;
using System.Text;

namespace Logging
{
	public class FileSystemLogger : ILogger
	{
		private readonly IFileSystem fileSystem;
		private readonly ILogMessageFormatter logMessageFormatter;
		private readonly string logFilePath;

		public FileSystemLogger(IFileSystem fileSystem, ILogMessageFormatter logMessageFormatter, string logDirectoryPath, string logFileName)
		{
			if (fileSystem == null)
				throw new ArgumentException("FileSystem implementation must be provided.");

			if (logMessageFormatter == null)
				throw new ArgumentException("LogMessageFormatter implementation must be provided.");

			this.logMessageFormatter = logMessageFormatter;
			this.fileSystem = fileSystem;

			if (!fileSystem.DirectoryExists(logDirectoryPath))
				throw new ArgumentException("Specified log file directory does not exist.");
			
			logFilePath = fileSystem.CombineDirectoryPathAndFileName(logDirectoryPath, logFileName);

		}

		public void Log(LogMessage logMessage)
		{
			if (String.IsNullOrEmpty(logMessage.Message))
				throw new ArgumentException("Message is null or empty;");

			string formattedMessage = logMessageFormatter.FormatLogMessage(logMessage);

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
