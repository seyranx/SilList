using SO.SilList.Manager.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SO.SilList.Manager.Models.ViewModels
{
    public class CarVm
    {
        public CarVm()
        {

        }
        public CarVm(CarVo input)
        {
            car = input;
            imagesToRemove = new List<int>();
            imagesToRemove.Add(-2); /// debug value
        }
        public CarVo car { get; set; }
        public List<int> imagesToRemove { get; set; }
    }
}
