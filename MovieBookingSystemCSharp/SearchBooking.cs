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
    public partial class SearchBooking : Form
    {
        public SearchBooking()
        {
            InitializeComponent();
        }

        private void SearchBooking_Load(object sender, EventArgs e)
        {
            
       //     this.moviesTableAdapter.Fill(this.movieDataSet3.movies);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\rahul\Desktop\MovieBookingSystemCSharp\MovieBookingSystemCSharp\movie.mdf;Integrated Security=True"))
            {

                string str2 = "SELECT * FROM movies where id='"+textBox1.Text +"'";
                SqlCommand cmd2 = new SqlCommand(str2, con1);
                SqlDataAdapter da = new SqlDataAdapter(cmd2);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = new BindingSource(dt, null);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
