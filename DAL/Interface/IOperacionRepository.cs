﻿using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IOperacionRepository
    {
        void Add(Operacion operacion);
        IEnumerable<Operacion> GetAll();
    }
}
