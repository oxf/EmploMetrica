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
        public MappingProfile()
        {
            Company();
            Department();
        }

        private void Department()
        {
            CreateMap<CreateDepartmentDTO, Department>();
            CreateMap<UpdateDepartmentDTO, Department>();
            CreateMap<Department, GetDepartmentDTO>();
        }

        private void Company()
        {
            CreateMap<CreateCompanyDTO, Company>();
            CreateMap<UpdateCompanyDTO, Company>();
            CreateMap<Company, GetCompanyDTO>();
        }
    }
}
