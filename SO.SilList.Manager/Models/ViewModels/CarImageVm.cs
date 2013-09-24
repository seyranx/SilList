using SO.SilList.Manager.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Will be used in Care Create/Edit to assist in image uploading

namespace SO.SilList.Manager.Models.ViewModels
{
    public class CarImageVm
    {
        public CarVo car { get; set; }
        public string imageLocalPath1 { get; set; }
        public string imageLocalPath2 { get; set; }
    }
}
