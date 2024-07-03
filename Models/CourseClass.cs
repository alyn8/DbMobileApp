using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbMyDemo.Models
{
    public class CourseClass
    {
        [PrimaryKey] 
        public int CourseID { get; set; }
        public string Name { get; set; }
    }
}
