using QL_COFFEE_WPF2.DAO;
using System.Data;
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

namespace QL_COFFEE_WPF2
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public static string userName;
		public static string userID;
		public static string pass;
		public MainWindow()
		{
			InitializeComponent();
			Load();
		}
		void Load()
		{
			txt_UserID.Focus();
		}
		private void btn_Login_Click(object sender, RoutedEventArgs e)
		{
			DataTable dt = AccountDAO.Instance.Login(txt_UserID.Text, txt_Password.Text);
			if(dt.Rows.Count>0)
			{
				userID = dt.Rows[0]["UserID"].ToString();
				userName = dt.Rows[0]["UserName"].ToString();
				pass = dt.Rows[0]["Pass"].ToString();
				
				Narbar narbar= new Narbar();
				narbar.Show();
				System.Windows.Application.Current.MainWindow.Hide();

			}
		}
	}
}