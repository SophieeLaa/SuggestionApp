﻿using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuggestionAppLibrary.DataAccess
{
    public class MongoCategoryData : ICategoryData
    {
        private readonly IMongoCollection<CategoryModel> _categories;
        private readonly IMemoryCache _cache;
        private const string cachName = "CategoryData";

        public MongoCategoryData(IDbConnection db, IMemoryCache cache)
        {
            _cache = cache;
            _categories = db.CategoryCollection;
        }

        public async Task<List<CategoryModel>> GetAllCategories()
        {
            var output = _cache.Get<List<CategoryModel>>(cachName);
            if (output is null)
            {
                var results = await _categories.FindAsync(_ => true);
                output = results.ToList();
                _cache.Set(cachName, output, TimeSpan.FromDays(value: 1));
            }
            return output;
        }
        public Task CreateCategory(CategoryModel category)
        {
            return _categories.InsertOneAsync(category);
        }

    }
}
