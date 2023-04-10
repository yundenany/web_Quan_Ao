namespace Web_Ban_Quan_Ao.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderDetail")]
    public partial class OrderDetail
    {
        [Key]
        [Column(Order = 0)]
        public int id_clothing { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OrderNo { get; set; }

        public decimal? Price { get; set; }

        public int? Quantity { get; set; }

        public virtual Clothing Clothing { get; set; }

        public virtual Order Order { get; set; }
    }
}
