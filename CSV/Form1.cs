using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
            openCSV.Filter = "*csv filter(*.csv) | *.csv";
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

            tsBtnOpen.Click += tsBtnOpenClick;
            tscmbRegion.SelectedIndexChanged += tscmbRegionSelectedIndexChanged;
            tscmbJob.SelectedIndexChanged += tscmbJobSelectedIndexChanged;
            tstboxSearch.TextChanged += TstboxSearch_TextChanged;
        }

        private void TstboxSearch_TextChanged(object sender, EventArgs e)
        {
            UpdateTable();
        }


        private void tscmbJobSelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTable();
        }

        private void tscmbRegionSelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTable();
        }

        private void tsBtnOpenClick(object sender, EventArgs e)
        {
            OpenFile();
        }

        public void UpdateCombos()
        {
            tscmbJob.Items.Clear();
            tscmbRegion.Items.Clear();

            var regionsList = jobs.Select(jobItem => jobItem.Region).Distinct().OrderBy(x => x);
            var jobList = jobs.Select(jobItem => jobItem.JobName).Distinct().OrderBy(x => x);

            tscmbJob.Items.AddRange(jobList.ToArray());
            tscmbRegion.Items.AddRange(regionsList.ToArray());
        }

        public void UpdateTable()
        {
            var query = jobs.AsEnumerable(); 
            if (!tscmbRegion.Text.Equals(""))
            {
                query = query.Where(jobItem => jobItem.Region.Equals(tscmbRegion.Text));
            }

            if (!tscmbJob.Text.Equals(""))
            {
                query = query.Where(jobItem => jobItem.JobName.Equals(tscmbJob.Text));
            }

            query = query.Where(jobItem => jobItem.SalaryTotal >= tbSalary.Value);

            if (!tstboxSearch.Text.Equals(""))
            {
                query = query.Where(jobItem => jobItem.JobName.ToLower().Contains(tstboxSearch.Text.ToLower()) ||
                jobItem.Industry.ToLower().Contains(tstboxSearch.Text.ToLower()) || 
                jobItem.SalaryTotal.ToString().Contains(tstboxSearch.Text) ||
                jobItem.Region.ToLower().Contains(tstboxSearch.Text.ToLower()));

            }
            jobGridView.DataSource = query.ToList();
        }

        public void UpdateTracks()
        {
            tbSalary.Minimum = (int)jobs.Select(jobItem => jobItem.SalaryTotal).Min();
            tbSalary.Maximum = (int)jobs.Select(jobItem => jobItem.SalaryTotal).Max();
            label1.Text = $"{tbSalary.Value}";
        }


        private void tbSalary_Scroll(object sender, EventArgs e)
        {
            label1.Text = $"{tbSalary.Value}";
            UpdateTable();
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
    }
}
