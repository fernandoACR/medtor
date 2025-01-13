using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;

namespace AppDoctor.Repositorio
{
    public class DoctorRepositorio: IDoctorRepositorio
    {
        public List<DoctorResponse> ObtenerDoctores()
        {
            MongoConnect mc = new MongoConnect();
            var db = mc.db;
            var collection = db.GetCollection<DoctorResponse>("Doctores");
            List<DoctorResponse> Lista = new List<DoctorResponse>();
            Lista = collection.Find(new BsonDocument()).Sort(Builders<DoctorResponse>.Sort.Descending("FechaRegistro")).ToList();

            return Lista;
        }

        public bool RegistrarDoctor(Doctor doctor)
        {
            try
            {
                MongoConnect mc = new MongoConnect();
                var db = mc.db;
                var collection = db.GetCollection<DoctorResponse>("Doctores");
                var update = Builders<DoctorResponse>.Update.AddToSet("Doctores", doctor);
                FilterDefinition<DoctorResponse> filter = "{ _id: " + 1 + " }";
                collection.UpdateOneAsync(filter, update);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
