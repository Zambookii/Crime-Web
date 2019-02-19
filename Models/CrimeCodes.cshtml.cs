using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Threading.Tasks;  
using Microsoft.AspNetCore.Mvc;  
using Microsoft.AspNetCore.Mvc.RazorPages;  
using System.Data;
  
namespace crimes.Pages  
{  
    public class CrimeCodesModel : PageModel  
    {  
        public List<Models.Crime> CrimeList { get; set; }
				public Exception EX { get; set; }
  
        public void OnGet()  
        {  
				  List<Models.Crime> crimes = new List<Models.Crime>();
					
					// clear exception:
					EX = null;
					
					try
					{
						string sql = string.Format(@"
SELECT Codes.PrimaryDesc, Codes.SecondaryDesc, Count(Crimes.IUCR) AS NumOccured
FROM Crimes
FULL OUTER JOIN Codes ON Crimes.IUCR = Codes.IUCR
GROUP BY Codes.PrimaryDesc, Codes.SecondaryDesc, Crimes.IUCR
ORDER BY Codes.PrimaryDesc ASC;
	");
    
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

							c.PrimaryDesc = Convert.ToString(row["PrimaryDesc"]);
							c.SecondaryDesc = Convert.ToString(row["SecondaryDesc"]);
							c.PercentTotal = Convert.ToDouble((NumOccured/TotalCrimes)*100).ToString("0.00");

							crimes.Add(c);
						}
                        }
					}
					catch(Exception ex)
					{
					  EX = ex;
					}
					finally
					{
            CrimeList = crimes;  
				  }
        }  
				
    }//class
}//namespace