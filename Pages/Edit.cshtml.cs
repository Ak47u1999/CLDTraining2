using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CLDTraining2.Models;

namespace CLDTraining2.Pages
{
    public class EditModel : PageModel
    {
        private readonly CLDTraining2.Models.workoutsContext _context;

        public EditModel(CLDTraining2.Models.workoutsContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(WorkoutList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkoutListExists(WorkoutList.MuscleGroup))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool WorkoutListExists(string id)
        {
            return _context.WorkoutList.Any(e => e.MuscleGroup == id);
        }
    }
}
