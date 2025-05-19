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
    public partial class Form6: Form
    {
        EsemkaFoodcourtEntities model = new EsemkaFoodcourtEntities();
        int? idSelected = null;

        public Form6()
        {
            InitializeComponent();
            numericUpDown1.Minimum = 0;
            numericUpDown1.Maximum = 9999999;
            loadData();
        }

        public void loadData()
        {
            var dt = new DataTable();
            dt.Columns.Add("Id", typeof(decimal));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Category", typeof(string));
            dt.Columns.Add("Description", typeof(string));
            dt.Columns.Add("Price", typeof(decimal));


            var Allmenu = model.Menus.Select(menu => new
            {
                menu.ID,
                menu.Name,
                menu.Description,
                menu.Price,
                CategoryName = model.Categories.Where(c => c.ID == menu.CategoryID).Select(c => c.Name).FirstOrDefault()

            }).ToList();
            foreach (var menu in Allmenu)
            {
                dt.Rows.Add(menu.ID, menu.Name, menu.CategoryName, menu.Description, menu.Price);
            }

            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                var id = int.Parse(selectedRow.Cells[0].Value.ToString());

                var m = model.Menus.FirstOrDefault(w => w.ID == id);

                id = m.ID;
                textBox1.Text = m.Name;
                textBox2.Text = m.Description;
                numericUpDown1.Value = (decimal) m.Price;
            }





        }
    }
}
