using SirmaAppEmployees.Interfaces;
using SirmaAppEmployees.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SirmaAppEmployees
{
    internal class CSVLoaderService: ICSVLoaderService
    {
        string _fileName;
        ILogger _logger;
        public CSVLoaderService(string inputFile, ILogger logger) {
            _fileName = inputFile;
            _logger = logger;
        }

        public Result Validate()
        {
            Result result = new Result();
            
            if (string.IsNullOrEmpty(_fileName)){
                result.Status = Status.Warn;
                result.Message = $"Filename cannot be empty!";
                _logger.LogWarning(result.Message);
                return result;
            }
            FileInfo fileInfo = new FileInfo(_fileName);

            if (!fileInfo.Exists)
            {
                result.Status = Status.Warn;
                result.Message = $"File '{_fileName}' cannot be found!";
                _logger.LogWarning(result.Message);
            }
            else if (fileInfo.Length == 0)
            {
                result.Status = Status.Warn;
                result.Message = $"File '{_fileName}' is empty!";
                _logger.LogWarning(result.Message);
            }

            
            return result;
        }
        public IList<EmployeeAssignment> LoadInputData()
        {
            IList<EmployeeAssignment> employeeAssignments = new List<EmployeeAssignment>();
           
            using (StreamReader sr = new StreamReader(_fileName))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    var emplAssignment = ParseLine(line);
                    if (emplAssignment != null)
                    {
                        employeeAssignments.Add(emplAssignment);
                    }
                }
            }

            return employeeAssignments;
        }
        private EmployeeAssignment ParseLine(string line)
        {            
            //if line does not contain 3 separators....
            if (string.IsNullOrEmpty(line) || line.IndexOf(Constants.DataSeparator) < 0)
            {
                //skip the line
                _logger.LogWarning($"Line '{line}' is null or does not contain separators. It will be skipped!");
                return null;
            }

            string[] items = line.Split(new string[] {Constants.DataSeparator}, StringSplitOptions.RemoveEmptyEntries);

            EmployeeAssignment assignment;
            try
            {
                var emplID = Convert.ToInt32(items[0]);
                var projID = Convert.ToInt32(items[1]);
                var dateFrom = items[2].ParseDate();
                var dateTo = items[3].ParseDate();
                assignment = new EmployeeAssignment(emplID, projID, dateFrom, dateTo);
            }
            catch (Exception ex){
                _logger.LogError($"Line '{line}' cannot be parsed. It will be skipped!", ex);
                return null;
            }
            return assignment;
        }
    }
}
