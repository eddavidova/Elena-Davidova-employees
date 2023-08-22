using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SirmaAppEmployees
{
    internal static class Constants
    {
        /// <summary>
        /// Default csv separator
        /// </summary>
        public const string DataSeparator = ",";
        public const string NullValue = "null";
        public const string KeyFormat = "{0}:{1}_{2}";
        public const string KeyFormatPattern = @"(\d+):(\d+)_(\d+)";
        public const string Ofd_Title = "Select a File";
        public const string Ofd_Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
        public const string LogFileName = "Log.txt";
        public const string Caption = "Sirma Employee Assignments";
        /// <summary>
        /// Date formats that are parsed. Other could be added here
        /// </summary>
        public static string[] DateFormatsToTry = new string[]
        {
            "yyyy-MM-dd",
            "MM/dd/yyyy",
            "dd-MMM-yyyy",
            "dd-MM-yyyy",
            "yyyy.MM.dd",
            "dd.MM.yyyy",
            "yyyyMMdd"
        };
    }
}
