﻿using EmploMetrica.Domain.Companies;
using EmploMetrica.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploMetrica.Application
{
    internal interface ICrudService<T,U,V>
    {
        public Result<List<T>> Get();
        public Result<T> GetById(int Id);
        public Result<T> Create(U createDto);
        public Result<T> Edit(int Id, V updateDto);
        public Result<bool> Delete(int Id);
    }
}
