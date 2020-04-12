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
    public partial class BookMovie : Form
    {
        string ticket_price;
        public BookMovie()
        {
            InitializeComponent();
        }

        private void BookMovie_Load(object sender, EventArgs e)
        {
         
            this.moviesTableAdapter.Fill(this.movieDataSet.movies);
            using (SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\rahul\Desktop\MovieBookingSystemCSharp\MovieBookingSystemCSharp\movie.mdf;Integrated Security=True"))
            {

                string str2 = "SELECT * FROM movies";
                SqlCommand cmd2 = new SqlCommand(str2, con1);
                SqlDataAdapter da = new SqlDataAdapter(cmd2);
                DataTable dt = new DataTable();
                da.Fill(dt);
                textBox1.Text = dt.Rows[dt.Rows.Count - 1][0].ToString();
                dataGridView1.DataSource = new BindingSource(dt, null);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\rahul\Desktop\MovieBookingSystemCSharp\MovieBookingSystemCSharp\movie.mdf;Integrated Security=True");
            con.Open();

            try
            {
                int amount = 200 * int.Parse(TextBox2.Text);
                string str = " Update movies set no_tick='" + TextBox2.Text + "',s_type='" + ComboBox1.Text  + "',s_no='" + TextBox3.Text + "', amnt='"+ amount +"' where id='" + textBox1.Text + "'";

                SqlCommand cmd = new SqlCommand(str, con);
                cmd.ExecuteNonQuery();

                string str1 = "select max(id) from movies;";

                SqlCommand cmd1 = new SqlCommand(str1, con);
                SqlDataReader dr = cmd1.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("Book Movie Successfully.. ", "Important Message");
                    textBox1.Text = "";
                    TextBox2.Text = "";
                    TextBox3.Text = "";
   
                    ComboBox1.Text = "--Select--";


                    using (SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\rahul\Desktop\MovieBookingSystemCSharp\MovieBookingSystemCSharp\movie.mdf;Integrated Security=True"))
                    {

                        string str2 = "SELECT * FROM movies";
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
            Payment p = new Payment();
            p.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
           
            ComboBox1.Text = "--Select--";      

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
