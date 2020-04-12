using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieBookingSystemCSharp
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void bookMovieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Movie obj = new Movie();
            obj.Show();
        }

        private void paymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Payment obj2 = new Payment();
            obj2.ShowDialog();
            
        }

        private void orderFoodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OrderFood obj3 = new OrderFood();
            obj3.ShowDialog();
        }

        private void searchBookingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchBooking obj4 = new SearchBooking();
            obj4.ShowDialog();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
