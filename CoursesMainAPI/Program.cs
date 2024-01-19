
using CoursesMainAPI.Data;
using CoursesMainAPI.Models;

namespace CoursesMainAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            MongoCRUD db = new MongoCRUD("AzureCourses");


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapGet("/courses", async() =>
            {
                var courses = await db.GetAllCourses("Courses");
                return Results.Ok(courses);

            });

            app.MapGet("/course/{id}", async (Guid id) =>
            {
                var course = await db.GetCourseById("Courses",id);
                return Results.Ok(course);
            });


            app.MapPost("/course", async (Courses course) =>
            {
                var usertest = await db.AddCourse("Courses", course);
                return Results.Ok(usertest);
            });

            app.MapPut("/course/{id}", async (Courses updatedCourse, Guid id) =>
            {

                var course = await db.UpdateCourse("Courses", updatedCourse);
                return Results.Ok(course);

            });


            app.MapDelete("/course/{id}", async (Guid id) =>
            {
                var course = await db.DeleteCourse("Courses", id);
                return Results.Ok(course);
            });

            app.Run();
        }
    }
}