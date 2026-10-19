using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineCourseManagementSystem.Models
{
    public class Lesson
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }
        public int CourseId { get; set; }
        public int DurationInMinutes {  get; set; }

        public Lesson(int id,string title,string description,int courseId,int durationInMinutes)
        {
            Id = id;
            Title = title;
            Description = description;
            CourseId = courseId;
            DurationInMinutes = durationInMinutes;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Lesson ID: {Id}");
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Description: {Description}");
            Console.WriteLine($"Course ID: {CourseId}");
            Console.WriteLine($"Duration: {DurationInMinutes} minutes");
        }
    }
}