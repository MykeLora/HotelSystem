﻿using Hotel.Application.Contract;
using Hotel.Application.Core;
using Hotel.Application.Dtos.Category;
using Hotel.Application.Models.Category;
using Hotel.Infraestructure.Interfaces;
using Microsoft.Extensions.Logging;
using Northwind.Domain.Entities;
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
                        FechaRegistro = category.FechaCreacion,
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
            ServiceResut<CategoryGetModel> result = new ServiceResut<CategoryGetModel>();

            try
            {
                var category = this.categoryRepository.GetEntity(id);

                if(category != null)
                {
                    result.Data = new CategoryGetModel
                    {
                        IdCategoria = category.IdCategoria,
                        Descripcion = category.Descripcion,
                        FechaRegistro = category.FechaCreacion
                    };
                }
                else
                {
                    result.Success = false;
                    result.Message = "La categoria no existe";
                }
            }
            catch (Exception)
            {
                result.Success = false;
                result.Message = "Error al obtener la categoria.";
                this.logger.LogError(result.Message);
            }

            return result;


        }


        public ServiceResut<CategoryGetModel> Remove(CategoryDtoRemove dtoRemove)
        {
            throw new NotImplementedException();
        }

        public ServiceResut<CategoryGetModel> Save(CategoryDtoAdd dtoAdd)
        {
            throw new NotImplementedException();
        }

        public ServiceResut<CategoryGetModel> Update(CategoryDtoUpdate dtoUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
