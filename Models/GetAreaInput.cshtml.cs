using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Threading.Tasks;  
using Microsoft.AspNetCore.Mvc;  
using Microsoft.AspNetCore.Mvc.RazorPages;
  
namespace crimes.Pages  
{  
    public class GetAreaInputModel : PageModel  
    {  
		  public string Input { get; set; }
			
      public void OnGet()  
      {  
				// no data needed for initial view:
		  }
			
    }//class  
}//namespace