﻿namespace BangaloreUniversityLearningSystem.Data
{
    using System;
    using System.Collections.Generic;
    using Interfaces;

    public class Repository<T> : IRepository<T>
    {
        private IList<T> items;

        public Repository()
        {
            this.Items = new List<T>();
        }

        public IList<T> Items
        {
            get
            {
                return this.items;
            }

            set
            {
                this.items = value;
            }
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