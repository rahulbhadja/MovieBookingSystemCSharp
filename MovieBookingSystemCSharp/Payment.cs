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
    public partial class Payment : Form
    {
        public Payment()
        {
            InitializeComponent();
        }

        private void Payment_Load(object sender, EventArgs e)
        {
           
            this.payTableAdapter.Fill(this.movieDataSet2.pay);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\rahul\Desktop\MovieBookingSystemCSharp\MovieBookingSystemCSharp\movie.mdf;Integrated Security=True");

            con.Open();
            if (textBox1.Text != "")
            {
                try
                {
                    string getCust = "select m_name,no_tick,amnt from movies where id=" + Convert.ToInt32(textBox1.Text) + " ;";

                    SqlCommand cmd = new SqlCommand(getCust, con);
                    SqlDataReader dr;
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        TextBox2.Text = dr.GetValue(0).ToString();
                        TextBox3.Text = dr.GetValue(1).ToString();
                        int a = int.Parse(TextBox3.Text);
                        TextBox4.Text = (a * 200) + "";
                    }
                }
                catch (SqlException excep)
                {
//                    MessageBox.Show(excep.Message);
                }
                con.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\rahul\Desktop\MovieBookingSystemCSharp\MovieBookingSystemCSharp\movie.mdf;Integrated Security=True");
            con.Open();

            try
            {
                string str = "INSERT INTO pay(id,m_name,no_tick,amnt,p_type) VALUES('"+textBox1.Text +"','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + ComboBox1.Text  + "'); ";

                SqlCommand cmd = new SqlCommand(str, con);
                cmd.ExecuteNonQuery();

               

                string str1 = "select max(Id) from pay;";

                SqlCommand cmd1 = new SqlCommand(str1, con);
                SqlDataReader dr = cmd1.ExecuteReader();
                if (dr.Read())
                {

                    MessageBox.Show(" You Paid Successfully,, Enjoy Movie. ");
                    using (SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\rahul\Desktop\MovieBookingSystemCSharp\MovieBookingSystemCSharp\movie.mdf;Integrated Security=True"))
                    {

                        string str2 = "SELECT * FROM pay";
                        SqlCommand cmd2 = new SqlCommand(str2, con1);
                        SqlDataAdapter da = new SqlDataAdapter(cmd2);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
           
                    }
                }
            }
            catch (SqlException excep)
            {
                MessageBox.Show(excep.Message);
            }
            con.Close();
        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void PrintPreviewDialog1(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bmp, 0, 0);

        }
        Bitmap bmp;

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Graphics g = this.CreateGraphics();
            bmp = new Bitmap(this.Size.Width, this.Size.Height, g);
            Graphics mg = Graphics.FromImage(bmp);
            mg.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, this.Size);
            printPreviewDialog1.ShowDialog();
        }
    }
}