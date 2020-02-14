namespace SULS.App.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Submission
    {
        public Submission()
        {
            Id = Guid.NewGuid().ToString();
        }
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
