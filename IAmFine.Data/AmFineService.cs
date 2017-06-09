﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IAmFine.Data;

namespace IAmFine.Data
{
    public class AmFineService
    {
        private AmFineContext db = new AmFineContext();


        public List<User> GetEmployees()
        {
            return db.Users.ToList();
        }
    }
}