using System;
using System.Collections.Generic;
using System.Text;

namespace TodoApp.Application.ViewModel
{
    public class UserParamsModel
    {
        private const int MaxPageSize = 50;
        public int PageNumber { get; set; } = 1;

        private int pageSize = 10;

        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = (value > MaxPageSize) ? MaxPageSize : value; }
        }
    }
}
