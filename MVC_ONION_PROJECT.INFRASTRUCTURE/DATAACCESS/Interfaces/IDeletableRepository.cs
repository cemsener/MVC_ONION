﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_ONION_PROJECT.INFRASTRUCTURE.DATAACCESS.Interfaces
{
    public interface IDeletableRepository<TEntity> : IRepository
    {
        bool Delete(TEntity entity);
    }
}
