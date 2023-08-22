using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SirmaAppEmployees
{
    internal class EmployeeAssignment
    {
        public int EmployeeID { get; private set; }

        public int ProjectID { get; private set; }

        public DateTime DateFrom { get; private set; }

        public DateTime DateTo { get; private set; }

        public EmployeeAssignment(int employeeID, int projectID, DateTime dateFrom, DateTime dateTo)
        {
            EmployeeID = employeeID;
            ProjectID = projectID;
            if (dateFrom > dateTo)
            {
                dateFrom = dateTo;
            }
            DateFrom = dateFrom;
            DateTo = dateTo;
        }
    }
}
