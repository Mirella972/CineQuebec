﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineQuebec.Windows.DAL.Data
{
    public class Film
    {
        [BsonId]
        public ObjectId Id { get; private set; }
        public string OriginalTitle { get; set; }
        public string FrenchTitle { get; set; }
        public string Description { get; set; }
        public ushort Duration { get; set; }
        public DateTime InternationalReleaseDate { get; set; }
        public ushort Rating { get; set; }
        public string OriginalLanguage { get; set; }

        public Film(string pOriginalTitle, string pFrenchTitle, string pDescription, ushort pDuration, DateTime pInternationalReleaseDate, ushort pRating, string pOriginalLanguage)
        {
            OriginalTitle = pOriginalTitle;
            FrenchTitle = pFrenchTitle;
            Description = pDescription;
            Duration = pDuration;
            InternationalReleaseDate = pInternationalReleaseDate;
            Rating = pRating;
            OriginalLanguage = pOriginalLanguage;
        }
    }
}
