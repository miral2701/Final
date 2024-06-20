using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Final.Models
{
    class MyTask
    {
        public string Name { get; set; }    
        public string Description { get; set; }
        public string Priority { get; set; }
        public bool IsCompleted { get; set; }

        public override string ToString()
        {
            return Name+"Description->"+Description+" Priority->"+Priority;
        }
    }
}
