//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace project_managemnt.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class member
    {
        public int uid { get; set; }
        public int pid { get; set; }
        public int mid { get; set; }
    
        public virtual project project { get; set; }
        public virtual user user { get; set; }
    }
}