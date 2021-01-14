using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace OTA.Pages
{
    public class IndexPageModel : PageModel
    {
        public string DayName 
        { 
            get => DateTime.Now.ToString("dddd");
            private set {}
        }
        
    }
    
}