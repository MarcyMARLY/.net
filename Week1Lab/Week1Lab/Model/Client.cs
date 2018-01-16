using System;
using System.Collections.Generic;
using System.Text;

namespace Week1Lab.Model
{
    class Client
    {
        private static int ID = 1;
        private int clientId;
        public double balance { get; set; }

        public List<Order> Orders = new List<Order>();

        public Client()
        {
            clientId = ID++;
        }
        public int GetClientID()
        {
            return clientId;
        }
        public void SetClientId(int newId)
        {
            clientId = newId;
        }

    }
}
