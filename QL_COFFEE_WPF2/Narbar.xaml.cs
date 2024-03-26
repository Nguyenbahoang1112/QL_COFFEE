using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace QL_COFFEE_WPF2
{
    /// <summary>
    /// Interaction logic for Narbar.xaml
    /// </summary>
    public partial class Narbar : Window
    {
        public Narbar()
        {
            InitializeComponent();
        }
		private PhucVu phucVuInstance;
		private void btn_PhucVu_Click(object sender, RoutedEventArgs e)
		{

			//PhucVu phucVu = new PhucVu();
			//if (!pnl_Main.Children.Contains(phucVu))
			//	pnl_Main.Children.Add(phucVu);
			//phucVu.Show();


			// Kiểm tra xem phucVuInstance đã được khởi tạo chưa
			if (phucVuInstance == null)
			{
				// Nếu chưa, khởi tạo phucVuInstance và thêm vào Panel
				phucVuInstance = new PhucVu();
				pnl_Main.Children.Add(phucVuInstance);
			}
			else
			{
				// Nếu đã tồn tại, không thêm vào Panel nữa
			}
		}
	}
}
