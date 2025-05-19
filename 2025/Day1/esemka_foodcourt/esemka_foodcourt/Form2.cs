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
    public partial class Form2: Form
    {
        EsemkaFoodcourtEntities model = new EsemkaFoodcourtEntities();

        public Form2()
        {
            
            InitializeComponent();
            textBox5.PasswordChar = '*';
            textBox6.PasswordChar = '*';
        }

        public void submit()
        {
            if (!textBox3.Text.Contains('@') || !textBox3.Text.Contains('.'))
            {
                MessageBox.Show("Email Invalid");
            }
            else
            {
                if(textBox5.Text.Equals(textBox6.Text))
                {

                    try
                    {
                        var user = new User();
                        user.FirstName = textBox1.Text;
                        user.LastName = textBox2.Text;
                        user.Email = textBox3.Text;
                        user.PhoneNumber = textBox4.Text;
                        user.Password = textBox5.Text;
                        user.RoleID = 2;
                        user.DateJoined = DateTime.Now;

                        var r = model.Users.Add(user);
                        model.SaveChanges();

                        if (r != null)
                        {
                            MessageBox.Show("Sukses Register");
                        }
                        else
                        {
                            MessageBox.Show("Gagal Register");

                        }

                    }
                    catch (Exception ex) 
                    {
                    
                        MessageBox.Show(ex.ToString());
                    
                    }


                } else
                {
                    MessageBox.Show("Password tidak sama");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            submit();
        }
    }
}
