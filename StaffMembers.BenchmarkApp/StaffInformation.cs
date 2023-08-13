using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffMembers.BenchmarkApp
{
    public class StaffInformation
    {
        private string staffName;         // add private variable staffName - string
        private int staffID;              // add private variable staffID - int
        private DateTime dateOfBirth;     // add private variable dateOfBirth - date
        private string staffEmail;        // add private variable staffEmail - string
        private int staffAnnualSalary;    // add private variable staffAnnualSalary -int

        public string StaffName { get => staffName; set => staffName = value; }                       // add public variable staffName - string
        public int StaffID { get => staffID; set => staffID = value; }                                // add public variable staffID - int
        public DateTime DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }               // add public variable dateOfBirth - date
        public string StaffEmail { get => staffEmail; set => staffEmail = value; }                    // add public variable staffEmail - string
        public int StaffAnnualSalary { get => staffAnnualSalary; set => staffAnnualSalary = value; }  // add public variable staffAnnualSalary -int

        public StaffInformation() 
        { 
            StaffName = "NA";                    //Add Constructor with default values to the variables
            StaffID = 0;
            DateOfBirth = DateTime.MinValue;
            StaffEmail = string.Empty;
            StaffAnnualSalary = 0;

        }
        public override string ToString()         //Override the ToString()Method to Display
        {
            return "Name: " +StaffName + " ID: " + StaffID + " Date of Birth: " + DateOfBirth +" Email: "+ StaffEmail + " Annual Salary: " + StaffAnnualSalary;
        }
    }
}
