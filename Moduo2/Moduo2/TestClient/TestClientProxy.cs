﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;


using Common;namespace TestClient
{  
    
    public class TestClientProxy : ChannelFactory<IWcf>, IWcf, IDisposable
    {
         IWcf factory;
         List<string> kompanije = new List<string>();


         public TestClientProxy(NetTcpBinding binding, EndpointAddress address)
            : base(binding, address)
        {
            factory = this.CreateChannel();
        }

        public bool PosaljiZahtev(string naziv)
        {
            try
            {
                factory.PosaljiZahtev(naziv);
                Console.WriteLine("test");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while trying to Login(). {0}", e.Message);
            }
            return true;

        }


        public List<string> GetOCompany()
        {
            try
            {
               
                kompanije= factory.GetOCompany();
                for (int i = 0; i < kompanije.Count;i++ )
                    Console.WriteLine(kompanije[i]+"\n");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while trying to Login(). {0}", e.Message);
            }
            return kompanije;
           
        }
    }
}
