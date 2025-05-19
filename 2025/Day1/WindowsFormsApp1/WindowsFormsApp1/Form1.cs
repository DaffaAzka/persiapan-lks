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
            converter();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            converter();
        }

        private void converter()
        {

            try
            {
                var c1 = int.Parse(comboBox1.SelectedValue.ToString());
                var c2 = int.Parse(comboBox2.SelectedValue.ToString());
                var c3 = int.Parse(comboBox3.SelectedValue.ToString());

                double t2 = double.Parse(textBox2.Text);

                decimal result = 0;

                var exchanges1 = model.USDExchangeRates.Where(p => p.period_id == c1)
                    .Where(p => p.currency_id == c2)
                    .Select(p => new { p.id, p.rate }).FirstOrDefault();

                var exchanges2 = model.USDExchangeRates.Where(p => p.period_id == c1)
                    .Where(p => p.currency_id == c3)
                    .Select(p => new { p.id, p.rate }).FirstOrDefault();

                if (exchanges1 != null && exchanges2 != null)
                {
                    var s = exchanges2.rate / exchanges1.rate;
                    result = (decimal)t2 * s;
                }

                textBox1.Text = Math.Round(result, 3).ToString();
            } catch(Exception e)
            {

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            converter();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var c2 = textBox2.Text;
            var c1 = textBox1.Text;

            var cb1 = comboBox2.SelectedIndex;
            var cb2 = comboBox3.SelectedIndex;

            comboBox2.SelectedIndex = cb2;
            comboBox3.SelectedIndex = cb1;

            textBox2.Text = c1.ToString();
            textBox1.Text = c2.ToString();

            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            converter();
        }
    }
}
