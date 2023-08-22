using SirmaAppEmployees.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SirmaAppEmployees.Interfaces
{
    internal interface ICSVLoaderService
    {
        Result Validate();

        IList<EmployeeAssignment> LoadInputData();
    }
}
