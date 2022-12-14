using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Net.Mail;
using System.Net;
using System.Configuration;

public class Database
{
    SqlConnection con;
    SqlCommand cmd;
    SqlDataReader dr, dr1, dr2, dr3;
    DataTable dt, dt1, dt2, dt3;

    public Database()
    {

    }

    public void openConnection()
    {
        SqlConnection.ClearAllPools();
        con = new SqlConnection();
        con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\karan\Desktop\College\Sem-7\SE\AU Project-20220903T181758Z-001\AU Project\Copy of Software Project Development\Software Project Development\HRAttendance\App_Data\HRDatabase.mdf"";Integrated Security=True;Connect Timeout=30";
        con.Open();
    }

    public void closeConnection()
    {
        con.Close();
    }

    public Boolean validEmployee(String username, String password, String category)
    {
        openConnection();
        cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "ValidateEmployee";
        cmd.Parameters.Add("@username", username);
        cmd.Parameters.Add("@password", password);
        cmd.Parameters.Add("@category", category);
        dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            closeConnection();
            return true;
        }
        else
        {
            closeConnection();
            return false;
        }
    }

    public Employee profileDetails(String Empid)
    {
        Employee e = null;
        openConnection();
        cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "DisplayProfile";
        cmd.Parameters.Add("@empID", Empid);
        dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            e = new Employee();
            dr.Read();
            e.Eid1 = dr[1].ToString();
            e.Epassword1 = dr[2].ToString();
            e.Ename1 = dr[3].ToString();
            e.Eemail1 = dr[4].ToString();
            e.EBdate1 = dr[5].ToString();
            e.Ecast1 = dr[6].ToString();
            e.Emob1 = dr[7].ToString();
            e.EGender1 = dr[8].ToString();
            e.EDesignation1 = dr[9].ToString();
            e.EDepartment1 = dr[10].ToString();
            e.EshiftID1 = int.Parse(dr[11].ToString());
            e.Eleavebalance1 = int.Parse(dr[12].ToString());
            e.Ebasic1 = double.Parse(dr[13].ToString());
            e.EPic1 = dr[14].ToString();
            e.EshiftTime1 = getShiftTime(e.EshiftID1);
        }
        closeConnection();
        return e;

    }

    public String getShiftTime(int sID)
    {
        openConnection();
        cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "DisplayShiftTime";
        cmd.Parameters.Add("@sid", sID);
        dr = cmd.ExecuteReader();
        dr.Read();
        String s = dr[1].ToString() + " - " + dr[2].ToString();
        closeConnection();
        return s;
    }


    public Boolean InsertHolidays(String d, String desc)
    {
        openConnection();
        cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "InsertHoliday";
        cmd.Parameters.Add("@HDate", d);
        cmd.Parameters.Add("@Hdesc", desc);
        int value = cmd.ExecuteNonQuery();
        closeConnection();
        if (value > 0)
            return true;
        else
            return false;
    }

    public DataTable DisplayHolidays()
    {
        openConnection();
        cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "DisplayHoliday";
        dr = cmd.ExecuteReader();
        dt = new DataTable();
        dt.Load(dr);
        closeConnection();
        return dt;
    }

    public Boolean AddnewTimeline(DateTime dt, String desc, String type)
    {
        openConnection();
        cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "InsertTimeline";
        cmd.Parameters.Add("@dd", dt);
        cmd.Parameters.Add("@desc", desc);
        cmd.Parameters.Add("@addedby", type);
        int val = cmd.ExecuteNonQuery();
        closeConnection();
        if (val > 0)
            return true;
        else
            return false;
    }

    public DataTable viewTimeline()
    {
        openConnection();
        cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "DisplayTimeline";
        dr = cmd.ExecuteReader();
        dt = new DataTable();
        dt.Load(dr);
        closeConnection();
        return dt;
    }

    public DataTable viewTimelinebyDate(String Date)
    {
        openConnection();
        cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "DisplayTimelinebyDate";
        cmd.Parameters.Add("@ddate", Date);
        dr = cmd.ExecuteReader();
        dt = new DataTable();
        dt.Load(dr);
        closeConnection();
        return dt;
    }

    public String[] getAllDesignation()
    {
        openConnection();
        cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "getDesignations";
        dr = cmd.ExecuteReader();
        dt = new DataTable();
        dt.Load(dr);
        int count = dt.Rows.Count;
        String[] s = new String[count + 1];
        s[0] = "All";
        int i = 0;
        while (i < count)
        {
            s[i + 1] = dt.Rows[i][0].ToString();
            i++;
        }
        closeConnection();
        return s;
    }

    public DataTable displayEmployees(String category)
    {
        openConnection();
        cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        if (category.Equals("All"))
        {
            cmd.CommandText = "DisplayEmployees";
        }
        else
        {
            cmd.CommandText = "DisplayCategoryWiseEmployee";
            cmd.Parameters.Add("@cat", category);
        }
        dr = cmd.ExecuteReader();
        dt = new DataTable();
        dt.Load(dr);
        closeConnection();
        return dt;
    }

    public DataTable getAllPendingLeaves()
    {
        openConnection();
        cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "DisplayPendingLeaves";
        dr = cmd.ExecuteReader();
        dt = new DataTable();
        dt.Load(dr);
        closeConnection();
        return dt;
    }

    public DataTable getAllLeaves()
    {
        openConnection();
        cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "DisplayLeaves";
        dr = cmd.ExecuteReader();
        dt = new DataTable();
        dt.Load(dr);
        closeConnection();
        return dt;
    }

    public Salary getSalaryDetails(String ID, String Month, String Year)
    {
        Salary sal = null;
        openConnection();
        cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "getSalaryInfo";
        cmd.Parameters.Add("@EID", ID);
        cmd.Parameters.Add("@Month", Month);
        cmd.Parameters.Add("@Year", Year);
        dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            sal = new Salary();
            dr.Read();
            sal.Slipid = int.Parse(dr[0].ToString());
            sal.EmpID1 = dr[1].ToString();
            sal.Monthname1 = dr[2].ToString();
            sal.Year1 = dr[3].ToString();
            sal.Basic1 = double.Parse(dr[4].ToString());
            sal.DA1 = double.Parse(dr[5].ToString());
            sal.HRA1 = double.Parse(dr[6].ToString());
            sal.MA1 = double.Parse(dr[7].ToString());
            sal.TA1 = double.Parse(dr[8].ToString());
            sal.WorkingDays = int.Parse(dr[9].ToString());
            sal.PresentDays1 = int.Parse(dr[10].ToString());
            sal.LateDays1 = int.Parse(dr[11].ToString());
            sal.Penalty1 = double.Parse(dr[12].ToString());
            sal.MonthLeaves1 = int.Parse(dr[13].ToString());
            sal.CarryForwardLeave1 = int.Parse(dr[14].ToString());
        }
        return sal;
    }

    public String getEmployeeName(String ID)
    {
        openConnection();
        cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "getName";
        cmd.Parameters.Add("@EID", ID);
        dr = cmd.ExecuteReader();
        dr.Read();
        return dr[0].ToString();
    }

    public Boolean updatePersonalDetails(Employee e)
    {
        openConnection();
        cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "UpdatePersonalDetails";
        cmd.Parameters.Add("@eid", e.Eid1);
        cmd.Parameters.Add("@ename", e.Ename1);
        cmd.Parameters.Add("@email", e.Eemail1);
        cmd.Parameters.Add("@emobile", e.Emob1);
        cmd.Parameters.Add("@ecast", e.Ecast1);
        cmd.Parameters.Add("@ebdate", e.EBdate1);
        cmd.Parameters.Add("@egen", e.EGender1);
        int r = cmd.ExecuteNonQuery();
        if (r > 0)
        {
            closeConnection();
            return true;
        }
        else
        {
            closeConnection();
            return false;
        }
    }

    public Boolean SentLeaveRequest(String EID, String Date, String Reason)
    {
        openConnection();
        cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "InsertLeaveRequest";
        cmd.Parameters.Add("@eid", EID);
        cmd.Parameters.Add("@leaveDate", Date);
        cmd.Parameters.Add("@leaveReason", Reason);
        int r = cmd.ExecuteNonQuery();
        if (r > 0)
        {
            closeConnection();
            return true;
        }
        else
        {
            closeConnection();
            return false;
        }
    }

    public Boolean approveLeave(String LID)
    {
        openConnection();
        cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "ApproveLeave";
        cmd.Parameters.Add("@lid", LID);
        int r = cmd.ExecuteNonQuery();
        if (r > 0)
        {
            closeConnection();
            return true;
        }
        else
        {
            return false;
        }
    }

    public Boolean RejectLeave(String LID)
    {
        openConnection();
        cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "RejectLeave";
        cmd.Parameters.Add("@lid", LID);
        int r = cmd.ExecuteNonQuery();
        if (r > 0)
        {
            closeConnection();
            return true;
        }
        else
        {
            return false;
        }
    }

    public DataTable getEmployeeLeave(String s)
    {
        openConnection();
        cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "getEmpLeaves";
        cmd.Parameters.Add("@eid", s);
        dr = cmd.ExecuteReader();
        dt = new DataTable();
        dt.Load(dr);
        closeConnection();
        return dt;
    }

    public DataTable getATT(String ID, String Month, String Year)
    {
        openConnection();
        cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "DisplayAttendanceEmp";
        cmd.Parameters.Add("@eid", ID);
        cmd.Parameters.Add("@eMonth", Month);
        cmd.Parameters.Add("@eyear", Year);
        dr = cmd.ExecuteReader();
        dt = new DataTable();
        dt.Load(dr);
        return dt;
    }

    public Boolean updatePassword(Employee e, String newpwd)
    {
        openConnection();
        cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "isValidEmployee";
        cmd.Parameters.Add("@eid", e.Eid1);
        cmd.Parameters.Add("@epwd", e.Epassword1);
        dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            dr.Close();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "updatePassword";
            cmd.Parameters.Add("@eid", e.Eid1);
            cmd.Parameters.Add("@epwd", newpwd);
            int r = cmd.ExecuteNonQuery();
            closeConnection();
            return true;
        }
        closeConnection();
        return false;
    }

    public Boolean forgetpassword(Employee e1)
    {
        Boolean flg = false;
        openConnection();
        cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "EmpforgetPassword";
        cmd.Parameters.Add("@eid", e1.Eid1);
        cmd.Parameters.Add("@email", e1.Eemail1);
        dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            dr.Read();
            String Name = dr[3].ToString();
            String emailID = dr[4].ToString();
            String pwd = dr[2].ToString();
            String Data = "Dear  " + Name + ", \n Please Remember Username & Password For Login. \nUsername : " + e1.Eid1 + " \nPassword : " + pwd;
            String Sub = "Login Credentials";
            if (SendMail(emailID, Sub, Data))
            {
                flg = true;
            }
        }
        else
        {
            flg = false;
        }
        return flg;
    }

    public Boolean SendMail(String Email, String Subject, String Data)
    {
        return true;
    }

    public String[] getAllDept()
    {
        openConnection();
        cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "getDesg";
        dr = cmd.ExecuteReader();
        dt = new DataTable();
        dt.Load(dr);
        int count = dt.Rows.Count;
        String[] dept = new String[count];
        int i = 0;
        while (i < count)
        {
            dept[i] = dt.Rows[i][0].ToString();
            i++;
        }
        closeConnection();
        return dept;
    }

    public String[] getAllDesg()
    {
        openConnection();
        cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "getDept";
        dr = cmd.ExecuteReader();
        dt = new DataTable();
        dt.Load(dr);
        int count = dt.Rows.Count;
        String[] desg = new String[count];
        int i = 0;
        while (i < count)
        {
            desg[i] = dt.Rows[i][0].ToString();
            i++;
        }
        closeConnection();
        return desg;
    }

    public String[] getAllCast()
    {
        openConnection();
        cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "getCast";
        dr = cmd.ExecuteReader();
        dt = new DataTable();
        dt.Load(dr);
        int count = dt.Rows.Count;
        String[] cast = new String[count];
        int i = 0;
        while (i < count)
        {
            cast[i] = dt.Rows[i][0].ToString();
            i++;
        }
        closeConnection();
        return cast;
    }

    public String[] getAllShift()
    {
        openConnection();
        cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "getShift";
        dr = cmd.ExecuteReader();
        dt = new DataTable();
        dt.Load(dr);
        int count = dt.Rows.Count;
        String[] shift = new String[count];
        int i = 0;
        while (i < count)
        {
            shift[i] = dt.Rows[i][1].ToString() + "-" + dt.Rows[i][2].ToString();
            i++;
        }
        closeConnection();
        return shift;
    }

    public int getShiftID(String shf)
    {
        openConnection();
        cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "getShiftInfo";
        string[] times = shf.Split('-');
        cmd.Parameters.Add("@stime", times[0]);
        cmd.Parameters.Add("@etime", times[1]);
        dr = cmd.ExecuteReader();
        dr.Read();
        int val = int.Parse(dr[0].ToString());
        closeConnection();
        return val;
    }

    public String InsertEmployee(Employee emp)
    {
        openConnection();
        cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "InsertNewEmployee";
        cmd.Parameters.Add("@ename", emp.Ename1);
        cmd.Parameters.Add("@email", emp.Eemail1);
        cmd.Parameters.Add("@ebdate", emp.EBdate1);
        cmd.Parameters.Add("@ecast", emp.Ecast1);
        cmd.Parameters.Add("@emob", emp.Emob1);
        cmd.Parameters.Add("@egen", emp.EGender1);
        cmd.Parameters.Add("@edesg", emp.EDesignation1);
        cmd.Parameters.Add("@edept", emp.EDepartment1);
        cmd.Parameters.Add("@eshift", emp.EshiftID1);
        cmd.Parameters.Add("@ebasic", emp.Ebasic1);
        string strEid = Convert.ToString(cmd.ExecuteScalar()); 
        return strEid;
    }

    public DataTable displaySalaryStructure()
    {
        openConnection();
        cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "getSalaryStructure";
        dr = cmd.ExecuteReader();
        dt = new DataTable();
        dt.Load(dr);
        closeConnection();
        return dt;
    }

    public DataTable displayLookup()
    {
        openConnection();
        cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "getLookup";
        dr = cmd.ExecuteReader();
        dt = new DataTable();
        dt.Load(dr);
        closeConnection();
        return dt;
    }

    public int getcompanyYear()
    {
        openConnection();
        cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "getYear";
        dr = cmd.ExecuteReader();
        dr.Read();
        return int.Parse(dr[0].ToString());
    }

    public Boolean OpenApplications(String ans)
    {
        openConnection();
        cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "AllowApplications";
        cmd.Parameters.Add("@value", ans);
        int r = cmd.ExecuteNonQuery();
        closeConnection();
        if (r > 0)
            return true;
        else
            return false;
    }

    public DataTable getAbsentEmployee(String Date)
    {
        openConnection();
        cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "getAbsentEntry";
        cmd.Parameters.Add("@ADate", Date);
        dr = cmd.ExecuteReader();
        dt = new DataTable();
        dt.Load(dr);
        closeConnection();
        return dt;
    }

    public Boolean isHoliday(String hdate)
    {
        openConnection();
        cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "CheckHoliday";
        cmd.Parameters.Add("@dates", hdate);
        dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            closeConnection();
            return true;
        }
        else
        {
            closeConnection();
            return false;
        }
    }

    public Boolean isAttendanceTake(String dates)
    {
        openConnection();
        cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "isAttendanceTaken";
        cmd.Parameters.Add("@dates", dates);
        dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            closeConnection();
            return true;
        }
        else
        {
            closeConnection();
            return false;
        }
    }

    public int makeEntry(String dates, String type)
    {
        int r = 0;
        openConnection();
        cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "DisplayEmployees";
        dr = cmd.ExecuteReader();
        dt = new DataTable();
        dt.Load(dr);
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (isLeaveAccepted(dt.Rows[i][0].ToString(), dates))
            {
                type = "L";
            }
            else
            {
                type = "A";
            }
            openConnection();
            SqlCommand cmd1 = new SqlCommand();
            cmd1.Connection = con;
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.CommandText = "InsertAttendanceABH";
            cmd1.Parameters.Add("@eid", dt.Rows[i][0].ToString());
            cmd1.Parameters.Add("@edates", dates);
            cmd1.Parameters.Add("@etype", type);
            r = cmd1.ExecuteNonQuery();
        }
        closeConnection();
        return r;
    }

    public int makeEntrys(String dates, String type)
    {
        int r = 0;
        openConnection();
        cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "DisplayEmployees";
        dr = cmd.ExecuteReader();
        dt = new DataTable();
        dt.Load(dr);
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            openConnection();
            SqlCommand cmd1 = new SqlCommand();
            cmd1.Connection = con;
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.CommandText = "InsertAttendanceABH";
            cmd1.Parameters.Add("@eid", dt.Rows[i][0].ToString());
            cmd1.Parameters.Add("@edates", dates);
            cmd1.Parameters.Add("@etype", type);
            r = cmd1.ExecuteNonQuery();
        }
        closeConnection();
        return r;
    }

    public Boolean isLeaveAccepted(String id, String Date)
    {
        openConnection();
        cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "isLeave";
        cmd.Parameters.Add("@eid", id);
        cmd.Parameters.Add("@edate", Date);
        dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            closeConnection();
            return true;
        }
        else
        {
            closeConnection();
            return false;
        }
    }

    public int makeEntryPresent(String dates, String type, String ciTime, String coTime)
    {
        int r = 0;
        openConnection();
        cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "DisplayEmployees";
        dr = cmd.ExecuteReader();
        dt = new DataTable();
        dt.Load(dr);
        dr.Close();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            SqlCommand cmd1 = new SqlCommand();
            cmd1.Connection = con;
            cmd1.CommandType = CommandType.StoredProcedure;
            //   cmd1.CommandText = "InsertEmployeeAttendancePresent";
            cmd1.Parameters.Add("@eid", dt.Rows[i][0].ToString());
            cmd1.Parameters.Add("@edates", dates);
            cmd1.Parameters.Add("@etype", type);
            cmd1.Parameters.Add("@citime", ciTime);
            r = cmd1.ExecuteNonQuery();
        }
        closeConnection();
        return r;
    }

    public void updateAttendance(int aid)
    {
        openConnection();
        cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "AttendanceUpdate";
        cmd.Parameters.Add("@aid", aid);
        cmd.ExecuteNonQuery();
        closeConnection();
    }

    public Boolean isSalaryPaid(String s)
    {
        openConnection();
        cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "isPaid";
        cmd.Parameters.Add("@mon", s);
        dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            closeConnection();
            return true;
        }
        else
        {
            closeConnection();
            return false;
        }
    }

    public Boolean calculateSalary(String s)
    {
        openConnection();
        SqlCommand cmd1 = new SqlCommand();
        cmd1.Connection = con;
        cmd1.CommandType = CommandType.StoredProcedure;
        cmd1.CommandText = "AllEmp";
       
        //SqlDataReader dr1 = cmd1.ExecuteReader(); -- Pritish
        dr1 = cmd1.ExecuteReader();

        dt1 = new DataTable();
        dt1.Load(dr1);
        closeConnection();


        openConnection();
        dt3 = new DataTable();
        SqlCommand cmd3 = new SqlCommand();
        cmd3.Connection = con;
        cmd3.CommandType = CommandType.StoredProcedure;
        cmd3.CommandText = "getSalaryStructure";
        dr3 = cmd3.ExecuteReader();
        dt3 = new DataTable();
        dt3.Load(dr3);
        closeConnection();
                
        for (int i = 0; i < dt1.Rows.Count; i++)
        {
            Salary sal = new Salary();
            sal.EmpID1 = dt1.Rows[i][1].ToString();
            sal.Monthname1 = s;
            sal.Year1 = DateTime.Now.Year.ToString().Remove(0, 2);
            sal.Basic1 = double.Parse(dt1.Rows[i][13].ToString());

            openConnection();
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = con;
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.CommandText = "getAttendanceCount";
            cmd2.Parameters.Add("@eid", sal.EmpID1);
            cmd2.Parameters.Add("@mon", sal.Monthname1);
            cmd2.Parameters.Add("@year", sal.Year1);
            dt2 = new DataTable();
            dr2 = cmd2.ExecuteReader();
            dt2.Load(dr2);
            closeConnection();

            int workingdays = 0;
            int presentdays = 0;
            int latedays = 0;
            int absentdays = 0;
            int leaves = 0;
            for (int j = 0; j < dt2.Rows.Count; j++)
            {
                if (dt2.Rows[j][3].ToString().Equals("P"))
                {
                    presentdays++;
                    workingdays++;
                }
                else if (dt2.Rows[j][3].ToString().Equals("L"))
                {
                    leaves++;
                    workingdays++;
                }
                else if (dt2.Rows[j][3].ToString().Equals("A"))
                {
                    leaves++;
                    absentdays++;
                    workingdays++;
                }

                if (dt2.Rows[j][6].ToString() == "Yes")
                    latedays++;
            }
            sal.WorkingDays = workingdays;
            sal.PresentDays1 = presentdays;
            sal.LateDays1 = latedays;
            sal.Penalty1 = Math.Round((absentdays * (sal.Basic1 / sal.WorkingDays)), 2);
            sal.MonthLeaves1 = leaves;
            sal.CarryForwardLeave1 = int.Parse(dt1.Rows[i][12].ToString())-sal.MonthLeaves1;
           
            if (dt3.Rows[0][3].ToString().Equals("Yes"))
            {
                sal.DA1 = (sal.Basic1 * double.Parse(dt3.Rows[0][2].ToString())) / 100;
            }
            else
            {
                sal.DA1 = double.Parse(dt3.Rows[0][2].ToString());
            }

            if (dt3.Rows[1][3].ToString().Equals("Yes"))
            {
                sal.HRA1 = (sal.Basic1 * double.Parse(dt3.Rows[1][2].ToString())) / 100;
            }
            else
            {
                sal.HRA1 = double.Parse(dt3.Rows[1][2].ToString());
            }

            if (dt3.Rows[2][3].ToString().Equals("Yes"))
            {
                sal.MA1 = (sal.Basic1 * double.Parse(dt3.Rows[2][2].ToString())) / 100;
            }
            else
            {
                sal.MA1 = double.Parse(dt3.Rows[2][2].ToString());
            }

            if (dt3.Rows[3][3].ToString().Equals("Yes"))
            {
                sal.TA1 = (sal.Basic1 * double.Parse(dt3.Rows[3][2].ToString())) / 100;
            }
            else
            {
                sal.TA1 = double.Parse(dt3.Rows[3][2].ToString());
            }

            DoneSalary(sal);

        }
        return true;
    }

    public void DoneSalary(Salary sal)
    {
        openConnection();
        cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "AddSalary";
        cmd.Parameters.Add("@seid", sal.EmpID1);
        cmd.Parameters.Add("@smon", sal.Monthname1);
        cmd.Parameters.Add("@syear", sal.Year1);
        cmd.Parameters.Add("@sbasic", sal.Basic1);
        cmd.Parameters.Add("@sda", sal.DA1);
        cmd.Parameters.Add("@shra", sal.HRA1);
        cmd.Parameters.Add("@sma", sal.MA1);
        cmd.Parameters.Add("@sta", sal.TA1);
        cmd.Parameters.Add("@swork", sal.WorkingDays);
        cmd.Parameters.Add("@spre", sal.PresentDays1);
        cmd.Parameters.Add("@slate", sal.LateDays1);
        cmd.Parameters.Add("@spen", sal.Penalty1);
        cmd.Parameters.Add("@slev", sal.MonthLeaves1);
        cmd.Parameters.Add("@scarry", sal.CarryForwardLeave1);
        cmd.ExecuteNonQuery();
        closeConnection();
    }

    public DataSet getDesgCount()
    {
        openConnection();
        cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "select E_Designation,count(E_Designation) from Tbl_Employee Group by E_Designation";
        cmd.CommandType = CommandType.Text;
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet("CountEmployee");
        adp.Fill(ds, "Tbl_Employee");
        return ds;
    }

    public DataTable getReports()
    {
        openConnection();
        cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "select Id,Report_Description from Tbl_Reports";
        dr = cmd.ExecuteReader();
        dt = new DataTable();
        dt.Load(dr);
        return dt;
    }
}