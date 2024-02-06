using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace WindowsFormsApp2
{
    public partial class BD : Form
    {
        private SqlConnection SqlConnection = null;
        public BD()
        {
            InitializeComponent();
        }

        private void BD_Load(object sender, EventArgs e)
        {
            SqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DataBase_1"].ConnectionString);

            SqlConnection.Open();
        }
    }
}
