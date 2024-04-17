using DevExpress.ClipboardSource.SpreadsheetML;
using QL_COFFEE_WPF2.DAO;
using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QL_COFFEE_WPF2
{
	/// <summary>
	/// Interaction logic for PhucVu.xaml
	/// </summary>
	public partial class PhucVu : System.Windows.Controls.UserControl
	{
		public PhucVu()
		{
			InitializeComponent();
			Load();
		}
		void Load()
		{
			
			Load_Cbo_Area();
		}
		
		void Load_Cbo_Area()
		{
			DataTable dataTable_Area = TM_AREA_DAO.Instance.Get_Area();
			cbo_Area.ItemsSource = dataTable_Area.DefaultView;
			cbo_Area.SelectedValuePath = "ID_Area";
			cbo_Area.DisplayMemberPath = "Area_Name";
			cbo_Area.SelectedIndex = 0;
		}
		//Khi chọn combobox thì sẽ load các bàn thuộc khu vực đó
		private void cbo_Area_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (!string.IsNullOrEmpty(cbo_Area.SelectedValue.ToString()))
			{
				if (int.TryParse(cbo_Area.SelectedValue.ToString(), out int area))
				{
					DataTable dataTable_GetTable = TM_TABLE_DAO.Instance.Get_Table(area);
					dgv_Table.ItemsSource = dataTable_GetTable?.DefaultView;
					lv_Food.ItemsSource = dataTable_GetTable?.DefaultView;
				}
			}
		}

		private void dgv_Table_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			var dataGrid = sender as DataGrid;
			if (dataGrid == null || dataGrid.SelectedItems.Count == 0)
			{
				return;
			}

			//var selectRow = dataGrid.SelectedItems;
			//var rowIndex = dataGrid.Items.IndexOf(selectRow);

		}
	}
}
