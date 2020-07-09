﻿using CharlieBackend.Core.Entities;
using CharlieBackend.Core.Models;
using CharlieBackend.Core.Models.Account;
using CharlieBackend.Core.Models.Course;
using CharlieBackend.Core.Models.Lesson;
using CharlieBackend.Core.Models.Student;
using CharlieBackend.Core.Models.Theme;
using System;
using System.Linq;

namespace CharlieBackend.Core
{
    public static class AdapterExtensionMethods
    {
        public static Account ToAccount(this BaseAccountModel accountModel)
        {
            return new Account
            {
                Id = accountModel.Id,
                Email = accountModel.Email,
                Password = accountModel.Password,
                FirstName = accountModel.FirstName,
                LastName = accountModel.LastName,
                Role = (sbyte)accountModel.Role,
                IsActive = accountModel.IsActive
            };
        }

        public static BaseAccountModel ToAccountModel(this Account account)
        {
            // TODO: fix ID error
            return new BaseAccountModel
            {
                Id = account.Id,
                Email = account.Email,
                Password = account.Password,
                FirstName = account.FirstName,
                LastName = account.LastName,
                Role = (sbyte)account.Role,
                IsActive = (bool)account.IsActive
            };
        }

        public static AccountInfoModel ToUserModel(this BaseAccountModel accountModel)
        {
            return new AccountInfoModel
            {
                FirstName = accountModel.FirstName,
                LastName = accountModel.LastName,
                Role = accountModel.Role
            };
        }

        public static Lesson ToLesson(this LessonModel lessonModel)
        {
            return new Lesson
            {
                Id = lessonModel.Id,
                StudentGroupId = lessonModel.GroupId,
                LessonDate = DateTime.Parse(lessonModel.LessonDate),
            };
        }

        public static LessonModel ToLessonModel(this Lesson lesson)
        {
            return new LessonModel
            {
                Id = lesson.Id,
                GroupId = lesson.StudentGroupId ?? 0, // TODO: remove
                LessonDate = lesson.LessonDate.ToString()
            };
        }

        public static Course ToCourse(this CourseModel courseModel)
        {
            return new Course
            {
                Id = courseModel.Id,
                Name = courseModel.Name
            };
        }

        public static CourseModel ToCourseModel(this Course course)
        {
            return new CourseModel
            {
                Id = course.Id,
                Name = course.Name,
            };
        }

        //public static StudentGroup ToStudentGroup(this StudentGroupModel studentGroupModel)
        //{
        //    return new StudentGroup
        //    {
        //        Name = studentGroupModel.name,
        //        CourseId = studentGroupModel.course_id,
        //        StartDate = DateTime.Parse(studentGroupModel.start_date),
        //        FinishDate = DateTime.Parse(studentGroupModel.finish_date),
        //    };
        //}

        public static Theme ToTheme(this ThemeModel themeModel)
        {
            return new Theme
            {
                Id = themeModel.Id,
                Name = themeModel.Name
            };
        }

        public static ThemeModel ToThemeModel(this Theme themeModel)
        {
            return new ThemeModel
            {
                Id = themeModel.Id,
                Name = themeModel.Name
            };
        }

        public static Mentor ToMentor(this MentorModel mentorModel)
        {
            return new Mentor
            {
                Id = mentorModel.Id
            };
        }

        public static MentorModel ToMentorModel(this Mentor mentor)
        {
            return new MentorModel
            {
                Id = mentor.Id,
                FirstName = mentor.Account.FirstName,
                LastName = mentor.Account.LastName,
                Email = mentor.Account.Email,
                Password = mentor.Account.Password,
                IsActive = (bool)mentor.Account.IsActive,
                CourseIds = mentor.MentorsOfCourses.Select(mentorOfCourse => (long)mentorOfCourse.CourseId).ToList()
            };
        }
        public static StudentModel ToStudentModel(this Student student)
        {
            return new StudentModel
            {
                Id = student.Id,
                FirstName = student.Account.FirstName,
                LastName = student.Account.LastName,
                Email = student.Account.Email,
                Password = student.Account.Password,
                IsActive = (bool)student.Account.IsActive
                //Groups_id = student.StudentsOfStudentGroups.Select(studentOfStudentGroup => (long)studentOfStudentGroup.StudentGroupId).ToList()
            };
        }
        public static Student ToStudent(this StudentModel studentModel)
        {
            return new Student
            { };
        }
    }
}
