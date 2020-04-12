using AutoMapper;
using Cat.System.Models;
using Cat.System.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cat.System
{
    public class ApiMapper : Profile
    {
        public ApiMapper()
        {
            CreateMap<Account, AccountListOutput>();
        }
    }
}
