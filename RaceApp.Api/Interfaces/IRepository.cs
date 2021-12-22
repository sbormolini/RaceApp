﻿using RaceApp.Api.Models;

namespace RaceApp.Api.Interfaces;

public interface IRepository<T> where T : Entity
{
    Task<T> GetByIdAsync(string id);
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}