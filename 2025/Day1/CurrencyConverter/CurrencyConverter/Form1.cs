using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CurrencyConverter
{
    public partial class Form1: Form
    {
        private CurrencyConverterEntities model = new CurrencyConverterEntities();

        public Form1()
        {
            InitializeComponent();
            load();

        }

        private void load()
        {
            var data = model.Periods.Select(p => new {p.id, p.name} ).ToList();
            comboBox1 = new ComboBox();
            comboBox1.Items.AddRange(data);
            comboBox1.SelectedIndex = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
