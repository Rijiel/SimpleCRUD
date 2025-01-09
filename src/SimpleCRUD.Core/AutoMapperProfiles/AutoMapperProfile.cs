using AutoMapper;
using SimpleCrud.Core.Domain.Models;
using SimpleCRUD.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRUD.Core.AutoMapperProfiles;
public class AutoMapperProfile : Profile
{
	public AutoMapperProfile()
	{
		CreateMap<Person, PersonResponse>().ReverseMap();
		CreateMap<PersonAddRequest, Person>();
		CreateMap<PersonResponse, PersonUpdateRequest>();
		CreateMap<PersonUpdateRequest, Person>();
	}
}
