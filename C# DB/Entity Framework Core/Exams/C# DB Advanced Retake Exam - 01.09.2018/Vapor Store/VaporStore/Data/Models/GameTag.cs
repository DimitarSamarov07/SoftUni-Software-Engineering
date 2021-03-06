﻿namespace VaporStore.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class GameTag
    {
        [Required]
        [ForeignKey(nameof(Game))]
        public int GameId { get; set; }

        [Required]
        [ForeignKey(nameof(Tag))]
        public int TagId { get; set; }

        public Game Game { get; set; }

        public Tag Tag { get; set; }
    }
}
