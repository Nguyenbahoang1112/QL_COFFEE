﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_COFFEE_WPF2.DAO
{
    public class TM_AREA_DAO
    {
        private static TM_AREA_DAO instance;
		public static TM_AREA_DAO Instance
		{
			get
			{
				if (instance == null)
					instance = new TM_AREA_DAO();
				return instance;
			}
			private set => instance = value;
		}
		private TM_AREA_DAO() { }
		public DataTable Get_Area()
		{
			string query = $"exec TM_AREA_Get_All";
			DataTable dataTable = DataProvider.Instance.ExecuteQuery(query);
			return dataTable;
		}

	}
}
