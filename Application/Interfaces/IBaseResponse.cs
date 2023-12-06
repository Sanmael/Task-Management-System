using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IBaseResponse
    {
        public bool IsSuccess {  get; }
        public object Data { get; }
    }
}
