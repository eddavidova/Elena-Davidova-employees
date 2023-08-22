using SirmaAppEmployees.Interfaces;
using SirmaAppEmployees.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SirmaAppEmployees
{
    public partial class frmMain : Form
    {
        ILogger _logger;
        public frmMain(ILogger logger)
        {
            InitializeComponent();
            _logger = logger;
        }

        

        private void OnBrowseClick(object sender, EventArgs e)
        {
            var file = BrowseInputFile();            

            var csvLoader = new CSVLoaderService(file, _logger);
            var fileValidation = csvLoader.Validate();
            if (fileValidation.Status == Status.OK)
            {
                var data = csvLoader.LoadInputData();
                var assignmentManager = new ProjectAssignmentsService(data, _logger);
                var assignmentsValidation = assignmentManager.Validate();
                if (assignmentsValidation.Status == Status.OK)
                {
                    var res = assignmentManager.GetTeamMembersOverlaps();
                    if (res.IsNullOrEmpty())
                    {
                        MessageBox.Show("No overlapping periods found for project members!", Constants.Caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        ClearCurrentData();
                    }
                    grdResult.AutoGenerateColumns = false;
                    grdResult.DataSource = res;
                }
                else
                {
                    MessageBox.Show(assignmentsValidation.Message, Constants.Caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ClearCurrentData();
                }
            }
            else
            {
                MessageBox.Show(fileValidation.Message, Constants.Caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ClearCurrentData();
            }
        }

        private void ClearCurrentData()
        {
            grdResult.DataSource = null;
        }

        private string BrowseInputFile()
        {
            string file = string.Empty;
            using (OpenFileDialog ofdBrowse = new OpenFileDialog())
            {
                ofdBrowse.Title = Constants.Ofd_Title;
                ofdBrowse.Filter = Constants.Ofd_Filter;
                ofdBrowse.Multiselect = false;

                DialogResult result = ofdBrowse.ShowDialog();
                if (result == DialogResult.OK)
                {
                    file = ofdBrowse.FileName;                    
                }
            }
            txtFile.Text = file;
            return file;
        }

        
    }
}
