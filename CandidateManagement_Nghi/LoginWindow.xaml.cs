using Candidate_BusinessObject;
using Candidate_Services;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CandidateManagement_Nghi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private IHrAccountService ihrAccountService;
        public LoginWindow()
        {
            InitializeComponent();
            ihrAccountService = new HrAccountService();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Hraccount hraccount = ihrAccountService.GetHraccountByEmail(txtEmail.Text.Trim());

            if (hraccount != null && txtPassword.Password.Equals(hraccount.Password))
            {
                Application.Current.Properties["account"] = hraccount;

                this.Hide();
                HomePageWindow hp = new HomePageWindow();
                hp.Show();
                

            }
            else
            {

                MessageBox.Show("Sorry");
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}