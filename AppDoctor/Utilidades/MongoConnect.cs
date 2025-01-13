using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;

namespace AppDoctor.Repositorio
{
    public class MongoConnect
    {
        public string server = "";
        public string databaseName = "";
        public MongoClient client;
        public IMongoDatabase db;
        public MongoConnect()
        {
            string connectionString = "mongodb://localhost:27017/AppDoctorReceta";
            var Connection = MongoUrl.Create(connectionString);
            client = new MongoClient(connectionString);
            db = client.GetDatabase(Connection.DatabaseName);
            //var collection = db.GetCollection<PositionResponse>("Positions");

            databaseName = Connection.DatabaseName;
            server = Connection.Server.Host + ":" + Connection.Server.Port;
        }
    }
}
