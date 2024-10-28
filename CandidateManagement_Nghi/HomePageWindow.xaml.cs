using Candidate_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
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
    /// Interaction logic for HomePageWindow.xaml
    /// </summary>
    public partial class HomePageWindow : Window

    {
        private readonly Hraccount acc; 
        
        public HomePageWindow()
        {
            
            InitializeComponent();
            acc = Application.Current.Properties["account"] as Hraccount;
            if (acc.MemberRole == 1)
            {
                this.tblRole.Text = "ROLE ADMIN";
            }
            else if (acc.MemberRole == 2)
            {
                this.tblRole.Text = "ROLE MANAGER";
            }
            else if (acc.MemberRole == 3)
            {
                this.tblRole.Text = "ROLE STAFF";
            }
            
        }

        private void btnCandidate_Click(object sender, RoutedEventArgs e)
        {
            int? roleID = acc.MemberRole;
            switch (roleID)
            {
                case 1:
                    this.Hide();
                    CandidateProfileWindow candi = new CandidateProfileWindow(roleID);
                    candi.Show();
                    break;
                case 2:
                    this.Hide();
                    CandidateProfileWindow staff = new CandidateProfileWindow(roleID);
                    staff.Show();
                    break;
                case 3:
                    break;
                default:
                    break;
            }
        }

        private void btnJobPosting_Click(object sender, RoutedEventArgs e)
        {
            int? roleID = acc.MemberRole;
            switch (roleID)
            {
                case 1:
                    this.Hide();
                    JobPostingWindow candi = new JobPostingWindow(roleID);
                    candi.Show();
                    break;
                case 2:
                    this.Hide();
                    JobPostingWindow staff = new JobPostingWindow(roleID);
                    staff.Show();
                    break;
                case 3:
                    break;
                default:
                    break;
            }

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
        }
    }
}
