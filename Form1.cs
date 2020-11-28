using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace reqLap4
{
    public partial class Form1 : Form
    {
        Controller controllerObj;

        const int fx = 210;
        const int mx = 578;
        const int lx = 951;
        const int py = 52;
        const int ty = -2;

        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            controllerObj = new Controller();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            insertPanel.Visible = false;
            inserttitlepanel.Visible = false;
            updatepanel.Visible = false;
            updatetitlepanel.Visible = false;

            showpanel.Visible = true;
            showtitlepanel.Visible = true;
            showpanel.Location = new Point(fx, py);
            showtitlepanel.Location = new Point(fx, ty);
            insertPanel.Location = new Point(mx, py);
            inserttitlepanel.Location = new Point(mx, ty);
            updatepanel.Location = new Point(lx, py);
            updatetitlepanel.Location = new Point(lx, ty);
        }
        private void insert_Click(object sender, EventArgs e)
        {

            insertPanel.Visible = true;
            inserttitlepanel.Visible = true;
            updatepanel.Visible = false;
            updatetitlepanel.Visible = false;

            showpanel.Visible = false;
            showtitlepanel.Visible = false;
            showpanel.Location = new Point(mx, py);
            showtitlepanel.Location = new Point(mx, ty);
            insertPanel.Location = new Point(fx, py);
            inserttitlepanel.Location = new Point(fx, ty);
            updatepanel.Location = new Point(lx, py);
            updatetitlepanel.Location = new Point(lx, ty);
        }

        private void delete_Click(object sender, EventArgs e)
        {
            insertPanel.Visible = false;
            inserttitlepanel.Visible = false;
            updatepanel.Visible = true;
            updatetitlepanel.Visible = true;

            showpanel.Visible = false;
            showtitlepanel.Visible = false;
            showpanel.Location = new Point(mx, py);
            showtitlepanel.Location = new Point(mx, ty);
            insertPanel.Location = new Point(lx, py);
            inserttitlepanel.Location = new Point(lx, ty);
            updatepanel.Location = new Point(fx, py);
            updatetitlepanel.Location = new Point(fx, ty);
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }





        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var dt = dateTimeBox.Value.ToString();
            string month = "";
            string day = "";
            string year = "";

            for (int i = 0; i < 2; i++)
            {
                if(dt[i] != '/')
                {
                    month += dt[i];
                    continue;
                }
                break;
            }

            for (int i = month.Length + 1; i < month.Length+3 ; i++)
            {
                if (dt[i] != '/')
                {
                    day += dt[i]; 
                    continue;
                }
                break;
            } 
            
            for (int i = month.Length + day.Length + 2; i < month.Length + day.Length + 6; i++)
            {
                if (dt[i] != '/')
                {
                    year += dt[i];
                    continue;
                }
                break;
            }
             
           
            try
            {
            var result = controllerObj.inserrtNewEmployee(
                        Fname: firstNameBox.Text,
                        Minit:  middleNameBox.Text[0],
                        Lname: lastNameBox.Text,
                        SSN: int.Parse(ssnBox.Text),
                        Address: addressBox.Text,
                        Sex: listBox1.Text[0],
                        Bdate: year + "-" + month + "-" + day,
                        Salary: int.Parse(sallyBox.Text),
                        Super_SSN: int.Parse(superSSNBox.Text),
                        Dno: int.Parse(departrmentBox.Text));
                    if (result == 0)
                    {
                        MessageBox.Show("The insertion of a new Employee failed");
                    }
                    else
                    {
                        MessageBox.Show("The row is inserted successfully!");
                    }
            }
            catch (Exception error)
            {
                MessageBox.Show("You Should Fill all cells With right Values");

            }


        }

        private void deleteproject_Click(object sender, EventArgs e)
        {
            try
            { 
                var result = controllerObj.DeleteProject(deleteprojectnumber.Text);

                if (result == 0)
                {
                    MessageBox.Show("No rows are deleted");
                }
                else
                {
                    MessageBox.Show("The Project is deleted successfully!");
                }

            }catch(Exception error)
            {
                MessageBox.Show("You Should enter a number");
            }

        }

        private void update_Click(object sender, EventArgs e)
        {
            try
            {
                 var dt = dateTimePicker1.Value.ToString();
                            string month = "";
                            string day = "";
                            string year = "";

                           for (int i = 0; i < 2; i++)
            {
                if(dt[i] != '/')
                {
                    month += dt[i];
                    continue;
                }
                break;
            }

            for (int i = month.Length + 1; i < month.Length+3 ; i++)
            {
                if (dt[i] != '/')
                {
                    day += dt[i]; 
                    continue;
                }
                break;
            } 
            
            for (int i = month.Length + day.Length + 2; i < month.Length + day.Length + 6; i++)
            {
                if (dt[i] != '/')
                {
                    year += dt[i];
                    continue;
                }
                break;
            }
             


                            var result = controllerObj.UpdateEmployee(
                                Fname: fn.Text,
                                Minit: mn.Text[0],
                                Lname: ln.Text,
                                SSN: int.Parse(ssnup.Text),
                                Address: ad.Text,
                                Sex: sexup.Text[0],
                                Bdate: year + "-" + month + "-" + day,
                                Salary: int.Parse(s.Text),
                                Super_SSN: int.Parse(sup.Text),
                                Dno: int.Parse(dno.Text));
                            if (result == 0)
                            {
                                MessageBox.Show("The Update of a new Employee failed");
                            }
                            else
                            {
                                MessageBox.Show("The row is Updated successfully!");
                            }
            }
            catch (Exception error)
            {
                MessageBox.Show("You Should Fill all cells With right Values");

            }

        }

        private void getthenumber_Click(object sender, EventArgs e)
        {
            try
            {
            empNumber.Text = controllerObj.CountEmployeesproj(int.Parse(projectNumber.Text)).ToString();

            }catch(Exception error)
            {
                MessageBox.Show("You Should enter a number");
            }
        }

        private void showemployees_Click(object sender, EventArgs e)
        {
            try { 

            DataTable dt = controllerObj.SelectAllEmployeesdep(int.Parse(departmentNumbertoshow.Text));
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
        }catch(Exception error)
            {
                MessageBox.Show("You Should enter a number");
            }
}

        private void dateTimeBox_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
