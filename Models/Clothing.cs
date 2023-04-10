namespace Web_Ban_Quan_Ao.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Clothing")]
    public partial class Clothing
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Clothing()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        [Key]
        public int id_clothing { get; set; }

        [Column("_name")]
        [StringLength(50)]
        public string C_name { get; set; }

        [StringLength(50)]
        public string manufacture { get; set; }

        [StringLength(255)]
        public string decription { get; set; }

        [StringLength(150)]
        public string images { get; set; }

        public int? category_id { get; set; }

        public decimal? price { get; set; }

        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
