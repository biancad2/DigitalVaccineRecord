﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalVaccineRecord.Core.Interfaces
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();

        T Get(Guid id);

        void Add(T item);

        void Edit(T item);

        void Delete(Guid id);
    }
}
