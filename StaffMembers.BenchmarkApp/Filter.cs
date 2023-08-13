using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffMembers.BenchmarkApp
{
    public class Filter
    {
        public List<StaffInformation> SortAZ(List<StaffInformation> sList)               //Add SortAZ method
        { 
           sList = sList.OrderBy(x => x.StaffName).ToList();                            //uses a LINQ lambda expression
            return sList;
        }



        public List<StaffInformation> SortZA(List<StaffInformation> sList)                //Add SortZA method
        { 
          sList = (from x in sList orderby x.StaffName descending select x).ToList();     //uses a LINQ query expression
            return sList;
        }



        public List<StaffInformation> Search(List<StaffInformation> sList, string term)      //Add Search method
        { 
            List<StaffInformation> results = new List<StaffInformation>();                    

            foreach (StaffInformation s in sList)                                           //uses a standard foreach search loop
            {
                if (s.StaffName.ToLower().Contains(term.ToLower()))                        //ToLower() statements make the search case insensitive
                { 
                    results.Add(s);
                }
            }
            return results;      
        }
    }
}
