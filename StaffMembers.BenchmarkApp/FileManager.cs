using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Linq.Expressions;

namespace StaffMembers.BenchmarkApp
{
    internal class FileManager
    {
        public List<StaffInformation> LoadStaffInformation()                            //Add a LoadStaffInformation method
        {   

              List<StaffInformation> staffInformation = new List<StaffInformation>(); 

              StreamReader sr = new StreamReader("Staffinformations.txt");

               while (!sr.EndOfStream)                                                  //Validate when the stream finish getting the data
               { 
                    string temp = sr.ReadLine();                                        //read the data
                    string[] values = temp.Split(',');                                  //change the data to be array 

                      StaffInformation s = new StaffInformation();                      // building a new object
                      s.StaffName = values[0];
                      s.StaffID = int.Parse(values[1]);
                      s.DateOfBirth = DateTime.Parse(values[2]); 
                      s.StaffEmail = values[3];
                      s.StaffAnnualSalary = int.Parse(values[4]);

                      staffInformation.Add(s);
               }
               sr.Close();
               return staffInformation; 
           
        }

        public bool SaveStaffInformation(List<StaffInformation> list, string fileName)
        {
            try // using try/catch block
            {
                StreamWriter sw = new StreamWriter(fileName);                              //declear a new writeable stream

                foreach (StaffInformation s in list)                                       //using foreach method
                {
                    sw.WriteLine(s.StaffName + "," + s.StaffID + "," + s.DateOfBirth + "," + s.StaffEmail + "," + s.StaffAnnualSalary);  //put the data into the stream
                }
                sw.Dispose();                                                          //dispose=close
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        
        }
        public bool SaveInFile(StaffInformation s, string fileName)           
        {

            try
            {
                StreamWriter sw = new StreamWriter(fileName);      //declear a new writeable stream

                //build data 
                sw.WriteLine("STAFF DETAILS");
                sw.WriteLine("Staff Name: " + s.StaffName);
                sw.WriteLine("StaffID: " + s.StaffID);
                sw.WriteLine("Staff Date of Birth: " + s.DateOfBirth);
                sw.WriteLine("Staff email: "+ s.StaffEmail);
                sw.WriteLine("Staff Annual Salary: "+ s.StaffAnnualSalary);
                 
                sw.Dispose();           // dispose the stream - avoid out of memory leak exception.
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
