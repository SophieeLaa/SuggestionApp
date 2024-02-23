﻿using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuggestionAppLibrary.DataAccess
{
    public class DbConnection
    {
        private readonly IConfiguration _config;
        private readonly IMongoDatabase _db;
        private string _connectionString = "MongoDB";
        public string DbName { get; private set; }
        public string CategoryCollectionName { get; private set; } = "categories";
        public string StatusCollectionName { get; private set; } = "statuses";
        public string UserCollectionName { get; private set; } = "users";
        public string SuggestionCollectionName { get; private set; } = "suggestions";
        public MongoClient Client { get; private set; }
        public IMongoCollection<CategoryModel> CategoryCollection { get; private set; }
        public IMongoCollection<StatusModel> StatusCollection { get; private set; }
        public IMongoCollection<SuggestionModel> SuggestionCollection { get; private set; }

        public DbConnection(IConfiguration config)
        {
            _config = config;
        }
    }
}