using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DailyDealWeb.Pages
{
    public class ShareModel : PageModel
    {
        public void OnGet()
        {
            Response.Redirect("https://www.facebook.com/sharer/sharer.php?u=https%3A//heimkauptilbod.azurewebsites.net/");
        }

    }
}