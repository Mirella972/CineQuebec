﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineQuebec.Windows.DAL.Data
{
    public class Realisateur
    {

        [BsonId]
        public ObjectId Id { get; private set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public Realisateur(string pNom, string pPrenom)
        {
            Nom = pNom;
            Prenom = pPrenom;
        }
    }
}
