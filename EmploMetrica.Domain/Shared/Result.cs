using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploMetrica.Domain.Shared
{
    public class Result<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
        public List<string> Errors { get; set; }

        public Result(bool Success, T Data, List<string> Errors) {
            this.Success = Success;
            this.Data = Data;
            this.Errors = Errors;
        }
        
    }
}
