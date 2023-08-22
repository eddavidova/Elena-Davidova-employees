using SirmaAppEmployees.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SirmaAppEmployees
{
    internal static class Program
    {
        static ILogger _logger;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            InitializeLogger();
            Application.ThreadException += OnApplicationThreadException;

            Application.Run(new frmMain(_logger));
        }

        private static void OnApplicationThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            _logger.LogError(e.Exception);
            MessageBox.Show(e.Exception.Message, Constants.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private static void InitializeLogger()
        {
            string logFileName = ConfigurationManager.AppSettings.Get("LogName");
            if (string.IsNullOrEmpty(logFileName))
            {
                logFileName = Constants.LogFileName;
            }
            _logger = new FileLogger(logFileName);
        }
    }
}
