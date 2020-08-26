# Simple Logger
A simple logging library that provides several interfaces and classes for logging in C#.

## Getting Started
Here is a breakdown of the current interfaces and classes:
### Interfaces
* ILogger - The main interface for the logging functionality. It provides a single method, Log, which takes a LoggingMessage parameter.
* ILogMessageFormatter - This interface provides a method FormatLogMessage, which takes a LogMessage parameter and returns the information in the LogMessage as a formatted string.
* IFileSystem - This interface serves as an abstraction for system IO, so unit tests can mock accessing the file system.

### Classes
* FileSystemLogger - Concrete implemetation of ILogger above. It's constructor takes an instance of IFileSystem and ILogMessageFormatter, which are used for system IO and formatting the log message into a string, respectively. The constructor also takes the directory path where the log files will be stored, as well as the desired filename for the log file. When the Log method is invoked, the provided LogMessage is formatted and saved to the desired file.
* DefaultLogMessageFormatter - Concrete implementation of ILogMessageFormatter above. It formats LogMessages in the following way: DateTime - LogLevel - EventId - Message.
* FileSystem - Concrete implementation of IFileSystem above. It uses methods from System.IO to access the file system.
* LogMessage - A class to hold the data related to each log message. It requires the LogLevel and the message to be logged. Optionally, it can be provided a datetime for the logged event. If it's not specified, it uses DateTime.Now when the LogMessage is created. Similarly, it can be provided an Event Id, which is a Guid. This allows a single Id to be associated with multiple logged messages. If no Event Id is provided, a new one is created when the LogMessage is created.

### Enums
* LogLevel - This enum allows logged messages to be given a specific level, such as Debug, Information, etc.

## Basic Usage
Here is some example code for setting up the ILogger:
    
    string directory = "C:/LoggerTest/";
    string filename = "LogFile.log";
    IFileSystem fileSystem = new FileSystem();
    ILogMessageFormatter logMessageFormatter = new DefaultLogMessageFormatter();
    ILogger logger = new FileSystemLogger(fileSystem, logMessageFormatter, directory, filename);

Once the ILogger instance is created, you can log messages in the following way:

    LogMessage logMessage = new LogMessage(LogLevel.DEBUG, "Test message 1.");
	logger.Log(logMessage);

	logMessage = new LogMessage(LogLevel.INFORMATION, "Test message 2.");
	logger.Log(logMessage);

## Unit Tests
The LoggingTests project provides a set of xUnit tests for the FileSystemLogger implementation. More tests can/should be added for FileSystem and DefaultLogMessageFormatter.