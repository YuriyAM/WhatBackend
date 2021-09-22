﻿using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using CharlieBackend.Core.Entities;
using CharlieBackend.Core.DTO.Homework;

namespace CharlieBackend.Data.Repositories.Impl.Interfaces
{
    public interface IHomeworkRepository : IRepository<Homework>
    {
        void UpdateManyToMany(IEnumerable<AttachmentOfHomework> currentHomeworkAttachments,
                     IEnumerable<AttachmentOfHomework> newHomeworkAttachments);

        Task<IList<Homework>> GetHomeworksByLessonId(long studentGroupId);
        Task<IList<Homework>> GetHomeworks(GetHomeworkRequestDto request);
        Task<IList<Homework>> GetHomeworksForMentorByCourseId(long courseId);
        Task<Homework> GetMentorHomeworkAsync(long mentorId, long homeworkId);
        Task<IList<Homework>> GetHomeworksForMentorByThemeFilter(GetHomeworkRequestDto request, long mentorId);
    }
}
