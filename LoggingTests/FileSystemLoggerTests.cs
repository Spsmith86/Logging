using Logging;
using Moq;
using System;
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
	}
}
