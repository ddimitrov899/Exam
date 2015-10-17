namespace BangaloreUniversity.Data
{
    using System;
    using System.Collections.Generic;
    using BangaloreUniversity.Interfaces;

    public class Repository<T> : IRepository<T>
    {
        protected readonly List<T> Items;

        public Repository()
        {
            this.Items = new List<T>();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return this.Items;
        }

        public virtual T Get(int id)
        {
            T item;
            try
            {
                item = this.Items[id - 1];
            }
            catch (ArgumentOutOfRangeException)
            {
                item = default(T);
            }

            return item;
        }

        public virtual void Add(T item)
        {
            this.Items.Add(item);
        }
    }
}