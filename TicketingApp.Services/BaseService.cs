using System;
using System.Collections.Generic;
using System.Text;
using TicketingApp.Shared.Responses;

namespace TicketingApp.Services
{
    public class BaseService
    {
        protected OperationResponse<T> Error<T>(string message, T record)
        {
            return new OperationResponse<T>
            {
                Message = message,
                Record = record,
                IsSuccess = false,
            };
        }
        protected OperationResponse<T> Success<T>(string message, T record)
        {
            return new OperationResponse<T>
            {
                Message = message,
                Record = record,
                IsSuccess = true,

            };
        }

    }
}
