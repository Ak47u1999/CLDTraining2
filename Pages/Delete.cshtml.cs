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
    public class DeleteModel : PageModel
    {
        private readonly CLDTraining2.Models.workoutsContext _context;

        public DeleteModel(CLDTraining2.Models.workoutsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public WorkoutList WorkoutList { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            WorkoutList = await _context.WorkoutList.FirstOrDefaultAsync(m => m.MuscleGroup == id);

            if (WorkoutList == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            WorkoutList = await _context.WorkoutList.FindAsync(id);

            if (WorkoutList != null)
            {
                _context.WorkoutList.Remove(WorkoutList);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
