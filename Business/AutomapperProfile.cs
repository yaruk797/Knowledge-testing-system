using AutoMapper;
using Business.Models;
using Business.Models.ViewModels;
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
                .ForMember(tm => tm.Id, t => t.MapFrom(r => r.Id))
                .ForMember(tm => tm.Name, t => t.MapFrom(r => r.Name))
                .ForMember(tm => tm.Description, t => t.MapFrom(r => r.Description))
                .ForMember(tm => tm.Questions, t => t.MapFrom(r => r.Questions))
                .ForMember(tm => tm.UserIds, t => t.MapFrom(r => r.Users.Select(x => x.Id)))
                .ReverseMap();
            //.ForMember(tm => tm.QuestionIds, t => t.MapFrom(r => r.Questions.Select(x => x.Id)))

            CreateMap<History, HistoryModel>()
                .ForMember(tm => tm.Id, t => t.MapFrom(r => r.Id))
                .ForMember(tm => tm.DateTime, t => t.MapFrom(r => r.DateTime))
                .ForMember(tm => tm.NumberOfQuestions, t => t.MapFrom(r => r.NumberOfQuestions))
                .ForMember(tm => tm.Result, t => t.MapFrom(r => r.Result))
                .ForMember(tm => tm.UserId, t => t.MapFrom(r => r.UserId))
                .ForMember(tm => tm.TestId, t => t.MapFrom(r => r.TestId))
                .ForMember(hm => hm.Test, h => h.MapFrom(r=>r.Test))
                .ReverseMap();

            CreateMap<History, HistoryViewModel>()
                .ForMember(hvm => hvm.UserName, h => h.MapFrom(r => r.User.FirstName + " " + r.User.LastName))
                .ForMember(hvm => hvm.DateTime, h => h.MapFrom(r => r.DateTime.ToShortDateString() + " " + r.DateTime.ToShortTimeString()))
                .ForMember(hvm => hvm.TestName, h => h.MapFrom(r => r.Test.Name));

            CreateMap<Question, QuestionModel>()
                //.ForMember(qm => qm.AnswerIds, q => q.MapFrom(r => r.Answers.Select(x => x.Id)))
                .ReverseMap();

            CreateMap<Answer, AnswerModel>().ReverseMap();
        }
    }
}
