using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSV
{
    public partial class Form1 : Form
    {
        List<JobItems> jobs = new List<JobItems>();
        String fileName = @"C:\Users\Администратор\source\repos\CSV\007_Иркутская область.csv";
        public Form1()
        {
            InitializeComponent();
            try
            {
                jobs = JobItems.LoadFile(fileName);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                OpenFile();

            }
            jobGridView.DataSource = jobs;

            jobGridView.Columns["JobName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            jobGridView.Columns["JobName"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            jobGridView.Columns["Industry"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            jobGridView.Columns["Industry"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            jobGridView.Columns["SalaryTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            jobGridView.Columns["Region"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            jobGridView.RowTemplate.Height = 40;
            //jobGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            //jobGridView.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            UpdateCombos();
            UpdateTracks();
            UpdateTable();

            openCSV.Filter = "*csv filter(*.csv) | *.csv";
        }

        public void UpdateCombos()
        {
            cmbRegion.Items.Clear();
            cmbJob.Items.Clear();

            var regionsList = jobs.Select(jobItem => jobItem.Region).Distinct().OrderBy(x => x);
            var jobList = jobs.Select(jobItem => jobItem.JobName).Distinct().OrderBy(x => x);

            cmbRegion.Items.AddRange(regionsList.ToArray());
            cmbJob.Items.AddRange(jobList.ToArray());
        }

        public void UpdateTable()
        {
            var query = jobs.AsEnumerable(); 
            if (!cmbRegion.Text.Equals(""))
            {
                query = query.Where(jobItem => jobItem.Region.Equals(cmbRegion.Text));
            }

            if (!cmbJob.Text.Equals(""))
            {
                query = query.Where(jobItem => jobItem.JobName.Equals(cmbJob.Text));
            }

            query = query.Where(jobItem => jobItem.SalaryTotal >= tbSalary.Value);

            if (!tboxSearch.Text.Equals(""))
            {
                query = query.Where(jobItem => jobItem.JobName.ToLower().Equals(tboxSearch.Text.ToLower()) ||
                jobItem.Industry.ToLower().Equals(tboxSearch.Text.ToLower()) || 
                jobItem.SalaryTotal.ToString().Equals(tboxSearch.Text) ||
                jobItem.Region.ToLower().Equals(tboxSearch.Text.ToLower()));

            }
            jobGridView.DataSource = query.ToList();
        }

        public void UpdateTracks()
        {
            tbSalary.Minimum = (int)jobs.Select(jobItem => jobItem.SalaryTotal).Min();
            tbSalary.Maximum = (int)jobs.Select(jobItem => jobItem.SalaryTotal).Max();
            label1.Text = $"{tbSalary.Value}";
        }

        private void cmbRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTable();
        }

        private void tbSalary_Scroll(object sender, EventArgs e)
        {
            label1.Text = $"{tbSalary.Value}";
            UpdateTable();
        }

        private void btnOpenCSV_Click(object sender, EventArgs e)
        {
            OpenFile();
        }
        public void OpenFile()
        {
            if (openCSV.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            fileName = openCSV.FileName;
            jobs = JobItems.LoadFile(fileName);
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            UpdateTable();
        }
    }
}
