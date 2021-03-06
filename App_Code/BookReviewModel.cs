﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

public partial class CheckinLog
{
    public int CheckInLogKey { get; set; }
    public int ReviewerKey { get; set; }
    public System.DateTime CheckinDateTime { get; set; }

    public virtual Reviewer Reviewer { get; set; }
}

public partial class Reviewer
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Reviewer()
    {
        this.CheckinLogs = new HashSet<CheckinLog>();
    }

    public int ReviewerKey { get; set; }
    public string ReviewerUserName { get; set; }
    public string ReviewerFirstName { get; set; }
    public string ReviewerLastName { get; set; }
    public string ReviewerEmail { get; set; }
    public int ReviewerKeyCode { get; set; }
    public string ReviewPlainPassword { get; set; }
    public byte[] ReviewerHashedPass { get; set; }
    public Nullable<System.DateTime> ReviewerDateEntered { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<CheckinLog> CheckinLogs { get; set; }
}
