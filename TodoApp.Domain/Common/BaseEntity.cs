using System;
using System.Collections.Generic;
using System.Text;

namespace TodoApp.Domain.Common
{
    public class BaseEntity
    {
        public DateTime Created { get; set; }
        public BaseEntity()
        {
            Created = DateTime.Now;
        }
    }
}
