using AutoMapper;
using Cat.Users.Models;
using Cat.Users.ViewModels.Api;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cat.Users
{
    public class ApiMapper : Profile
    {
        public ApiMapper()
        {
            CreateMap<User, UserRecordOutput>();
        }
    }
}
