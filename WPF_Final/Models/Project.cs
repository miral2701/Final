using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Final.Models
{
    class Project
    {
        public Project()
        {
            Tasks = new ObservableCollection<MyTask>();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public ObservableCollection<MyTask> Tasks { get; set; }
        public override string ToString()
        {
            return Name +"Discription-> "+Description;
        }
    }
}
