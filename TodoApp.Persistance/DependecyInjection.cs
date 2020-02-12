﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TodoApp.Application.Helpers;
using TodoApp.Application.Services;
using TodoApp.Application.Services.Interfce;
using TodoApp.Application.ViewModel;
using TodoApp.Domain.Entities;
using TodoApp.Domain.Interface;
using TodoApp.Persistance;
using TodoApp.Persistance.Repository;

//Percistance

namespace TodoApp.Persistance
{
    public static class DependecyInjection
    {
        /// <summary>
        /// Register repositories to services with dependency injection
        /// </summary>
        /// <param name="services"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        /// 
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUnitOfWork, TodoAppDbContext>();

            services.AddScoped<ICategoryService, CategoryService>();

            services.AddScoped<ISubCategoryService, SubCategoryService>();

            services.AddScoped<ITodoService, TodoService>();

            services.AddScoped<INoteService, NoteService>();

            services.AddScoped<ILinkService, LinkService>();

            services.AddScoped<IFileService, FileService>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            });
            services.AddSingleton<IMapper>(sp => config.CreateMapper());
            services.AddDbContext<TodoAppDbContext>(options =>
              options.UseSqlServer(configuration.GetConnectionString("TodoAppDatabase")));

            return services;
        }
    }
}
