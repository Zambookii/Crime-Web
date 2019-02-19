using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Threading.Tasks;  
using Microsoft.AspNetCore.Mvc;  
using Microsoft.AspNetCore.Mvc.RazorPages;  
using System.Data;
  
namespace crimes.Pages  
{  
    public class AreaInfoModel : PageModel  
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
SELECT Areas.Area, Areas.AreaName, Count(Crimes.Area) AS NumOccured
FROM Crimes
LEFT JOIN Areas ON Crimes.Area = Areas.Area
GROUP BY Areas.AreaName, Areas.Area
ORDER BY Areas.AreaName ASC;
	");
    
                        string sql2 = string.Format(@"
                        SELECT COUNT(*) AS TotalCrimes
                        from Crimes
                        ");

						DataSet ds = DataAccessTier.DB.ExecuteNonScalarQuery(sql);
                        DataSet ds2 = DataAccessTier.DB.ExecuteNonScalarQuery(sql2);
                        
                        double TotalCrimes = Convert.ToDouble(ds2.Tables["TABLE"].Rows[0]["TotalCrimes"].ToString());

						foreach (DataRow row in ds.Tables["TABLE"].Rows)
						{
							Models.Crime c = new Models.Crime();
                            
                            double NumOccured = Convert.ToDouble(row["NumOccured"]);

							c.Area = Convert.ToInt32(row["Area"]);
							c.AreaName = Convert.ToString(row["AreaName"]);
							c.NumOccured = Convert.ToInt32(row["NumOccured"]);
                            c.PercentTotal = Convert.ToDouble((NumOccured/TotalCrimes)*100).ToString("0.00");

							crimes.Add(c);
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