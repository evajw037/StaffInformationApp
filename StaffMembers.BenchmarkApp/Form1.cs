using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StaffMembers.BenchmarkApp
{
    public partial class Form1 : Form
    {
        List<StaffInformation> staffInformation = new List<StaffInformation>();    //Global variable

        public Form1()
        {
            InitializeComponent();
        }

        public void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }


        public void ttpToolTips_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        public void btnAZ_Click(object sender, EventArgs e)
        {
            Filter sFilter = new Filter();                                        //create a Filter object

            staffInformation = sFilter.SortAZ(staffInformation);                 //set the staffinformation list to equal the results from the Sort method

            lbxStaffMembers.Items.Clear();
            lbxStaffMembers.Items.AddRange(staffInformation.ToArray());          //update the listbox
        }

        public void btnLoad_Click(object sender, EventArgs e)
        {
            staffInformation.Clear();                                            //clear the master staffinformation list
            
            FileManager fm = new FileManager();                                  //create a FileManager object

            staffInformation = fm.LoadStaffInformation();                        //load the staffinformations, update the data

            if (staffInformation == null)                                        //Add an if statement in case things went wrong during loading and a null list was returned.
            {
                MessageBox.Show("Error loading Staff Informations", "File IO Error");
            }
            else
            {
                lbxStaffMembers.Items.Clear();
                lbxStaffMembers.Items.AddRange(staffInformation.ToArray());               //update the listbox
            }
            
        }

        public void btnZA_Click(object sender, EventArgs e)
        {
            Filter sFilter = new Filter();                                             //create a Filter object

            staffInformation = sFilter.SortZA(staffInformation);     //set the staffinformation list to equal the results from the Sort method

            lbxStaffMembers.Items.Clear();
            lbxStaffMembers.Items.AddRange(staffInformation.ToArray());                     //update the listbox
        }

        public void btnSearch_Click(object sender, EventArgs e)
        { 
            List<StaffInformation> result = new List<StaffInformation>();                //create a search results list

            Filter sFilter = new Filter();                                                  //Creat a Filter object

            string term = tbxSearch.Text;                                                     //Get search term

            result = sFilter.Search(staffInformation, term);             //set the results list to equal what is returned from the search method

            lbxSearchResults.Items.Clear();                                              //clear the list items
            lbxSearchResults.Items.AddRange(result.ToArray());                        //update the search results list box

        }

        public void btnAdd_Click(object sender, EventArgs e)
        {
            staffInformation.Clear();
            FileManager fileManager = new FileManager();
            staffInformation = fileManager.LoadStaffInformation();                               // load data from txt file

            StaffInformation staffInformation01 = new StaffInformation();                      // declare a new object.

            try
            {
                int.Parse(tbxName.Text);
                MessageBox.Show("Name must not be number", "int parsing Error");     // use int.Parse method to check the input ., if it is,  show error message
                return;
            }
            catch {
                staffInformation01.StaffName = tbxName.Text;                         // utilize the parse method to handle the correct information.
            }


            try {
                staffInformation01.StaffID = int.Parse(tbxID.Text);                                          // check if it is int
            }
            catch {
                MessageBox.Show("ID file must only contain number values", "int parsing Error");     // not int, then show error , return
                return;
            }

            try
            {
                staffInformation01.StaffAnnualSalary = int.Parse(tbxAnnualSalary.Text);                       // check if it is int
            }
            catch {
                MessageBox.Show("Annual Salary must only contain number values", "int parsing Error");       // not int, then show error , return
                return;
            }

            staffInformation01.DateOfBirth = DateTime.Parse(tbxDateOfBirth.Text);
            staffInformation01.StaffEmail = tbxEmail.Text;
            staffInformation01.StaffAnnualSalary = int.Parse(tbxAnnualSalary.Text);

            staffInformation.Add(staffInformation01);                                                   // add the object into the list data
            fileManager.SaveStaffInformation(staffInformation, "StaffInformations.txt");                         //set back to txt file
            lbxStaffMembers.Items.Clear();
            lbxStaffMembers.Items.AddRange(staffInformation.ToArray());                                

        }

        public void btnDelete_Click(object sender, EventArgs e)
        {
            int index = lbxStaffMembers.SelectedIndex;                                                         // get the selected index
            FileManager fileManager = new FileManager();

            staffInformation = fileManager.LoadStaffInformation();
            staffInformation.RemoveAt(index);                                                                 //remove the item of the data

            fileManager.SaveStaffInformation(staffInformation, "StaffInformations.txt");                       //set back the data to txt file
            lbxStaffMembers.Items.Clear();
            lbxStaffMembers.Items.AddRange(staffInformation.ToArray());

        }

        public void btnSave_Click(object sender, EventArgs e)
        {

            try                                    //Add a Try/Catch block in case a staff member has not been selected from the search results list box
            {
                FileManager fm = new FileManager();                                                      //Create a File Manager object

                StaffInformation s = (StaffInformation)lbxStaffMembers.SelectedItem;                    //Get information to save

                string filenames = s.StaffName + ".txt";                                                   //Build File Name

                bool result = fm.SaveInFile(s,filenames);

                if (result == false)                                                                 //If/Else method
                {
                    MessageBox.Show("Error Saving Staff Information", "File IO Error");              //Message to show after save unsuccessful
                }
                else
                {
                    DialogResult dr = MessageBox.Show("View File?", "Save Success", MessageBoxButtons.YesNo);
                    
                    if (dr.Equals(DialogResult.Yes)) 
                    {
                        System.Diagnostics.Process.Start(filenames);                                 //User get to choose to see the saved file or not
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please select a staff", "Error");
            }
        }

        public void lbxSearchResults_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void btnUpdate_Click(object sender, EventArgs e)
        {
            staffInformation.Clear();                                                //clear the existing data 
            FileManager fileManager = new FileManager();                            //declare FileManager object
            int index = lbxStaffMembers.SelectedIndex;                             // get the selected index
            staffInformation = fileManager.LoadStaffInformation();                  // get the txt file data object

            StaffInformation staffInformation01 = new StaffInformation();          // declare a staffInformation object
            // update the object data
            staffInformation01.StaffName = tbxName.Text;    
            staffInformation01.StaffID = int.Parse(tbxID.Text);
            staffInformation01.DateOfBirth = DateTime.Parse(tbxDateOfBirth.Text);
            staffInformation01.StaffEmail = tbxEmail.Text;
            staffInformation01.StaffAnnualSalary = int.Parse(tbxAnnualSalary.Text);
            
            staffInformation.RemoveAt(index);                                           // remove the selected the data of the list
            staffInformation.Add(staffInformation01);                                      // add the updated data
            fileManager.SaveStaffInformation(staffInformation, "StaffInformations.txt");  // set back the data to txt file
            lbxStaffMembers.Items.Clear();                                                  // update UI
            lbxStaffMembers.Items.AddRange(staffInformation.ToArray());                // display the updated data in ui
        }

        public void lbxStaffMembers_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                StaffInformation s = (StaffInformation)lbxStaffMembers.SelectedItem;   // get the selected data from UI 

                //display each items of the object
                tbxName.Text = s.StaffName; 
                tbxID.Text = s.StaffID.ToString();
                tbxDateOfBirth.Text = s.DateOfBirth.ToShortDateString();
                tbxEmail.Text = s.StaffEmail;
                tbxAnnualSalary.Text = s.StaffAnnualSalary.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Error");
            }
        }
    }
}
