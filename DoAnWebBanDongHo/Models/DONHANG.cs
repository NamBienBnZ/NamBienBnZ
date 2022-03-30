namespace DoAnWebBanDongHo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DONHANG")]
    public partial class DONHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DONHANG()
        {
            CHITIETDONHANG = new HashSet<CHITIETDONHANG>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MADH { get; set; }

        public int? MAKH { get; set; }

        [StringLength(20)]
        public string TRANGTHAI { get; set; }

        [Column(TypeName = "ntext")]
        public string DIACHIGIAO { get; set; }

        [StringLength(12)]
        public string SDT { get; set; }

        public DateTime? NGAYDAT { get; set; }

        public DateTime? NGAYGIAO { get; set; }

        [StringLength(10)]
        public string MOTA { get; set; }

        public double? TONGTIEN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETDONHANG> CHITIETDONHANG { get; set; }

        public virtual KHACHHANG KHACHHANG { get; set; }
    }
}
