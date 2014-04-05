using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SO.SilList.Manager.Models.ViewModels
{
    public class DropDownVm
    {
        public DropDownVm();

        public string dataTextField { get; set; }
        public string dataValueField { get; set; }
        public object htmlAttributes { get; }
        public bool isMultiple { get; set; }
        public IList items { get; set; }
        public string optionLabel { get; set; }
        public string propertyName { get; set; }
        public object selectedValue { get; set; }
    }
}


