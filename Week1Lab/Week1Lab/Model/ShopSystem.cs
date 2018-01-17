using System;
using System.Collections.Generic;
using System.Text;

namespace Week1Lab.Model
{
    class ShopSystem
    {
        public List<Client> Clients { get; set; }

        public ShopSystem()
        {
            Clients = new List<Client>();
        }

    }
}
