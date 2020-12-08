﻿using CharlieBackend.Core.Models.ResultModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CharlieBackend.Business.Services.Interfaces
{
    public interface IHomeworkService
    {
        Task<Result<HometaskDto>> CreateHometaskAsync(CreateHometaskDto courseModel);
    }
}
