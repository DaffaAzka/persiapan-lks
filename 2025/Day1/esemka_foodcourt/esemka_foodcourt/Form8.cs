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
    }
}
