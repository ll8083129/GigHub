//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GigHub
{
    using System;
    using System.Collections.Generic;
    
    public partial class Notifications
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Notifications()
        {
            this.UserNotifications = new HashSet<UserNotifications>();
        }
    
        public int Id { get; set; }
        public System.DateTime DateTime { get; set; }
        public int NotificationType { get; set; }
        public Nullable<System.DateTime> OriginalDateTime { get; set; }
        public string OriginalVenue { get; set; }
        public int Gig_Id { get; set; }
    
        public virtual Gigs Gigs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserNotifications> UserNotifications { get; set; }
    }
}
