using CoursesMainAPI.Models;
using MongoDB.Driver;

namespace CoursesMainAPI.Data
{


    public class MongoCRUD
    {
        private IMongoDatabase db;

        public MongoCRUD(string database)
        {

        }

        public async Task<List<Courses>> AddCourse(string table, Courses course)
        {

        }

        public async Task<List<Courses>> GetAllCourses(string table)
        {

        }

        public async Task<Courses> GetCourseById(string table, Guid id)
        {
      
        }

        public async Task<Courses> UpdateCourse(string table, Courses course)
        {

        }

        public async Task<string> DeleteCourse(string table, Guid Id)
        {

        }

    }
}
