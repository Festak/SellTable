﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellTables.Interfaces
{
    interface IRepository<T> where T : class
    {
        ICollection<T> GetAll();

        ICollection<T> Find(Func<T, bool> predicate);

      Task<T> Get(int id);

        Task<bool> Remove(int id);

        void Add(T item);
        void Update(T item);
    }
}