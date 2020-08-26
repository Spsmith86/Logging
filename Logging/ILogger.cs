using System;

namespace Logging
{
	public interface ILogger
	{
		public void LogDebug(LogMessage message);
	}
}
