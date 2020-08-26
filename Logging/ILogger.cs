using System;

namespace Logging
{
	public interface ILogger
	{
		public void LogDebug(LogMessage logMessage);
		public void LogInformation(LogMessage logMessage);
		public void LogWarning(LogMessage logMessage);
		public void LogError(LogMessage logMessage);
	}
}
