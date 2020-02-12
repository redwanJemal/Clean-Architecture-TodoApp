using System;
using System.Collections.Generic;
using System.Text;
using TodoApp.Domain.Interface;

namespace TodoApp.Application.Services
{
    public abstract class BaseService
    {
        public IUnitOfWork UoW { get; set; }
    }
}
