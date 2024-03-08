using EmploMetrica.Domain.Companies;
using EmploMetrica.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploMetrica.Application.Interfaces
{
    public interface ICrudChildService<T, U, V>
    {
        public Result<List<T>> Get(int ParentId);
        public Result<T> GetById(int ParentId, int Id);
        public Result<T> Create(int ParentId, U createDto);
        public Result<T> Edit(int ParentId, int Id, V updateDto);
        public Result<bool> Delete(int ParentId, int Id);
    }
}
