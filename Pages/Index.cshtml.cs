using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CLDTraining2.Models;

namespace CLDTraining2.Pages
{
    public class IndexModel : PageModel
    {
        private readonly CLDTraining2.Models.workoutsContext _context;

        public IndexModel(CLDTraining2.Models.workoutsContext context)
        {
            _context = context;
        }

        public IList<WorkoutList> WorkoutList { get;set; }

        public async Task OnGetAsync()
        {
            WorkoutList = await _context.WorkoutList.ToListAsync();
        }
    }
}
