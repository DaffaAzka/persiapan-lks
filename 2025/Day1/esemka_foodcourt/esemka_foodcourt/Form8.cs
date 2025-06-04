using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace esemka_foodcourt
{
    public partial class Form8: Form
    {
        EsemkaFoodcourtEntities model = new EsemkaFoodcourtEntities();

        public Form8()
        {
            InitializeComponent();
            load();
        }

        public void load()
        {


            DateTime selectedDate = dateTimePicker1.Value.Date; // Get only the date part
            var res = model.Reservations.ToList().Where(x => x.ReservationDate.Date == selectedDate);
            
            foreach (var item in res) {

                if (item.TableID == 1) { pictureBox1.Image = Properties.Resources.table_reserved; }
                else if (item.TableID == 2) { pictureBox2.Image = Properties.Resources.table_reserved; }
                else if (item.TableID == 3) { pictureBox3.Image = Properties.Resources.table_reserved; }
                else if (item.TableID == 4) { pictureBox4.Image = Properties.Resources.table_reserved; }
                else if (item.TableID == 5) { pictureBox5.Image = Properties.Resources.table_reserved; }
                else if (item.TableID == 6) { pictureBox6.Image = Properties.Resources.table_reserved; }
                else if (item.TableID == 7) { pictureBox7.Image = Properties.Resources.table_reserved; }
                else if (item.TableID == 8) { pictureBox8.Image = Properties.Resources.table_reserved; }
                else if (item.TableID == 9) { pictureBox9.Image = Properties.Resources.table_reserved; }
                else if (item.TableID == 10) { pictureBox10.Image = Properties.Resources.table_reserved; }
                else if (item.TableID == 11) { pictureBox11.Image = Properties.Resources.table_reserved; }
                else if (item.TableID == 12) { pictureBox12.Image = Properties.Resources.table_reserved; }

            }

            //pictureBox10.Image = Properties.Resources.table_reserved;

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form8_Load(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            load();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

            DateTime selectedDate = dateTimePicker1.Value.Date;
            Reservation r = model.Reservations.Where(x => x.TableID == 1).Where(x => x.ReservationDate == selectedDate).FirstOrDefault();

            if (r != null)
            {
                               
                textBox1.Text = r.CustomerFirstName + " " + r.CustomerLastName;
                textBox2.Text = r.CustomerEmail;
                textBox3.Text = r.CustomerPhoneNumber;

                getOrder(r);

            } else
            {
                MessageBox.Show("Found Clicked");
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (pictureBox2.Image.Equals(Properties.Resources.table_reserved))
            {
                DateTime selectedDate = dateTimePicker1.Value.Date;
                Reservation r = model.Reservations.Where(x => x.TableID == 2).Where(x => x.ReservationDate == selectedDate).FirstOrDefault();

                textBox1.Text = r.CustomerFirstName + " " + r.CustomerLastName;
                textBox2.Text = r.CustomerEmail;
                textBox3.Text = r.CustomerPhoneNumber;

            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (pictureBox3.Image.Equals(Properties.Resources.table_reserved))
            {
                DateTime selectedDate = dateTimePicker1.Value.Date;
                Reservation r = model.Reservations.Where(x => x.TableID == 3).Where(x => x.ReservationDate == selectedDate).FirstOrDefault();

                textBox1.Text = r.CustomerFirstName + " " + r.CustomerLastName;
                textBox2.Text = r.CustomerEmail;
                textBox3.Text = r.CustomerPhoneNumber;

            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (pictureBox4.Image.Equals(Properties.Resources.table_reserved))
            {
                DateTime selectedDate = dateTimePicker1.Value.Date;
                Reservation r = model.Reservations.Where(x => x.TableID == 4).Where(x => x.ReservationDate == selectedDate).FirstOrDefault();

                textBox1.Text = r.CustomerFirstName + " " + r.CustomerLastName;
                textBox2.Text = r.CustomerEmail;
                textBox3.Text = r.CustomerPhoneNumber;

            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (pictureBox5.Image.Equals(Properties.Resources.table_reserved))
            {
                DateTime selectedDate = dateTimePicker1.Value.Date;
                Reservation r = model.Reservations.Where(x => x.TableID == 5).Where(x => x.ReservationDate == selectedDate).FirstOrDefault();

                textBox1.Text = r.CustomerFirstName + " " + r.CustomerLastName;
                textBox2.Text = r.CustomerEmail;
                textBox3.Text = r.CustomerPhoneNumber;

            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (pictureBox6.Image.Equals(Properties.Resources.table_reserved))
            {
                DateTime selectedDate = dateTimePicker1.Value.Date;
                Reservation r = model.Reservations.Where(x => x.TableID == 6).Where(x => x.ReservationDate == selectedDate).FirstOrDefault();

                textBox1.Text = r.CustomerFirstName + " " + r.CustomerLastName;
                textBox2.Text = r.CustomerEmail;
                textBox3.Text = r.CustomerPhoneNumber;

            }
        }


        private void getOrder(Reservation reservation)
        {
            var dt = new DataTable();
            dt.Columns.Add("Menu", typeof(string));
            dt.Columns.Add("Qty", typeof(string));
            dt.Columns.Add("Price", typeof(string));
            dt.Columns.Add("Sub Total", typeof(string));

            var orders = model.ReservationDetails.Select(r => new
            {
                r.ReservationID,
                r.Qty,
                r.ID,
                menu = model.Menus.Where(x => x.ID == r.MenuID).FirstOrDefault(),
            }).Where(x => x.ReservationID == reservation.ID).ToList();

            foreach (var order in orders)
            {
                dt.Rows.Add(order.menu.Name, order.Qty, "Rp" + order.menu.Price, "Rp" + (order.Qty * order.menu.Price));

            }

            dataGridView1.DataSource = dt;
        }
    }
}
