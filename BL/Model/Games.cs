namespace BL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Games
    {
        [Key]
        public int GameID { get; set; }

        public int? Player_1_ID { get; set; }

        [Required]
        [StringLength(100)]
        public string GameLog { get; set; }

        public int? WINNER { get; set; }

        public DateTime? Date { get; set; }

        public virtual ICollection<PLAYERS> Courses { get; set; }

        public virtual PLAYERS PLAYERS { get; set; }
    }
}
