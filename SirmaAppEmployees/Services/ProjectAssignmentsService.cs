using SirmaAppEmployees.Interfaces;
using SirmaAppEmployees.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace SirmaAppEmployees
{
    internal class ProjectAssignmentsService: IProjectAssignementsService
    {
        IList<EmployeeAssignment> _inputData;
        ILogger _logger;
        public ProjectAssignmentsService(IList<EmployeeAssignment> inputData, ILogger logger)
        {
            _inputData = inputData;
            _logger = logger;
        }

        private Dictionary<string, int> ConstructProjectAssignementsWithDuration()
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            for (int i = 0; i < _inputData.Count; i++)
            {
                var assignment1 = _inputData[i];
                for (int j = i + 1; j < _inputData.Count; j++)
                {
                    var assignment2 = _inputData[j];
                    if (assignment1.EmployeeID != assignment2.EmployeeID && assignment1.ProjectID == assignment2.ProjectID)
                    {
                        var projID = assignment1.ProjectID;
                        DateTime overlapStart = assignment1.DateFrom > assignment2.DateFrom ? assignment1.DateFrom : assignment2.DateFrom;
                        DateTime overlapEnd = assignment1.DateTo < assignment2.DateTo ? assignment1.DateTo : assignment2.DateTo;

                        if (overlapStart <= overlapEnd)
                        {
                            //nevermind which is the first and which second employee
                            string emplKey1 = string.Format(Constants.KeyFormat, projID, assignment1.EmployeeID, assignment2.EmployeeID);
                            string emplKey2 = string.Format(Constants.KeyFormat, projID, assignment2.EmployeeID, assignment1.EmployeeID);
                            int days = (int)(overlapEnd - overlapStart).TotalDays;

                            if (!dictionary.ContainsKey(emplKey1) && !dictionary.ContainsKey(emplKey2))
                            {
                                dictionary.Add(emplKey1, days);
                            }
                            else if (dictionary.ContainsKey(emplKey1))
                            {
                                dictionary[emplKey1] += days;
                            }

                        }
                    }
                }
            }

            return dictionary;
        }

        private List<TeamInfo> GetTeamsOrderedByLongestOverlapPeriod(Dictionary<string, int> dictionary)
        {
            List<TeamInfo> teamMetrics = new List<TeamInfo>();
            foreach (KeyValuePair<string, int> pair in dictionary)
            {
                var key = pair.Key;
                Match match = Regex.Match(key, Constants.KeyFormatPattern);
                if (match.Success)
                {
                    //construct the employeeIDs and project id from key
                    int projID = Int32.Parse(match.Groups[1].Value);
                    int emplFirst = Int32.Parse(match.Groups[2].Value);
                    int emplSecond = Int32.Parse(match.Groups[3].Value);
                    teamMetrics.Add(new TeamInfo(projID, emplFirst, emplSecond, pair.Value)) ;
                }
            }

            return teamMetrics.OrderByDescending(x => x.OverlappingDays).ToList();
        }

        public List<TeamInfo> GetTeamMembersOverlaps()
        {
            Dictionary<string, int> dictionary = ConstructProjectAssignementsWithDuration();
            return GetTeamsOrderedByLongestOverlapPeriod(dictionary);
        }

        public Result Validate()
        {
            Result res = new Result();
            //validate
            if (_inputData.IsNullOrEmpty())
            {
                res.Status = Status.Warn;
                res.Message = "No employee assignment data was read from CSV!";
            }
            return res;
        }
    }
}
