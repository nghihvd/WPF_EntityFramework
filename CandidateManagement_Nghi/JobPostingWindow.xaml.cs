using Candidate_BusinessObject;
using Candidate_Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CandidateManagement_Nghi
{
    /// <summary>
    /// Interaction logic for JobPostingWindow.xaml
    /// </summary>
    public partial class JobPostingWindow : Window
    {
        private readonly IJobPostingService jobPostingService;

        private readonly int? roleID;
        public JobPostingWindow()
        {
            InitializeComponent();
            jobPostingService = new JobPostingService();    
        }
        public JobPostingWindow(int? role)
        {
            InitializeComponent();
            jobPostingService = new JobPostingService();
            this.roleID = role;
            switch (role)
            {
                case 1:
                    break;
                case 2:
                    this.btnCreate.IsEnabled = false;
                    this.btnDelete.IsEnabled = false;
                    this.btnUpdate.IsEnabled = false;
                    break;
                case 3:
                    break;
                default:
                    break;
            }
        }
        

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.dgJobPosting.ItemsSource = jobPostingService.GetJobPostings();

        }
        
        private void LoadGrid()
        {
            this.dgJobPosting.ItemsSource = jobPostingService.GetJobPostings();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void dgJobPosting_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            DataGrid dataGrid = sender as DataGrid;
            DataGridRow row = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromItem(dataGrid.SelectedItem);
            if (row == null)
            {
                return;
            }
            DataGridCell? column = dataGrid.Columns[0].GetCellContent(row).Parent as DataGridCell;
            if(column == null || column.Content == null)
            {
                return;
            }
            string id = ((TextBlock)column.Content).Text;
            if(id == null || id.Trim().Length == 0)
            {
                resetInput();
                return;
            }
            JobPosting job = jobPostingService.GetJobPostingByID(id);
          
            this.txtDescription.Text = job.Description;
            this.txtJobPostingTittle.Text = job.JobPostingTitle;
            this.txtPostingID.Text = job.PostingId;
            this.dtPosting.SelectedDate = job.PostedDate;
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            if(this.txtDescription.Text == null ||
                this.txtJobPostingTittle.Text == null ||
                this.txtPostingID.Text == null ||
                this.dtPosting.SelectedDate == null)
            {
                MessageBox.Show("All field is required");
                return;
            }
           JobPosting job = new JobPosting();
            job.Description = this.txtDescription.Text;
            job.PostedDate = this.dtPosting.SelectedDate;
            job.JobPostingTitle = this.txtJobPostingTittle.Text;
            job.PostingId = this.txtPostingID.Text;
            bool result = jobPostingService.AddJobPosting(job);
            if (result)
            {
                MessageBox.Show("Added success");
                
            }
            else 
            {
                MessageBox.Show("ID already exist");
            }

            resetInput();
            LoadGrid();
        }

        private void resetInput()
        {
            this.txtDescription.Text = null;
            this.txtJobPostingTittle.Text = null;
            this.txtPostingID.Text = null;
            this.dtPosting.SelectedDate = null;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            string id = this.txtPostingID.Text;
            bool result = jobPostingService.DeleteJobPosting(id);
            if (result)
            {
                MessageBox.Show("Delete success");
            }
            else
            {
                MessageBox.Show("Cannot delete this job posting");
            }
            LoadGrid();
            resetInput();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (this.txtDescription.Text == null ||
                this.txtJobPostingTittle.Text == null ||
                this.txtPostingID.Text == null ||
                this.dtPosting.SelectedDate == null)
            {
                MessageBox.Show("All field is required");
                return;
            }
            
            JobPosting job = new JobPosting();
            job.PostingId = this.txtPostingID.Text; 
            job.Description = this.txtDescription.Text;
            job.PostedDate = this.dtPosting.SelectedDate;
            job.JobPostingTitle = this.txtJobPostingTittle.Text;
            bool result = jobPostingService.UpdateJobposting(job);
            if (result) 
            {
                MessageBox.Show("Update success");
            }
            else
            {
                MessageBox.Show("Cannot find ID");
            }
            resetInput();
            LoadGrid();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            HomePageWindow homePageWindow = new HomePageWindow();   
            homePageWindow.Show();
        }
    }
}
