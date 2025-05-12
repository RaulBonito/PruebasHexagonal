using PruebasHexagonal.Domain.Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebasHexagonal.Domain.Abstractions.Presenters
{
    public interface IPresenter<TResponse>
    {
        Task<AppResponse<TResponse>> PresentAsync(TResponse response);
    }
}
