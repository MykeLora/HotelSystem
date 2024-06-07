using Hotel.Application.Contract;
using Hotel.Application.Core;
using Hotel.Application.Dtos.Category;
using Hotel.Application.Models.Category;
using Hotel.Infraestructure.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ILogger<CategoryService> logger;
        private readonly ICategoryRepository categoryRepository;

        public CategoryService(ILogger<CategoryService> logger,
                                ICategoryRepository categoryRepository)
        {
            this.logger = logger;
            this.categoryRepository = categoryRepository;
        }
        public ServiceResut<List<CategoryGetModel>> GetAll()
        {
            ServiceResut<List<CategoryGetModel>> result = new ServiceResut<List<CategoryGetModel>>();

            try
            {
                var categories = this.categoryRepository.GetEntities().Select(
                    category => new CategoryGetModel()
                    {
                        IdCategoria = category.IdCategoria,
                        Descripcion = category.Descripcion,
                        FechaRegistro = category.FechaRegistro,
                    }).ToList();

                result.Data = categories;

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al obtener las categorias.";
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        
        }

        public ServiceResut<CategoryGetModel> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public ServiceResut<CategoryGetModel> Remove(CategoryDtoUpdate dtoRemove)
        {
            throw new NotImplementedException();
        }

        public ServiceResut<CategoryGetModel> Save(CategoryDtoAdd dtoAdd)
        {
            throw new NotImplementedException();
        }

        public ServiceResut<CategoryGetModel> Update(CategoryDtoRemove dtoUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
