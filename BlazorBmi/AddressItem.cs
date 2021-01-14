using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorBmi
{
    public class AddressItem
    {
        public string name { get; set; }
        public int age { get; set; }
        public string zipcode { get; set; }
        public string telephone { get; set; }
        public int prefectureId { get; set; } = 13;
    }
}
