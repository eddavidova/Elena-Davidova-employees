using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace SirmaAppEmployees
{
    public class TeamInfo
    {
        public int FirstEmployee { get; private set; }

        public int SecondEmployee { get; private set; }

        public int ProjectID { get; private set; }
        
        public int OverlappingDays { get; private set; }

        public TeamInfo(int projID, int firstEmp, int secondEmpl, int days) { 
            ProjectID = projID;
            FirstEmployee = firstEmp;
            SecondEmployee = secondEmpl;
            OverlappingDays = days;
        }

    }
}
