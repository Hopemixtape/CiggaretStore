﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Domain.Entities;

namespace Store.Domain.Abstract
{
    public interface IWareRepository
    {
        IEnumerable<Ware> Wares { get; }
        void SaveWare(Ware ware);
        Ware DeleteWare(int wareId);
    }
}
