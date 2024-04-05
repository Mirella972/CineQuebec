﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CineQuebec.Windows.DAL.Data;
using MongoDB.Bson;

namespace CineQuebec.Windows.DAL.Repositories.Films
{
    public interface IFilmRepository
    {
        List<Film> GetFilms();
        void AddFilm(Film film);
        void UpdateFilm(Film film);
        List<Projection> GetProjectionsForFilm(ObjectId filmId);
    }
}
