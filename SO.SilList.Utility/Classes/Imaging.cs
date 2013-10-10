using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SO.SilList.Utility.Classes
{
    public class ImageCheckBoxInfo
    {
        public ImageCheckBoxInfo()
        {
        }
        public ImageCheckBoxInfo(string imgIdStr, string imgUrlStr, bool isChecked = true)
        {
            this.imageIdStr = imgIdStr;
            this.imageUrlStr = imgUrlStr;
            this.imageIsChecked = isChecked;
        }
        public string imageIdStr { get; set; }
        public string imageUrlStr { get; set; }
        public bool imageIsChecked { get; set; }
    };
}
