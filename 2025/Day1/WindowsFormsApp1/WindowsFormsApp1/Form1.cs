using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1: Form
    {
        CurrencyConverterEntities model = new CurrencyConverterEntities();

        public Form1()
        {
            InitializeComponent();
            loadPeriod();
            loadCurrency1();
            loadCurrency2();
        }

        private void loadPeriod()
        {
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            var data = model.Periods.Select(p => new { p.id, p.name }).ToList();

            comboBox1.DataSource = data;
            comboBox1.DisplayMember = "name";  
            comboBox1.ValueMember = "id";

        }

        private void loadCurrency1()
        {
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;

            var data = model.Currencies.Select(p => new {p.id, p.abbreviation}).ToList();

            comboBox2.DataSource = data;
            comboBox2.DisplayMember = "abbreviation";
            comboBox2.ValueMember = "id";
        }

        private void loadCurrency2()
        {
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;

            var data = model.Currencies.Select(p => new { p.id, p.abbreviation }).ToList();

            comboBox3.DataSource = data;
            comboBox3.ValueMember = "id";
            comboBox3.DisplayMember = "abbreviation";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void converter()
        {
            var c1 = Convert.ToInt32(comboBox1.SelectedValue);
            var c2 = Convert.ToInt32(comboBox2.SelectedValue);
            var c3 = Convert.ToInt32(comboBox3.SelectedValue);

            decimal result = 0;

            var exchanges1 = model.USDExchangeRates.Where(p => p.period_id == c1)
                .Where(p => p.currency_id == c2)
                .Select(p => new {p.id, p.rate}).FirstOrDefault();

            var exchanges2 = model.USDExchangeRates.Where(p => p.period_id == c1)
                .Where(p => p.currency_id == c3)
                .Select(p => new { p.id, p.rate }).FirstOrDefault();

            if(exchanges1 != null && exchanges2 != null)
            {
                var s = exchanges2.rate / exchanges1.rate;
                result = numericUpDown1.Value * s;
            }

            textBox1.Text = result.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            converter();
        }
    }
}
