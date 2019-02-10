namespace BL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Cards
    {
        [Key]
        public int CardID { get; set; }

        [StringLength(20)]
        public string CardName { get; set; }
       
        public int CardValue { get; set; }

        [StringLength(20)]
        public string CardSuit { get; set; }

        public byte[] Image { get; set; }
    }

   

}
