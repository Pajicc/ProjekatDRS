﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using SRV1.Access;

namespace SRV1
{
    public class CompanyService : ICompanyService
    {
        public bool Login(string username, string pass)
        {
            Console.WriteLine("Username: "+username+"\nPassword: "+pass);

            DB.Instance.AddUser(new User
            {
                Username = username,
                Password = pass,
            });

            return true;

        }

    }
}
