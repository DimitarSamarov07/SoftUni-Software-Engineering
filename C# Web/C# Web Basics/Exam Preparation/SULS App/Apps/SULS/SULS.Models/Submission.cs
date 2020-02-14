using System;
using System.Collections.Generic;
using System.Text;

namespace SULS.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Submission
    {
        public string Id { get; set; }

        [Required]
        [MaxLength(800)]
        public string Code { get; set; }

        [Required]
        [MaxLength(300)]
        public int AchievedResult { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public string ProblemId { get; set; }

        public Problem Problem { get; set; }

        [Required]
        public string UserId { get; set; }

        public User User { get; set; }
    }
}
