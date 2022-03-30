namespace DoAnWebBanDongHo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KHACHHANG")]
    public partial class KHACHHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KHACHHANG()
        {
            DONHANG = new HashSet<DONHANG>();
        }

        [Key]
        public int MAKH { get; set; }

        public int? MATK { get; set; }

        [StringLength(50)]
        public string TENKH { get; set; }

        [StringLength(50)]
        public string EMAIL { get; set; }

        [StringLength(12)]
        public string SDT { get; set; }

        [StringLength(3)]
        public string GIOITINH { get; set; }

        [StringLength(100)]
        public string DIACHI { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DONHANG> DONHANG { get; set; }

        public virtual TAIKHOAN TAIKHOAN { get; set; }
    }
}
