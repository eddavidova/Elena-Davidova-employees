using SirmaAppEmployees.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SirmaAppEmployees.Interfaces
{
    internal interface IProjectAssignementsService
    {
        List<TeamInfo> GetTeamMembersOverlaps();

        Result Validate();
    }
}
