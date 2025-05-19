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
    public partial class Form1: Form
    {
        EsemkaFoodcourtEntities model = new EsemkaFoodcourtEntities();
        public Form1()
        {
            InitializeComponent();
            textBox2.PasswordChar = '*';
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void login()
        {
            var user = model.Users.Where(k => k.Email.Equals(textBox1.Text)).FirstOrDefault();

            if (user != null) {
                if (user.Password.Equals(textBox2.Text)) {
                    //MessageBox.Show("Login berhasil");
                    UserClass.user = user;
                    UserClass.name = user.FirstName + " " + user.LastName;

                    if (user.RoleID == 2)
                    {
                        Form4 form4 = new Form4();
                        form4.Show();
                        this.Hide();
                    }

                    if (user.RoleID == 1) 
                    {
                        Form3 form3 = new Form3();
                        form3.Show();
                        this.Hide();
                    }
                } else
                {
                    label5.Text = "Invalid Password";
                }
            } else
            {
                label5.Text = "Invalid Credential";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            login();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }
    }
}
