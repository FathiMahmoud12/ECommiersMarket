//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ECommiersMarket.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class InvoDet
    {
        public int ID { get; set; }
        public Nullable<int> invoID { get; set; }
        public Nullable<int> iteamID { get; set; }
        public string IteamName { get; set; }
        public Nullable<int> IeamQnt { get; set; }
        public Nullable<int> IteamPrice { get; set; }
    
        public virtual Invo Invo { get; set; }
    }
}
