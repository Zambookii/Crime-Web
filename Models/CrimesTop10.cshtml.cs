using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Threading.Tasks;  
using Microsoft.AspNetCore.Mvc;  
using Microsoft.AspNetCore.Mvc.RazorPages;  
using System.Data;
  
namespace crimes.Pages  
{  
    public class CrimesTop10Model : PageModel  
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
SELECT TOP 10 Crimes.IUCR, Codes.PrimaryDesc, Codes.SecondaryDesc, Count(Crimes.IUCR) AS NumOccured,
(SUM(CONVERT(float,Arrested))/COUNT(*)) AS ArrestPercent
FROM Crimes
INNER JOIN Codes ON Crimes.IUCR = Codes.IUCR
GROUP BY Crimes.IUCR, Codes.PrimaryDesc, Codes.SecondaryDesc
ORDER BY NumOccured DESC;
	");
    
                        string sql2 = string.Format(@"
                        SELECT COUNT(*) AS TotalCrimes
                        from Crimes
                        ");

						DataSet ds = DataAccessTier.DB.ExecuteNonScalarQuery(sql);
                        DataSet ds2 = DataAccessTier.DB.ExecuteNonScalarQuery(sql2);

						foreach (DataRow row in ds.Tables["TABLE"].Rows)
						{
                            foreach(DataRow row2 in ds2.Tables["TABLE"].Rows)
                            {
							Models.Crime c = new Models.Crime();
                            
                            double NumOccured = Convert.ToDouble(row["NumOccured"]);
                            double TotalCrimes = Convert.ToDouble(row2["TotalCrimes"]);
                            double ArrestPercent = Convert.ToDouble(row["ArrestPercent"]);

							c.IUCR = Convert.ToInt32(row["IUCR"]);
							c.PrimaryDesc = Convert.ToString(row["PrimaryDesc"]);
							c.SecondaryDesc = Convert.ToString(row["SecondaryDesc"]);
							c.NumOccured = Convert.ToInt32(row["NumOccured"]);
							c.PercentTotal = Convert.ToDouble((NumOccured/TotalCrimes)*100).ToString("0.00");
                            c.ArrestPercent = Convert.ToDouble((ArrestPercent)*100).ToString("0.00");
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