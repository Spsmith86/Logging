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
			ILogger logger = new FileSystemLogger(directory, filename);
			LogMessage logMessage = new LogMessage("Test message 1.");
			logger.LogDebug(logMessage);
		}
	}
}
