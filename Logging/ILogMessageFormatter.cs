using System;
using System.Collections.Generic;
using System.Text;

namespace Logging
{
	public interface ILogMessageFormatter
	{
		public string FormatLogMessage(LogMessage logMessage);
	}
}
