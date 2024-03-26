using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_COFFEE_WPF2.DAO
{
	

	public class AccountDAO
	{
		private static AccountDAO instance;
		public static AccountDAO Instance
		{
			get
			{
				if (instance == null)
					instance = new AccountDAO();
				return instance;
			}
			private set => instance = value;
		}
		public AccountDAO() { }

		public DataTable Login(string username, string password)
		{
			string query = $"exec TM_USER_Get_All '{username}','{password}'";
			DataTable dt = DataProvider.Instance.ExecuteQuery(query);
			return dt;
		}
	}
}
