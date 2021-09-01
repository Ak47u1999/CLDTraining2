using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CLDTraining2.Models
{
    public partial class WorkoutList
    {
        public string MuscleGroup { get; set; }
        public string ExerciseName { get; set; }
        public int? SetsNum { get; set; }
        public int? RepsNum { get; set; }
        public string Split { get; set; }
    }
}
