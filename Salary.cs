using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Salary
{
	public Salary()
	{
        
	}

    int id, workingDays, PresentDays, LateDays, MonthLeaves, CarryForwardLeave, slipid;

    public int Slipid
    {
        get { return slipid; }
        set { slipid = value; }
    }

    public int CarryForwardLeave1
    {
        get { return CarryForwardLeave; }
        set { CarryForwardLeave = value; }
    }

    public int MonthLeaves1
    {
        get { return MonthLeaves; }
        set { MonthLeaves = value; }
    }

    public int LateDays1
    {
        get { return LateDays; }
        set { LateDays = value; }
    }

    public int PresentDays1
    {
        get { return PresentDays; }
        set { PresentDays = value; }
    }

    public int WorkingDays
    {
        get { return workingDays; }
        set { workingDays = value; }
    }

    public int Id
    {
        get { return id; }
        set { id = value; }
    }
    String EmpID, Monthname, Year;

    public String Year1
    {
        get { return Year; }
        set { Year = value; }
    }

    public String Monthname1
    {
        get { return Monthname; }
        set { Monthname = value; }
    }

    public String EmpID1
    {
        get { return EmpID; }
        set { EmpID = value; }
    }
    Double Basic, DA, HRA, MA, TA, Penalty;

    public Double Penalty1
    {
        get { return Penalty; }
        set { Penalty = value; }
    }

    public Double TA1
    {
        get { return TA; }
        set { TA = value; }
    }

    public Double MA1
    {
        get { return MA; }
        set { MA = value; }
    }

    public Double HRA1
    {
        get { return HRA; }
        set { HRA = value; }
    }

    public Double DA1
    {
        get { return DA; }
        set { DA = value; }
    }

    public Double Basic1
    {
        get { return Basic; }
        set { Basic = value; }
    }
}