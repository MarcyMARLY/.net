using System;
using System.Collections.Generic;
using System.Text;

namespace Week1Lab.Model
{
    class TeaCollection
    {
        public List<Tea> TeaCollectionList { get; set; }
        public TeaCollection()
        {
            TeaCollectionList = new List<Tea>();
        }
    }
}
