//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DomainEntities.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblQuote
    {
        public int Quote_ID { get; set; }
        public string Quote_Type { get; set; }
        public string Contact_Name { get; set; }
        public string Task_Type { get; set; }
        public Nullable<System.DateTime> DueDate { get; set; }
    }
}
