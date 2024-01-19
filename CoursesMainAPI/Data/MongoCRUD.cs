using CoursesMainAPI.Models;
using MongoDB.Driver;

namespace CoursesMainAPI.Data
{


    public class MongoCRUD
    {
        private IMongoDatabase db;

        public MongoCRUD(string database)
        {
            var client = new MongoClient("");
            db = client.GetDatabase(database);
        }

        public async Task<List<Courses>> AddCourse(string table, Courses course)
        {
            var collection = db.GetCollection<Courses>(table);
            await collection.InsertOneAsync(course);
            return collection.AsQueryable().ToList();
        }

        public async Task<List<Courses>> GetAllCourses(string table)
        {
            var collection = db.GetCollection<Courses>(table);
            var courses = await collection.AsQueryable().ToListAsync();
            return courses;
        }

        public async Task<Courses> GetCourseById(string table, Guid id)
        {
            var collection = db.GetCollection<Courses>(table);
            var course = await collection.FindAsync(x => x.Id == id);
            return await course.FirstOrDefaultAsync();
        }

        public async Task<Courses> UpdateCourse(string table, Courses course)
        {
            var collection = db.GetCollection<Courses>(table);
            course.Name = "Potatis";
            await collection.ReplaceOneAsync(x => x.Id == course.Id, course, new ReplaceOptions { IsUpsert = true });
            return course;
        }

        public async Task<string> DeleteCourse(string table, Guid Id)
        {
            var collection = db.GetCollection<Courses>(table);
            var course = await collection.DeleteOneAsync(x => x.Id == Id);
            return "Niceeey!";
        }

    }
}
