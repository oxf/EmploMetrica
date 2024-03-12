using AutoMapper;
using EmploMetrica.Domain.Companies;
using EmploMetrica.Domain.Departments;
using EmploMetrica.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploMetrica.Domain
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            Company();
            Department();
            User();
        }
        private void User()
        {
            CreateMap<RegisterDto, User>().AfterMap((src, dest) => dest.IsActive = true);
        }

        private void Department()
        {
            CreateMap<CreateDepartmentDTO, Department>();
            CreateMap<UpdateDepartmentDTO, Department>();
            CreateMap<Department, GetDepartmentDTO>();
            CreateMap<RegisterDto, User>().AfterMap((src, dest) => dest.IsActive = true);
        }

        private void Company()
        {
            CreateMap<CreateCompanyDTO, Company>();
            CreateMap<UpdateCompanyDTO, Company>();
            CreateMap<Company, GetCompanyDTO>();
        }
    }
}
