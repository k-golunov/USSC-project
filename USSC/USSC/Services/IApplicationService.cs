﻿using Microsoft.AspNetCore.Mvc;
using USSC.Entities;
using USSC.Dto;
namespace USSC.Services;

public interface IApplicationService
{
    Task<Guid> Add(UsersDirectionsfkModel model);
}