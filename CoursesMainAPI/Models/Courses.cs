using MongoDB.Bson.Serialization.Attributes;

namespace CoursesMainAPI.Models
{
    public class Courses
    {
        [BsonId]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public string Category { get; set; }

    }
}
