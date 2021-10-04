﻿using AutoMapper;
using CharlieBackend.Panel.Models.Lesson;
using CharlieBackend.Panel.Services.Interfaces;
using CharlieBackend.Panel.Utils.Interfaces;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CharlieBackend.Panel.Services
{
    public class LessonService : ILessonService
    {
        private readonly LessonsApiEndpoints _lessonkApiEndpoints;
        private readonly IApiUtil _apiUtil;
        private readonly IMapper _mapper;
        public LessonService(IOptions<ApplicationSettings> options, IApiUtil apiUtil, IMapper mapper)
        {
            _lessonkApiEndpoints = options.Value.Urls.ApiEndpoints.Lessons;
            _apiUtil = apiUtil;
            _mapper = mapper;
        }
        public async Task<IList<LessonViewModel>> GetAllLessons()
        {
            var lessonsEndpoint = _lessonkApiEndpoints.GetAllLessons;
            return await _apiUtil.GetAsync<IList<LessonViewModel>>(lessonsEndpoint);
           
        }
    }
}
