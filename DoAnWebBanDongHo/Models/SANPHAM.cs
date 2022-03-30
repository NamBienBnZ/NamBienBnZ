namespace DoAnWebBanDongHo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SANPHAM")]
    public partial class SANPHAM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SANPHAM()
        {
            CHITIETDONHANG = new HashSet<CHITIETDONHANG>();
        }

        [Key]
        public int MASP { get; set; }

        [StringLength(50)]
        public string TENSP { get; set; }

        [StringLength(50)]
        public string HINH { get; set; }

        [StringLength(100)]
        public string MOTA { get; set; }

        public int? MATH { get; set; }

        public int? SOLUONG { get; set; }

        [StringLength(7)]
        public string MALOAISP { get; set; }

        public double? DONGIA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETDONHANG> CHITIETDONHANG { get; set; }

        public virtual LOAISANPHAM LOAISANPHAM { get; set; }

        public virtual THUONGHIEU THUONGHIEU { get; set; }
    }
}
