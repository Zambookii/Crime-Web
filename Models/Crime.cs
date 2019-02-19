//
// One movie
//

namespace crimes.Models
{

  public class Crime
	{
	
		// data members with auto-generated getters and setters:
	    public int Area { get; set; }
		public string AreaName { get; set; }
	    public int IUCR { get; set; }
		public string PrimaryDesc { get; set; }
        public string SecondaryDesc { get; set; }
		public int NumOccured { get; set; }
		public string PercentTotal { get; set; }
		public string ArrestPercent { get; set; }
        public int Year { get; set; }
	
		// default constructor:
		public Crime()
		{ }
		
		// constructor:
		public Crime(int Area1, string AreaName1, int IUCR1, string PrimaryDesc1, string SecondaryDesc1, int NumOccured1, string PercentTotal1, string ArrestPercent1, int Year1)
		{
            Area = Area1;
            AreaName = AreaName1;
			IUCR = IUCR1;
			PrimaryDesc = PrimaryDesc1;
            SecondaryDesc = SecondaryDesc1;
			NumOccured = NumOccured1;
			PercentTotal = PercentTotal1;
			ArrestPercent = ArrestPercent1;
            Year = Year1;
		}
		
	}//class

}//namespace