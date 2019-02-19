using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Threading.Tasks;  
using Microsoft.AspNetCore.Mvc;  
using Microsoft.AspNetCore.Mvc.RazorPages;  
using System.Data;
  
namespace crimes.Pages  
{  
    public class CrimeInfoModel : PageModel  
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
SELECT TOP 10 Areas.Area, Areas.AreaName, Crimes.IUCR, Codes.PrimaryDesc, Codes.SecondaryDesc, Count(Crimes.IUCR) AS NumOccured,
(SUM(CONVERT(float,Arrested))/COUNT(*)) AS ArrestPercent
FROM Crimes
LEFT JOIN Codes ON Crimes.IUCR = Codes.IUCR
LEFT JOIN Areas ON Crimes.Area = Areas.Area
WHERE Crimes.Area = {0}
GROUP BY Areas.Area, Areas.AreaName, Crimes.IUCR, Codes.PrimaryDesc, Codes.SecondaryDesc
ORDER BY NumOccured DESC;
	", id);
							}
							else
							{
								// lookup movie(s) by partial name match:
								input = input.Replace("'", "''");

								sql = string.Format(@"
SELECT TOP 10 Areas.Area, Areas.AreaName, Crimes.IUCR, Codes.PrimaryDesc, Codes.SecondaryDesc, Count(Crimes.IUCR) AS NumOccured,
(SUM(CONVERT(float,Arrested))/COUNT(*)) AS ArrestPercent
FROM Crimes
LEFT JOIN Codes ON Crimes.IUCR = Codes.IUCR
LEFT JOIN Areas ON Crimes.Area = Areas.Area
WHERE AreaName LIKE '%{0}%'
GROUP BY Areas.Area, Areas.AreaName, Crimes.IUCR, Codes.PrimaryDesc, Codes.SecondaryDesc
ORDER BY NumOccured DESC;
	", input);
							}
                            
                        string sql2 = string.Format(@"
                        SELECT COUNT(*) AS TotalCrimes
                        from Crimes
                        ");

							DataSet ds = DataAccessTier.DB.ExecuteNonScalarQuery(sql);
                            DataSet ds2 = DataAccessTier.DB.ExecuteNonScalarQuery(sql2);

							foreach (DataRow row in ds.Tables["TABLE"].Rows)
							{
                            foreach (DataRow row2 in ds2.Tables["TABLE"].Rows)
                            {
                            
                            Models.Crime c = new Models.Crime();
                            
                            
                            double NumOccured = Convert.ToDouble(row["NumOccured"]);
                            double TotalCrimes = Convert.ToDouble(row2["TotalCrimes"]);
                            double ArrestPercent = Convert.ToDouble(row["ArrestPercent"]);

                            c.Area = Convert.ToInt32(row["Area"]);
                            c.AreaName = Convert.ToString(row["AreaName"]);
							c.IUCR = Convert.ToInt32(row["IUCR"]);
							c.PrimaryDesc = Convert.ToString(row["PrimaryDesc"]);
							c.SecondaryDesc = Convert.ToString(row["SecondaryDesc"]);
							c.NumOccured = Convert.ToInt32(row["NumOccured"]);
							c.PercentTotal = Convert.ToDouble((NumOccured/TotalCrimes)*100).ToString("0.00");
                            c.ArrestPercent = Convert.ToDouble((ArrestPercent)*100.0).ToString("0.00");
							crimes.Add(c);

							}
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