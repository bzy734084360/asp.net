﻿using OA.IDAL;
using OA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.IBLL
{
    public interface IUserInfoService : IBaseService<UserInfo>
    {
        bool DeleteEntities(List<int> list);
    }
}
