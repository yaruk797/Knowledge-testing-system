using AutoMapper;
using Business.Models;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<User, UserModel>()
                .ForMember(um => um.Username, u => u.MapFrom(r => r.Profile.Username))
                .ForMember(um => um.Password, u => u.MapFrom(r => r.Profile.Password))
                .ForMember(um => um.TestIds, u => u.MapFrom(r => r.PassTests.Select(x => x.TestId)))
                .ReverseMap();

            CreateMap<Test, TestModel>()
                .ForMember(tm => tm.UserIds, t => t.MapFrom(r => r.Users.Select(x => x.UserId)))
                //.ForMember(tm => tm.QuestionIds, t => t.MapFrom(r => r.Questions.Select(x => x.Id)))
                .ReverseMap();

            CreateMap<Question, QuestionModel>()
                //.ForMember(qm => qm.AnswerIds, q => q.MapFrom(r => r.Answers.Select(x => x.Id)))
                .ReverseMap();

            CreateMap<Answer, AnswerModel>().ReverseMap();
        }
    }
}
