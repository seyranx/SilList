using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SO.Utility.Attributes
{
   [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
public class TemplatesVisibilityAttribute : Attribute, IMetadataAware
{
    public bool ShowForDisplay { get; set; }

    public bool ShowForEdit { get; set; }

    public TemplatesVisibilityAttribute()
    {
        this.ShowForDisplay = true;
        this.ShowForEdit = true;
    }

    public void OnMetadataCreated(ModelMetadata metadata)
    {
        if (metadata == null)
        {
            throw new ArgumentNullException("metadata");
        }

       // metadata.IsReadOnly
        metadata.ShowForDisplay = this.ShowForDisplay;
        metadata.ShowForEdit = this.ShowForEdit;
       
    }

}
}
