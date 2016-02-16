//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BandAppWeb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public partial class Band
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Band()
        {
            this.Musician = new HashSet<Musician>();
        }

        public int idBand { get; set; }

        [Required]
        [Display(Name = "Nome")]
        [StringLength(50)]
        public string name { get; set; }

        [Required]
        [Display(Name = "Data de funda��o")]
        [DataType(DataType.Date)]
        public System.DateTime foundationDate { get; set; }

        public int fk_style { get; set; }

        public virtual Style Style { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Musician> Musician { get; set; }
    }
}
