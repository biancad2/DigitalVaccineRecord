﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalVaccineRecord.Core.Interfaces
{
    public interface IService<T>
    {
        Task<List<T>> GetAllAsync();

        T Get(Guid id);

        void Add(T item);

        T Edit(T item);

        bool Delete(Guid id);
    }
}
