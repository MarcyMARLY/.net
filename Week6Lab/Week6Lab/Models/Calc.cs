using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Week6Lab.Models
{
    public enum Operation
    {
        Addition = '+',
        Substraction = '-',
        Multiplication = '*',
        Division = '/'
    }
    public class Calc
    {
        public decimal Number1 { get; set; }
        public decimal Number2 { get; set; }
        public Operation operationType { get; set; }
        public decimal Result { get; set; }
    }
}
