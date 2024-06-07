using Hotel.Application.Core;
using Hotel.Application.Dtos.Category;
using Hotel.Application.Models.Category;
using Hotel.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Application.Contract
{
    public interface ICategoryService : IBaseService<CategoryDtoAdd, CategoryDtoUpdate, CategoryDtoRemove,CategoryGetModel >
    {

    }
}
