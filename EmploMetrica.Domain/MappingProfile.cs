using AutoMapper;
using EmploMetrica.Domain.Companies;
using EmploMetrica.Domain.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploMetrica.Domain
{
    public class MappingProfile: Profile
    {
        public MappingProfile() {
            CreateMap<CreateCompanyDTO, Company>();
            CreateMap<Company, GetCompanyDTO>();
            CreateMap<CreateDepartmentDTO, Department>();
            CreateMap<Department, GetDepartmentDTO>();
        }
    }
}
