﻿using Infrastructure.Persistence.Interfaces;

namespace Application.Services;

public class BaseService
{
    public BaseService(IUnitOfWork unitOfWork)
    {
        UnitOfWork = unitOfWork;
    }

    protected internal IUnitOfWork UnitOfWork { get; set; }
}