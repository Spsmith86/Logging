using System;

namespace Logging
{
	public interface ILogger
	{
		public void Log(LogMessage logMessage);
	}
}
