﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_COFFEE_WPF2.DAO
{
	public class DataProvider
	{
		private static DataProvider instance;
		public static DataProvider Instance
		{
			get
			{
				if (instance == null)
					instance = new DataProvider();
				return instance;
			}
			private set => instance = value;
		}

		private DataProvider() { }
		private string connectionSTR = @"Data Source=.\;Initial Catalog=QL_Quan_Coffee;Integrated Security=True";  //;Trust Server Certificate=True
		public DataTable ExecuteQuery(string query, object[] parameters = null)
		{
			DataTable data = new DataTable();
			using (SqlConnection connection = new SqlConnection(connectionSTR))
			{
				SqlCommand cmd = new SqlCommand(query, connection);

				if (parameters != null)
				{
					string[] listPara = query.Split(' ');
					int i = 0;
					foreach (string item in listPara)
					{
						if (item.Contains('@'))
						{
							cmd.Parameters.AddWithValue(item, parameters[i]);
							i++;
						}
					}
				}

				SqlDataAdapter adapter = new SqlDataAdapter(cmd);

				adapter.Fill(data);
			}

			return data;
		}

		public int ExecuteNonQuery(string query, object[] parameters = null)
		{
			int data = 0;

			using (SqlConnection connection = new SqlConnection(connectionSTR))
			{
				SqlCommand cmd = new SqlCommand(query, connection);

				if (parameters != null)
				{
					string[] listPara = query.Split(' ');
					int i = 0;
					foreach (string item in listPara)
					{
						if (item.Contains('@'))
						{
							cmd.Parameters.AddWithValue(item, parameters[i]);
							i++;
						}
					}
				}
				data = cmd.ExecuteNonQuery();
			}
			return data;
		}
	}
}
