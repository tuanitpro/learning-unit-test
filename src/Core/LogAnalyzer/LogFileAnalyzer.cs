using System;

namespace Core
{
    public class LogFileAnalyzer
    {
        public bool IsValidLogFileName(string fileName)
        {
            IExtensionManager extensionManager = new FileExtensionManager();
            return extensionManager.IsValid(fileName);
        }
    }
}