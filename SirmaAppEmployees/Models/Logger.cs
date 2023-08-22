using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SirmaAppEmployees.Interfaces;

namespace SirmaAppEmployees
{    
    internal class FileLogger: ILogger
    {
        string _logFile;
        public FileLogger(string logFile)
        {
            _logFile = logFile;
            if (!File.Exists(_logFile))
            {
                File.Create(_logFile);
            }
        }

        public void LogInfo(string message)
        {
            Log($"info: {message}");
        }

        public void LogError(Exception ex)
        {
            Log($"Error: {ex.Message}");
        }

        public void LogError(string message, Exception ex)
        {
            Log($"Error: {message} => {ex.ToString()}");
        }
        public void LogWarning(string message)
        {
            Log($"Warning: {message}");
        }

        private void Log(string message)
        {
            string line = $"{Environment.NewLine}{DateTime.Now} - {message}{Environment.NewLine}";
            try
            {
                using (StreamWriter writer = File.AppendText(_logFile))
                {
                    writer.WriteLine(line);
                }
            }
            catch 
            {

            }
        }

        
    }


}
