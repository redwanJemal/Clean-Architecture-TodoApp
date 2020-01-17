using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TodoApp.Application.ViewModel;
using TodoApp.Domain.Entities;

namespace TodoApp.Application.Helpers
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Category, CategoryModel>().ReverseMap();
            CreateMap<SubCategory, SubCategoryModel>().ReverseMap();
            CreateMap<Todo, TodoModel>().ReverseMap();
            CreateMap<Note, NoteModel>().ReverseMap();
            CreateMap<Link, LinkModel>().ReverseMap();
            CreateMap<UserParams, UserParamsModel>().ReverseMap(); 
            CreateMap<File, FileModel>().ReverseMap();

        }
    }
}
