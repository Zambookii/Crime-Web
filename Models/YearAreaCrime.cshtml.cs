using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Threading.Tasks;  
using Microsoft.AspNetCore.Mvc;  
using Microsoft.AspNetCore.Mvc.RazorPages;  
using System.Data;
  
namespace crimes.Pages  
{  
    public class YearAreaCrimeModel : PageModel  
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
SELECT Areas.Area, Areas.AreaName, Count(*) AS NumCrimes, Crimes.Year
FROM Crimes
FULL OUTER JOIN Areas ON Crimes.Area = Areas.Area
WHERE Areas.Area != 0
GROUP BY Crimes.Year, Areas.Area, Areas.AreaName
ORDER BY Crimes.Year DESC, NumCrimes DESC;
	");


						DataSet ds = DataAccessTier.DB.ExecuteNonScalarQuery(sql);

						foreach (DataRow row in ds.Tables["TABLE"].Rows)
						{
							Models.Crime c = new Models.Crime();

							c.Area = Convert.ToInt32(row["Area"]);
							c.AreaName = Convert.ToString(row["AreaName"]);
							c.NumOccured = Convert.ToInt32(row["NumCrimes"]);
                            c.Year = Convert.ToInt32(row["Year"]);

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