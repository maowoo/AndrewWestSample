using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAssemblySample.Shared
{
    public class EditDto :ChildEditDto
    {
        public void UpdateChildData(ChildEditDto dto)
        {
            ChildNumber1=dto.ChildNumber1;
            ChildString1=dto.ChildString1;
            ChildTitle=dto.ChildTitle;
        }
        public int ParentNumber1 { get; set; }
        public int ParentNumber2 { get; set; }
      
        public string ParentString1 { get; set; }
       
        public string ParentTitle { get; set; }
    }
}
