namespace BFBApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Transactions
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Display(Name = "Цена")]
        public decimal Price { get; set; }

        [Display(Name = "Объем")]
        public int Amount { get; set; }

        [Display(Name = "Дата и время")]
        public DateTime DateTime { get; set; }

        public int participant_new_Id { get; set; }

        public int participant_old_Id { get; set; }

        public int currency_Id { get; set; }

        public virtual Currencies Currencies { get; set; }

        public virtual Participants Participants { get; set; }

        public virtual Participants Participants1 { get; set; }
    }
}
