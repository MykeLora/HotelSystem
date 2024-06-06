using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Application.Core
{
    public interface IBaseService<TDtoAdd,  TDtoRemove, TDtoUpdate, TModel>
    {
        ServiceResut<List<TModel>> GetAll();
        ServiceResut<TModel> GetById(int id);
        ServiceResut<TModel> Save(TDtoAdd dtoAdd);
        ServiceResut<TModel> Update(TDtoUpdate dtoUpdate);
        ServiceResut<TModel> Remove(TDtoRemove dtoRemove);
    }
}
