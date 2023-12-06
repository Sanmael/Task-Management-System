using Application.Interfaces;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class FailureBaseResponse : IBaseResponse
    {
        public bool IsSuccess => false;
        public object Data => ErrorResponse;
        public ErrorResponse ErrorResponse { get; set; }
        public FailureBaseResponse(string message, string errr)
        {
            ErrorResponse = new ErrorResponse(message,new List<string> { errr });
        }
        public void AddError(string errr)
        {
            ErrorResponse.Error.Add(errr);
        }
    }
    public record ErrorResponse
    (
        string Message,
        List<string> Error
    );
}
