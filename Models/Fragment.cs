//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Memcomb.Models
{
    using System;
    using System.Collections.Generic;
    using System.Web;

    public partial class Fragment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Fragment()
        {
            this.Connections = new HashSet<Connection>();
        }
    
        public int Fragment_ID { get; set; }
        public int Memory_ID { get; set; }
        public Nullable<System.DateTime> Date_Posted { get; set; }
        public Nullable<System.DateTime> Fragment_Date { get; set; }
        public string Fragment_Location { get; set; }
        public string Memory_Description { get; set; }
        public string Fragment_Data { get; set; }
        public bool Is_Highlight { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Connection> Connections { get; set; }
        public virtual Memory Memory { get; set; }

        public string[] getImage { get; set; }
        public HttpPostedFileBase getImagePath { get; set; }
    }
}
