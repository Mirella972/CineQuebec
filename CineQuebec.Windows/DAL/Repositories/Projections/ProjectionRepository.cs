﻿using CineQuebec.Windows.DAL.Data;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineQuebec.Windows.DAL.Repositories.Projections
{
    public class ProjectionRepository : IProjectionRepository
    {
        private readonly DatabaseGestion _databaseGestion;
        private readonly IMongoCollection<Projection> _projectionsCollection;
        private readonly IMongoCollection<Salle> _sallesCollection;

        public ProjectionRepository(DatabaseGestion databaseGestion)
        {
            _databaseGestion = databaseGestion;
            _projectionsCollection = _databaseGestion.GetProjectionsCollection().Result;
            _sallesCollection = _databaseGestion.GetSallesCollection().Result;
        }
        public async Task<Projection> AddProjection(Projection projection)
        {
            try
            {
                await _projectionsCollection.InsertOneAsync(projection);
                return projection;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Impossible d'ajouter la projection : " + ex.Message);
                return null;
            }
        }

        public async Task<bool> DeleteProjection(Projection projection)
        {
            try
            {
                var deleteResult = await _projectionsCollection.DeleteOneAsync(p => p.Id == projection.Id);
                return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Impossible de supprimer la projection : " + ex.Message);
                return false;
            }
        }

        public async Task<List<Projection>> GetProjectionsForFilm(ObjectId filmId)
        {
            try
            {
                var projectionsFilm = Builders<Projection>.Filter.Eq(p => p.Film.Id, filmId);
                return await _projectionsCollection.Find(projectionsFilm).ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Impossible d'obtenir les projections pour le film : " + ex.Message);
                return new List<Projection>();
            }
        }

        public async Task<bool> UpdateProjection(Projection projection)
        {
            try
            {
                var filter = Builders<Projection>.Filter.Eq(p => p.Id, projection.Id);
                var updateResult = await _projectionsCollection.ReplaceOneAsync(filter, projection);

                return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Impossible de mettre à jour la projection : " + ex.Message);
                return false;
            }
        }

        public async Task<List<Salle>> GetSallesDisponibles(DateTime dateHeureDebut)
        {
            try
            {
                var salles = await _sallesCollection.Aggregate().ToListAsync();
                // TODO : ameliorer la logique en prenant en compte fin projection
                var sallesNonDispo = await _projectionsCollection.Find(p => p.DateHeureDebut == dateHeureDebut).Project(p => p.Salle.Id).ToListAsync();
                var sallesDispo = salles.Where(s => !sallesNonDispo.Contains(s.Id)).ToList();
                return sallesDispo;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Impossible d'obtenir les salles disponible : " + ex.Message);
                return new List<Salle>();
            }
        }
    }
}