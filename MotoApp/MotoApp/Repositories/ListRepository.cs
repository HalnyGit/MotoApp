﻿namespace MotoApp.Repositories
{
    using MotoApp.Entities;
    public class ListRepository<T> : IRepository<T> where T : class, IEntity, new()
    {

        protected readonly List<T> _items = new();

        public void Add(T item)
        {
            item.Id = _items.Count + 1;
            _items.Add(item);
        }

        public void Remove(T item)
        {
            _items.Remove(item);
        }

        public T GetById(int id)
        {
            return _items.Single(item => item.Id == id);
        }

        public IEnumerable<T> GetAll()
        {
            return _items.ToList();
        }

        public void Save()
        {
            //  save is not required with List
        }

    }
}
