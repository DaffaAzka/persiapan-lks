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
    public partial class Form7: Form
    {
        EsemkaFoodcourtEntities model = new EsemkaFoodcourtEntities();


        List<int> ints = new List<int>();
        public Form7()
        {
            InitializeComponent();
            load();
        }

        public void load()
        {
            var dt = new DataTable();
            dt.Columns.Add("Menu", typeof(string));
            dt.Columns.Add("Action");

            var allMenu = model.Menus.ToList();
            foreach (var menu in allMenu)
            {
                ints.Add(menu.ID);
                dt.Rows.Add(menu.Name, "Edit Ingredients");
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

                int id = ints[e.RowIndex];
                var dt = new DataTable();
                dt.Columns.Add("Name", typeof(string));
                dt.Columns.Add("Qtc", typeof(decimal));
                dt.Columns.Add("Unit", typeof(string));
                dt.Columns.Add("Action", typeof(string));

                var menuIngredients = model.MenuIngredients.Where(x => x.MenuID == id).Select(x => new
                {
                    x.ID,
                    IngredientName = model.Ingredients.Where(y => y.ID == x.IngredientID).Select(y => y.Name).FirstOrDefault(),
                    UnitName = model.Units.Where(y => y.ID == x.UnitID).Select(y => y.Name).FirstOrDefault(),
                    x.Qty
                });
                foreach (var menu in menuIngredients)
                {
                    ints.Add(menu.ID);
                    dt.Rows.Add(menu.IngredientName, menu.Qty, menu.UnitName, "Remove");
                }

                dataGridView2.DataSource = dt;

            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
