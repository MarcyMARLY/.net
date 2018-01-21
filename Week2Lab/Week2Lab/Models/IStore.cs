using System;
using System.Collections.Generic;
using System.Text;

namespace Week2Lab.Models
{
    interface IStore<T>
    {
        string Path { get; set; }
        List<T> GetCollection();

        T ConvertItem(string item);
    }
}
