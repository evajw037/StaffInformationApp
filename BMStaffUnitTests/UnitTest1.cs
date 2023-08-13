using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using StaffMembers.BenchmarkApp;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Collections;

namespace BMStaffUnitTests
{
    [TestClass]
    public class StaffUnitTest
    {
        [TestMethod]
        public void TestStaffName()
        {
            StaffInformation s = new StaffInformation();
            s.StaffName = "Tom";
            Assert.AreEqual("Tom", s.StaffName);
        }//Test to ensure that StaffID returns the correct data.

        [TestMethod]
        public void TestStaffID()
        { 
            StaffInformation s = new StaffInformation();
            s.StaffID = 123;
            Assert.AreEqual(123, s.StaffID);
        }//Test to ensure that StaffID returns the correct data.

        [TestMethod]
        public void TestStaffDateofBirthday()
        { 
           StaffInformation s = new StaffInformation();
            DateTime date = DateTime.Parse("12/03/1998");
            s.DateOfBirth = date;
            Assert.AreEqual("12/03/1998 12:00:00 AM", s.DateOfBirth.ToString());
        }//Test to ensure that StaffDate of Birth returns the correct data.

        [TestMethod]
        public void TestStaffEmail()
        {
            StaffInformation s = new StaffInformation();
            s.StaffEmail = "eva@officer.company.ac.nz";
            Assert.AreEqual("eva@officer.company.ac.nz", s.StaffEmail);
        }//Test to ensure that StaffEmail returns the correct data.

        [TestMethod]
        public void StaffAnnualSalary() 
        {
             StaffInformation s = new StaffInformation();
             s.StaffAnnualSalary = 456;
             Assert.AreEqual(456, s.StaffAnnualSalary);
        }//Test to ensure that StaffAnnualSalary returns the correct data.

        [TestMethod]
        public void TestStaffInformationConstructor()
        {
            StaffInformation s = new StaffInformation();
            Assert.AreEqual("NA", s.StaffName, "Name Fail");
            Assert.AreEqual(0,s.StaffID, "ID Fail");
            Assert.AreEqual(DateTime.MinValue, s.DateOfBirth, "Date of Birth Fail");
            Assert.AreEqual("", s.StaffEmail, "Email Fail");
            Assert.AreEqual(0, s.StaffAnnualSalary, "Annual Salary Fail");
        }//Test to ensure that each class returns the correct information in the correct format.

        [TestMethod]
        public void TestStaffInformationToStringFormat()
        {
            StaffInformation s = new StaffInformation();
            s.StaffName = "Sonny";
            s.StaffID = 1;
            s.DateOfBirth = DateTime.Now;
            s.StaffEmail = "Sonny04@officer.company.ac.nz";
            s.StaffAnnualSalary = 2;

            Assert.AreEqual("Name: Sonny ID: 1 Date of Birth: "+ DateTime.Now + " Email: Sonny04@officer.company.ac.nz Annual Salary: 2", s.ToString());
        }//Test to ensure that selected staff information returns the correct information in the correct string format.
    }

    [TestClass]
    public class FilterUnitTests
    {
        [TestMethod]
        public void TestFilterSortAZ()
        {
            StaffInformation s1 = new StaffInformation();
            s1.StaffName = "s1";
            s1.StaffID = 1;
            s1.DateOfBirth = DateTime.Now;
            s1.StaffEmail = "eva1";
            s1.StaffAnnualSalary = 1;

            StaffInformation s2 = new StaffInformation();
            s2.StaffName = "s2";
            s2.StaffID = 2;
            s2.DateOfBirth = DateTime.Now;
            s2.StaffEmail = "eva2";
            s2.StaffAnnualSalary = 2;

            StaffInformation s3 = new StaffInformation();
            s3.StaffName = "s3";
            s3.StaffID = 3;
            s3.DateOfBirth = DateTime.Now;
            s3.StaffEmail = "eva3";
            s3.StaffAnnualSalary = 3;

            StaffInformation s4 = new StaffInformation();
            s4.StaffName = "s4";
            s4.StaffID = 4;
            s4.DateOfBirth = DateTime.Now;
            s4.StaffEmail = "eva4";
            s4.StaffAnnualSalary = 4;

            List<StaffInformation> sListExpected = new List<StaffInformation>();

            sListExpected.Add(s1);
            sListExpected.Add(s2);
            sListExpected.Add(s3);
            sListExpected.Add(s4);

            List<StaffInformation> sList = new List<StaffInformation>();

            sList.Add(s2);
            sList.Add(s4);
            sList.Add(s1);
            sList.Add(s3);

            Filter f = new Filter();
            sList = f.SortAZ(sList);

            CollectionAssert.AreEqual(sListExpected, sList);
        }//Test to ensure that sorting to A to Z returns in the correct order.

        [TestMethod]
        public void TestFilterSortZA()
        {
            StaffInformation s1 = new StaffInformation();
            s1.StaffName = "as1";
            s1.StaffID = 1;
            s1.DateOfBirth = DateTime.Now;
            s1.StaffEmail = "eva1";
            s1.StaffAnnualSalary = 1;

            StaffInformation s2 = new StaffInformation();
            s2.StaffName = "bs2";
            s2.StaffID = 2;
            s2.DateOfBirth = DateTime.Now;
            s2.StaffEmail = "eva2";
            s2.StaffAnnualSalary = 2;

            StaffInformation s3 = new StaffInformation();
            s3.StaffName = "cs3";
            s3.StaffID = 3;
            s3.DateOfBirth = DateTime.Now;
            s3.StaffEmail = "eva3";
            s3.StaffAnnualSalary = 3;

            StaffInformation s4 = new StaffInformation();
            s4.StaffName = "ds4";
            s4.StaffID = 4;
            s4.DateOfBirth = DateTime.Now;
            s4.StaffEmail = "eva4";
            s4.StaffAnnualSalary = 4;

            List<StaffInformation> sListExpected = new List<StaffInformation>();

            sListExpected.Add(s4);
            sListExpected.Add(s3);
            sListExpected.Add(s2);
            sListExpected.Add(s1);

            List<StaffInformation> sList = new List<StaffInformation>();

            sList.Add(s1);
            sList.Add(s2);
            sList.Add(s3);
            sList.Add(s4);

            Filter f = new Filter();
            sList = f.SortZA(sList);

            CollectionAssert.AreEqual(sListExpected, sList);
        }//Test to ensure that sorting to Z to A returns in the correct order.

        [TestMethod]
        public void TestFilterSearch()
        {
            StaffInformation s1 = new StaffInformation();
            s1.StaffName = "Tom";

            StaffInformation s2 = new StaffInformation();
            s2.StaffName = "Sonny";

            StaffInformation s3 = new StaffInformation();
            s3.StaffName = "Jo";

            StaffInformation s4 = new StaffInformation();
            s4.StaffName = "Anna";

            List<StaffInformation> slist = new List<StaffInformation>();

            slist.Add(s1);     
            slist.Add(s2);
            slist.Add(s3);
            slist.Add(s4);

            Filter f = new Filter();

            List<StaffInformation> searchResults = new List<StaffInformation>();
            searchResults = f.Search(slist, "o");

            CollectionAssert.Contains(searchResults, s1);
            CollectionAssert.Contains(searchResults, s2);
            CollectionAssert.Contains(searchResults, s3);
            CollectionAssert.DoesNotContain(searchResults, s4);
        }//Test to ensure that searching staffinformation returns the correct information.
    }
}
