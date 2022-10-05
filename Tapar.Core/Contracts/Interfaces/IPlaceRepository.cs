﻿
using TanvirArjel.Extensions.Microsoft.DependencyInjection;
using Tapar.Data.Entities;

namespace Tapar.Core.Contracts.Interfaces
{
    [ScopedService]
    public interface IPlaceRepository:IRepository<Place>
    {
        
    }
}