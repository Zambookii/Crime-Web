using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Threading.Tasks;  
using Microsoft.AspNetCore.Mvc;  
using Microsoft.AspNetCore.Mvc.RazorPages;  
using System.Data;
  
namespace crimes.Pages  
{  
    public class Top20CrimeAreaModel : PageModel  
    {  
				public List<Models.Crime> CrimeList { get; set; }
				public string Input { get; set; }
				public int NumAreas { get; set; }
				public Exception EX { get; set; }
  
        public void OnGet(string input)  
        {  
				  List<Models.Crime> crimes = new List<Models.Crime>();
					
					// make input available to web page:
					Input = input;
					
					// clear exception:
					EX = null;
			
					try
					{
						//
						// Do we have an input argument?  If so, we do a lookup:
						//
						if (input == null)
						{
							//
							// there's no page argument, perhaps user surfed to the page directly?  
							// In this case, nothing to do.
							//
						}
						else  
						{
							// 
							// Lookup movie(s) based on input, which could be id or a partial name:
							// 
							int id;
							string sql;
							if (System.Int32.TryParse(input, out id))
							{
								// lookup movie by area id:
								sql = string.Format(@"
SELECT TOP 20 Areas.Area, Areas.AreaName, Crimes.Year, Count(*) AS NumCrimes
FROM Crimes
LEFT JOIN Areas ON Crimes.Area = Areas.Area
WHERE Crimes.Year = {0}
AND Areas.Area != 0
GROUP BY Areas.Area, Areas.AreaName, Crimes.Year
ORDER BY NumCrimes DESC;
	", id);
							}
							else
							{
								// lookup movie(s) by partial name match:
								input = input.Replace("'", "''");

								sql = string.Format(@"
SELECT TOP 20 Areas.Area, Areas.AreaName, Crimes.Year, Count(*) AS NumCrimes
FROM Crimes
LEFT JOIN Areas ON Crimes.Area = Areas.Area
WHERE Crimes.Year LIKE '%{0}%'
AND Areas.Area != 0
GROUP BY Areas.Area, Areas.AreaName, Crimes.Year
ORDER BY NumCrimes DESC;
	", input);
    
    EX = new Exception("Please enter a year and not a string!");
							}
                            
                       

							DataSet ds = DataAccessTier.DB.ExecuteNonScalarQuery(sql);
                            

							foreach (DataRow row in ds.Tables["TABLE"].Rows)
							{
                            
                            
                            Models.Crime c = new Models.Crime();


                            c.Area = Convert.ToInt32(row["Area"]);
                            c.AreaName = Convert.ToString(row["AreaName"]);
							c.Year = Convert.ToInt32(row["Year"]);;
							c.NumOccured = Convert.ToInt32(row["NumCrimes"]);
					
							crimes.Add(c);

							
                            }
						}//else
					}
					catch(Exception ex)
					{
					  EX = ex;
					}
					finally
					{
					  CrimeList = crimes;
					  NumAreas = crimes.Count;
				  }
				}
			
    }//class  
}//namespace