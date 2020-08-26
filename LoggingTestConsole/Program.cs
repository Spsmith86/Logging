using Logging;
using System;

namespace LoggingTestConsole
{
	class Program
	{
		static void Main(string[] args)
		{
			string directory = "C:/LoggerTest/";
			string filenameAddendum = "MM-dd-yyyy";
			string filename = $"LogFile-{System.DateTime.Now.ToString(filenameAddendum)}.log";
			IFileSystem fileSystem = new FileSystem();
			ILogMessageFormatter logMessageFormatter = new DefaultLogMessageFormatter();
			ILogger logger = new FileSystemLogger(fileSystem, logMessageFormatter, directory, filename);

			LogMessage logMessage = new LogMessage(LogLevel.DEBUG, "Test message 1.");
			logger.Log(logMessage);

			logMessage = new LogMessage(LogLevel.INFORMATION, "Test message 2.");
			logger.Log(logMessage);

			logMessage = new LogMessage(LogLevel.WARNING, "Test message 3.");
			logger.Log(logMessage);

			logMessage = new LogMessage(LogLevel.ERROR, "Test message 4.");
			logger.Log(logMessage);
		}
	}
}
