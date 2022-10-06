using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Login_Form_Application
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Represents a connection to a SQL Server Database
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-KQ1OF28;Initial Catalog=Youtube;Integrated Security=True");


        private void button_login_Click(object sender, EventArgs e)
        {
            String username, user_password;

            username = txt_username.Text;
            user_password = txt_password.Text;

            try
            {
                String querry = "SELECT * FROM Login_new WHERE username = '"+txt_username.Text+"' AND password = '"+txt_password.Text+"'";
                SqlDataAdapter sda = new SqlDataAdapter(querry, conn);

                DataTable dtable = new DataTable();
                sda.Fill(dtable);

                if(dtable.Rows.Count > 0)
                {
                    username = txt_username.Text;

                    //page that needed to be load next
                    Menuform form2 = new Menuform();
                    form2.Show();
                    //hides the login form
                    this.Hide();
                    

                }
                else
                {
                    MessageBox.Show("Invalid login details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_username.Clear();
                    txt_password.Clear();

                    //to focus username
                    txt_username.Focus();
                }

            }
            catch
            {
                MessageBox.Show("Error");
            }
            finally
            {
                //Closes the connection to the database
                conn.Close();
            }

        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            txt_username.Clear();
            txt_password.Clear();

            txt_username.Focus();
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            DialogResult res;

            res = MessageBox.Show("Do you want to exit", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                this.Show();
            }
        }
    }
}

//Very simple example with no SQL INJECTION MECHANISM
//SQL INJECTION EXAMPLE
//admin'or'1'='1
