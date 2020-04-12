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
    public partial class OrderFood : Form
    {
        public OrderFood()
        {
            InitializeComponent();
        }

        private void OrderFood_Load(object sender, EventArgs e)
        {
           
            this.foodTableAdapter.Fill(this.movieDataSet1.food);
            using (SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\rahul\Desktop\MovieBookingSystemCSharp\MovieBookingSystemCSharp\movie.mdf;Integrated Security=True"))
            {

                string str2 = "SELECT * FROM food";
                SqlCommand cmd2 = new SqlCommand(str2, con1);
                SqlDataAdapter da = new SqlDataAdapter(cmd2);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = new BindingSource(dt, null);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            //TextBox2.Text = "";
            ComboBox1.Text = "--Select--";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\rahul\Desktop\MovieBookingSystemCSharp\MovieBookingSystemCSharp\movie.mdf;Integrated Security=True");
            con.Open();

            try
            {
                int amount;
                if (ComboBox1.Text.Equals("Drinks")) amount = 35;
                else amount = 50;
                string str = "INSERT INTO food(type,f_name,amnt) VALUES('" + ComboBox1.Text + "','" + textBox1.Text + "','" + amount  + "'); ";

                SqlCommand cmd = new SqlCommand(str, con);
                cmd.ExecuteNonQuery();

               

                string str1 = "select max(Id) from food;";

                SqlCommand cmd1 = new SqlCommand(str1, con);
                SqlDataReader dr = cmd1.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show(" Reach Food As Soon..");
                    using (SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\rahul\Desktop\MovieBookingSystemCSharp\MovieBookingSystemCSharp\movie.mdf;Integrated Security=True"))
                    {

                        string str2 = "SELECT * FROM food";
                        SqlCommand cmd2 = new SqlCommand(str2, con1);
                        SqlDataAdapter da = new SqlDataAdapter(cmd2);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridView1.DataSource = new BindingSource(dt, null);
                    }

                }
            }
            catch (SqlException excep)
            {
                MessageBox.Show(excep.Message);
            }
            con.Close();
            this.Hide();
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
