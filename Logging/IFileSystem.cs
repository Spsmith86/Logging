using System;
using System.Collections.Generic;
using System.Text;

namespace Logging
{
	public interface IFileSystem
	{
		public bool DirectoryExists(string directoryPath);
		public void WriteToFile(string filePath, string value, bool append);
		public string CombineDirectoryPathAndFileName(string directoryPath, string fileName);
	}
}
