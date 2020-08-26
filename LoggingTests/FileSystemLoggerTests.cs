using Logging;
using Moq;
using System;
using System.IO;
using Xunit;

namespace LoggingTests
{
	public class FileSystemLoggerTests
	{
		[Fact]
		public void Constructor_NoFileSystem_ThrowsArgumentException()
		{
			ILogMessageFormatter logMessageFormatter = new DefaultLogMessageFormatter();
			Assert.Throws<ArgumentException>(() => new FileSystemLogger(null, logMessageFormatter, "C:/Logs", "Log.log"));
		}

		[Fact]
		public void Constructor_NoLogMessageFormatter_ThrowsArgumentException()
		{
			Mock<IFileSystem> fileSystem = new Mock<IFileSystem>();
			Assert.Throws<ArgumentException>(() => new FileSystemLogger(fileSystem.Object, null, "C:/Logs", "Log.log"));
		}

		[Fact]
		public void Constructor_LogDirectoryDoesNotExist_ThrowsArgumentException()
		{
			Mock<IFileSystem> fileSystem = new Mock<IFileSystem>();
			fileSystem.Setup(e => e.DirectoryExists(It.IsAny<string>())).Returns(false);

			ILogMessageFormatter logMessageFormatter = new DefaultLogMessageFormatter();

			Assert.Throws<ArgumentException>(() => new FileSystemLogger(fileSystem.Object, logMessageFormatter, "C:/Logs", "Log.log"));
		}

		[Fact]
		public void Log_NoMessage_ThrowsArgumentException()
		{
			Mock<IFileSystem> fileSystem = new Mock<IFileSystem>();
			fileSystem.Setup(e => e.DirectoryExists(It.IsAny<string>())).Returns(true);

			ILogMessageFormatter logMessageFormatter = new DefaultLogMessageFormatter();
			ILogger logger = new FileSystemLogger(fileSystem.Object, logMessageFormatter, "C:/Logs", "Log.log");
			LogMessage logMessage = new LogMessage(LogLevel.DEBUG, String.Empty);

			Assert.Throws<ArgumentException>(() => logger.Log(logMessage));
		}

		[Fact]
		public void Log_CallsWriteToFile()
		{
			string directoryPath = "C:/Logs";
			string fileName = "Log.log";
			string combined = Path.Combine(directoryPath, fileName);
			Mock<IFileSystem> fileSystem = new Mock<IFileSystem>();
			fileSystem.Setup(e => e.DirectoryExists(It.IsAny<string>())).Returns(true);
			fileSystem.Setup(e => e.WriteToFile(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>()));
			fileSystem.Setup(e => e.CombineDirectoryPathAndFileName(directoryPath, fileName)).Returns(combined);

			ILogMessageFormatter logMessageFormatter = new DefaultLogMessageFormatter();
			ILogger logger = new FileSystemLogger(fileSystem.Object, logMessageFormatter, directoryPath, fileName);
			LogMessage logMessage = new LogMessage(LogLevel.DEBUG, "Some Message", DateTime.Now, Guid.NewGuid());

			logger.Log(logMessage);

			string formattedMessage = logMessageFormatter.FormatLogMessage(logMessage);
			fileSystem.Verify(mock => mock.WriteToFile(combined, formattedMessage, true), Times.Once());
		}
	}
}
