using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Logging
{
	public class FileSystem : IFileSystem
	{
		public string CombineDirectoryPathAndFileName(string directoryPath, string fileName)
		{
			return Path.Combine(directoryPath, fileName);
		}

		public bool DirectoryExists(string directoryPath)
		{
			return Directory.Exists(directoryPath);
		}

		public void WriteToFile(string filePath, string value, bool append)
		{
			using (StreamWriter writer = new StreamWriter(filePath, append))
			{
				writer.WriteLine(value);
			}
		}
	}
}
