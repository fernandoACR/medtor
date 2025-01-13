using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AppDoctor
{
    public class DoctorResponse
    {
        [BsonElement("id")]
        public int id { get; set; }
        public List<Doctor> Doctores { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
