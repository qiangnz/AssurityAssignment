using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssurityAssignment
{
    public class CriteriaContents
    {
        public string Name { get; set; }

        public bool CanRelist { get; set; }

        public _Promotions[] Promotions { get; set; }

    }

    public class _Promotions
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
