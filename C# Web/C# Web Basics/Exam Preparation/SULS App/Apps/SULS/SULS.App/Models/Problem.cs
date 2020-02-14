namespace SULS.App.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Problem
    {
        public Problem(string name, int points)
        {
            this.Id = Guid.NewGuid().ToString();
            this.Name = name;
            this.Points = points;
            this.Submissions = new HashSet<Submission>();
        }
        public string Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        public int Points { get; set; }

        public ICollection<Submission> Submissions { get; set; }
    }
}
