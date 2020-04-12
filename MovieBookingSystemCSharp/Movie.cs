using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MovieBookingSystemCSharp
{
    public partial class Movie : Form
    {
        public Movie()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\rahul\Desktop\MovieBookingSystemCSharp\MovieBookingSystemCSharp\movie.mdf;Integrated Security=True");
            con.Open();

            try
            {
                string str = "INSERT INTO movies(city,locat,m_name,time) VALUES('" + ComboBox1.Text  + "','" + ComboBox2.Text + "','" + ComboBox3.Text + "','" + ComboBox4.Text + "'); ";

                SqlCommand cmd = new SqlCommand(str, con);
                cmd.ExecuteNonQuery();

                

                string str1 = "select max(Id) from movies;";

                SqlCommand cmd1 = new SqlCommand(str1, con);
                SqlDataReader dr = cmd1.ExecuteReader();
                if (dr.Read())
                {
                    this.Visible = false;
                    BookMovie obj = new BookMovie();
                    obj.ShowDialog();
                }
            }
            catch (SqlException excep)
            {
                MessageBox.Show(excep.Message);
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ComboBox1.Text = "";
            ComboBox2.Text = "";
            ComboBox3.Text = "";
            ComboBox4.Text = "";
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
