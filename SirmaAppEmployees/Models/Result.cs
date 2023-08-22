using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SirmaAppEmployees.Models
{
    internal class Result
    {
        public Status Status { get; set; }

        public string Message { get; set; }
    }

    public enum Status
    {
        OK,
        Warn,
        Error
    }
}
