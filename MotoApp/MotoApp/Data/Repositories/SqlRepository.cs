﻿namespace MotoApp.Data.Repositories;

using Microsoft.EntityFrameworkCore;
using MotoApp.Data.Entities;
using System.Runtime.CompilerServices;

//public delegate void ItemAdded<T>(T item);

public class SqlRepository<T> : IRepository<T> where T : class, IEntity
{
    private readonly DbSet<T> _dbSet;
    private readonly DbContext _dbContext;
    private readonly Action<T>? _itemAddedCallback;

    public SqlRepository(DbContext dbContext, Action<T>? itemAddedCallback = null)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<T>();
        _itemAddedCallback = itemAddedCallback;
    }

    public event EventHandler<T>? ItemAdded;

    public T? GetById(int id)
    {
        return _dbSet.Find(id);
    }

    public void Add(T item)
    {
        _dbSet.Add(item);
        _itemAddedCallback?.Invoke(item); // delegate action
        ItemAdded?.Invoke(this, item); // eventhandler

    }

    public void Remove(T item)
    {
        _dbSet.Remove(item);
    }

    public void Save()
    {
        _dbContext.SaveChanges();
    }

    public IEnumerable<T> GetAll()
    {
        return _dbSet.ToList();
    }



}