using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MF.Application.Services
{
    public interface IGenericService<RequestModel,ResponseModel>
    {
        Task Create(RequestModel request);
        Task Update(Guid id, RequestModel request);
        Task Delete(Guid id);
        Task<ResponseModel> GetById(Guid id);
        Task<IList<ResponseModel>> GetAll();
    }
}