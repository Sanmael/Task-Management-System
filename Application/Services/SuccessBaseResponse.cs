using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class SuccessBaseResponse<T> : IBaseResponse
    {
        public bool IsSuccess => true;        
        public SuccessResponse Data { get; set; }

        object IBaseResponse.Data => Data;

        public SuccessBaseResponse(string message, T data)
        {            
            Data = new SuccessResponse(message,data!);
        }
    }
    public record SuccessResponse
    (
       string Message ,
       object Data 
    );
}
