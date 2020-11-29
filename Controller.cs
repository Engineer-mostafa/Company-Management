using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;


namespace reqLap4
{

    public class Controller
    {
        DBManager dbMan;

        public Controller()
        {
            dbMan = new DBManager();
        }


        public int inserrtNewEmployee(
            string Fname,
            char Minit,
            string Lname,
            int SSN,
            string Address,
            char Sex,
            string Bdate,
            int Salary,
            int Super_SSN,
            int Dno
            )
        {
            string query = "INSERT INTO Employee (Fname, Minit, Lname, SSN, Address, Sex, Bdate, Salary, Super_SSN, Dno) " +
                            "Values('" + Fname + "','" + Minit + "','" + Lname + "'," + SSN + ",'" + Address + "','" +  Sex + "','" + Bdate +  "'," + Salary + ","  + Super_SSN + "," + Dno + ");";
            return dbMan.ExecuteNonQuery(query);

        }



        public int DeleteProject(string pNumber)
        {
            string query = "DELETE FROM Project WHERE pNumber='" + pNumber + "';";
            return dbMan.ExecuteNonQuery(query);
        }




        public int UpdateEmployee(
            string Fname,
            char Minit,
            string Lname,
            int SSN,
            string Address,
            char Sex,
            string Bdate,
            int Salary,
            int Super_SSN,
            int Dno
            )
        {
            string query = "UPDATE Employee SET Fname = '" + Fname + "'," + " Minit = '" + Minit + "'," + " Lname = '" + Lname + "'," + " Address ='" + Address + "'," + " Sex = '" + Sex + "'," + " Bdate = '" + Bdate + "'," + " Salary = " + Salary + "," + " Super_SSN =  " + Super_SSN + "," + " Dno = " + Dno + " WHERE SSN = " + SSN + ";";
            return dbMan.ExecuteNonQuery(query);
        }


        public DataTable SelectAllEmployeesdep(int departmentNumber)
        {
            string query = "SELECT * FROM Employee WHERE Dno = '" + departmentNumber + "';";
            return dbMan.ExecuteReader(query);
        }


        public int CountEmployeesproj(int projectNumber)
        {
            string query = "SELECT COUNT(SSN) FROM Employee as e , Works_On as wo  Where e.SSN = wo.Essn AND wo.Pno = '" + projectNumber + "' ;";
            return (int)dbMan.ExecuteScalar(query);
        }
    }
}
