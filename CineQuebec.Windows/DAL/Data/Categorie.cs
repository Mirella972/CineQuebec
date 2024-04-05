﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineQuebec.Windows.DAL.Data
{
    public class Categorie
    {
        [BsonId]
        public ObjectId Id { get; private set; }
        public string Nom { get; set; }
    }
}
