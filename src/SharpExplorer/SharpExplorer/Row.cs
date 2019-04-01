using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharpExplorer
{
    public class Row
    {
        public object Value { get; set; }
        public string FilterString { get; set; }
        public string[] Cells { get; set; }
        public Row(object value, string filterString, params string[] cells)
        {
            Value = value;
            FilterString = filterString?.ToLower();
            Cells = cells;
        }
    }
}
