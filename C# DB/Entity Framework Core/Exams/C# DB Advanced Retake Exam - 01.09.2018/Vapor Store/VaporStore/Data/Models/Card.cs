namespace VaporStore.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Enums;

    public class Card
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]{4} [0-9]{4} [0-9]{4} [0-9]{4}$")]
        public string Number { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(3)]
        public string Cvc { get; set; }

        [Required]
        public CardType Type { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }

        public User User { get; set; }

        public ICollection<Purchase> Purchases { get; set; }
            = new HashSet<Purchase>();
    }
}
