using Candidate_BusinessObject;
using Candidate_Services;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
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
    /// Interaction logic for CandidateProfileWindow.xaml
    /// </summary>
    public partial class CandidateProfileWindow : Window
    {
        private readonly ICandidateProfileService profileService;
        private readonly IJobPostingService jobPostingService;
        private readonly int? roleID;
        public CandidateProfileWindow()
        {
            InitializeComponent();
            this.profileService = new CandidateProfileService();
            this.jobPostingService = new JobPostingService();
        }
        public CandidateProfileWindow(int? roleID)
        {
            InitializeComponent();
            this.profileService = new CandidateProfileService();
            this.jobPostingService = new JobPostingService();
            this.roleID = roleID;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            switch (roleID)
            {
                case 1:
                    break;
                case 2:
                    //staff
                    this.btAdd.IsEnabled = false;
                    this.btnDelete.IsEnabled = false;
                    this.btnUpdate.IsEnabled = false;
                    break;
                case 3:
                    break;
                default:
                    this.Close();
                    break;

            }
            this.LoadGrid(0);
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {

            if (this.txtCandidateID.Text.Length < 0 ||
            this.txtDescription.Text.Length < 0 ||
            this.txtFullName.Text.Length < 0 ||
            this.cmbPostID.SelectedValue == null ||
            this.txtImage.Text.Length < 0 ||
            this.dpBirthday.SelectedDate == null)
            {
                MessageBox.Show("All field is required");
                return;
            }
            
            CandidateProfile candidate = new CandidateProfile();
            candidate.CandidateId = txtCandidateID.Text;
            candidate.Fullname = txtFullName.Text;
            candidate.ProfileUrl = txtImage.Text;
            candidate.ProfileShortDescription = txtDescription.Text;
            candidate.Birthday = dpBirthday.SelectedDate;
            candidate.PostingId = cmbPostID.SelectedValue.ToString();
            bool result = profileService.updateProfile(candidate);
            if (result)
            {
                MessageBox.Show("Update success");
            }
            else { MessageBox.Show("Failed"); }

            LoadGrid(0);
            resetInput();
        }
        private void LoadGrid(int pageNum)
        {
            // hiển thị danh sách và tính số danh sách cần bỏ qua
            List<CandidateProfile> can = profileService.cadidateList()
                .Skip((pageNum) * 3).Take(3).ToList();
            this.tblPage.Text = (pageNum + 1).ToString();
            this.dtgView.ItemsSource = can.Select(a => new
            {
                a.CandidateId,
                a.Fullname,
                a.Birthday,
                a.ProfileShortDescription,
                a.ProfileUrl,
                a.PostingId,
                a.Posting.JobPostingTitle
            });
            this.cmbPostID.ItemsSource = jobPostingService.GetJobPostings();
            this.cmbPostID.DisplayMemberPath = "JobPostingTitle";
            this.cmbPostID.SelectedValuePath = "PostingId";

        }

        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            if (this.txtCandidateID.Text.Trim().Length == 0||
                this.txtDescription.Text.Trim().Length == 0 ||
                this.txtFullName.Text.Trim().Length == 0 ||
                this.txtImage.Text.Trim().Length == 0 ||
                this.dpBirthday.SelectedDate == null)
            {
                MessageBox.Show("All field is required");
                return;
            }
            if (profileService.SearchCandidateByID(this.txtCandidateID.Text) != null)
            {
                MessageBox.Show("Candidate ID already exist");
                return;
            }

            CandidateProfile profile = new CandidateProfile();
            profile.CandidateId = txtCandidateID.Text;
            profile.Fullname = txtFullName.Text;
            profile.ProfileUrl = txtImage.Text;
            profile.PostingId = cmbPostID.SelectedValue.ToString();
            profile.ProfileShortDescription = txtDescription.Text;
            profile.Birthday = dpBirthday.SelectedDate;
            bool result = profileService.AddCandidate(profile);
            if (result)
            {
                MessageBox.Show("Add success");
                resetInput();
                LoadGrid(0);
            }
            else
            {
                MessageBox.Show("Something wrong!!!");
            }


        }

        private void dtgView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dataGrid = sender as DataGrid; // ép kiểu sender từ object sang datagrid 
            DataGridRow row =
                (DataGridRow)dataGrid.ItemContainerGenerator
                .ContainerFromIndex(dataGrid.SelectedIndex);
            if (row == null)
            {
                return;
            }
            // (selected index -> chỉ số của hàng đc chọn) -> dòng này hiển giá trị của hàng đc chọn
            DataGridCell? RowColumn =
                dataGrid.Columns[0].GetCellContent(row).Parent as DataGridCell; // ?_ có thể null
            // ô đầu tiên trong hàng đã chọn
            string id = ((TextBlock)RowColumn.Content).Text;
            CandidateProfile candidate = profileService.SearchCandidateByID(id);
            txtCandidateID.Text = candidate.CandidateId;
            txtFullName.Text = candidate.Fullname;
            txtDescription.Text = candidate.ProfileShortDescription;
            txtImage.Text = candidate.ProfileUrl;
            dpBirthday.SelectedDate = candidate.Birthday;
            cmbPostID.SelectedValue = candidate.PostingId;


        }
        private void resetInput()
        {
            txtCandidateID.Text = "";
            txtDescription.Text = "";
            txtFullName.Text = "";
            txtImage.Text = "";
            dpBirthday.SelectedDate = null;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (profileService.RemoveCandidate(txtCandidateID.Text))
            {
                MessageBox.Show("Delete success");
                LoadGrid(0);
                resetInput();
            }
            else
            {
                MessageBox.Show("Delete failed");
            }


        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            int page = int.Parse(this.tblPage.Text) - 1;
            int pageTotal = 0;
            if (profileService.cadidateList().Count % 3 == 0)
            {
                pageTotal = profileService.cadidateList().Count / 3;
            }
            else
            {
                pageTotal = profileService.cadidateList().Count / 3 + 1;
            }
            if (page == pageTotal)
            {
                LoadGrid(pageTotal);
            }
            else
            {
                LoadGrid(page + 1);
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            int page = int.Parse(this.tblPage.Text) - 1;
            if (page == 0)
            {
                LoadGrid(0);
            }
            else
            {
                LoadGrid(page - 1);
            }

        }

        private void btnHomePage_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            HomePageWindow homePageWindow = new HomePageWindow();
            homePageWindow.Show();
        }
    }

}
