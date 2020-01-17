using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApp.Domain.Entities
{
    public class UserParams
    {
        private const int MaxPageSize = 50;
        private int pageNumber = 1;

        private int pageSize = 10;

        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = (value > MaxPageSize) ? MaxPageSize : (value <= 0) ? 10 : value; }
        }
        public int PageNumber
        {
            get { return pageNumber; }
            set { pageNumber = value <= 0 ? 1 : value; }
        }

    }
}
