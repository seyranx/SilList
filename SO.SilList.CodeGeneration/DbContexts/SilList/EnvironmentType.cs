//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SO.SilList.CodeGeneration.DbContexts.SilList
{
    using System;
    using System.Collections.Generic;
    
    public partial class EnvironmentType
    {
        public EnvironmentType()
        {
            this.SettingTypes = new HashSet<SettingType>();
        }
    
        public int EnvironmentTypeId { get; set; }
        public string name { get; set; }
        public byte[] url { get; set; }
        public string description { get; set; }
        public Nullable<int> createdBy { get; set; }
        public Nullable<int> modifiedBy { get; set; }
        public System.DateTime modified { get; set; }
        public System.DateTime created { get; set; }
        public bool isActive { get; set; }
    
        public virtual ICollection<SettingType> SettingTypes { get; set; }
    }
}