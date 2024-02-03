using AutoMapper;
using EmploMetrica.Domain.Companies;
using EmploMetrica.Domain.Interfaces;
using EmploMetrica.Domain.Shared;
using EmploMetrica.Persistence.Contexts;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploMetrica.Application.UseCases.Companies
{
    public class CompanyService(AppDbContext _db, IMapper _mapper): CrudService
    {
        public Result<List<GetCompanyDTO>> Get()
        {
            return new Result<List<GetCompanyDTO>>(true,  _db.CompanyDbSet.Select(x => _mapper.Map<GetCompanyDTO>(x)).ToList(), null);
        }

        public Result<GetCompanyDTO> GetById(int Id)
        {
            var company = _mapper.Map<GetCompanyDTO>(_db.CompanyDbSet.Find(Id));
            if(company != null)
            {
                return new Result<GetCompanyDTO>(true, company, null);
            } else
            {
                return new Result<GetCompanyDTO>(false, null, new List<string> { "Company Not Found" });
            }
        }
        public Result<GetCompanyDTO> Post(CreateCompanyDTO companyDto)
        {
            Company company = _mapper.Map<Company>(companyDto);
            //validate
            _db.CompanyDbSet.Add(company);
            _db.SaveChanges();
            return new Result<GetCompanyDTO>(true, _mapper.Map<GetCompanyDTO>(company), null);
        }

        public Result<GetCompanyDTO> Put(int Id, UpdateCompanyDTO updateCompanyDto)
        {
            var company = _db.CompanyDbSet.Find(Id);
            if (company == null)
            {
                return new Result<GetCompanyDTO>(false, null, new List<string> { "Company Not Found" });
            }
            _mapper.Map(updateCompanyDto, company);
            _db.SaveChanges();
            return new Result<GetCompanyDTO>(true, _mapper.Map<GetCompanyDTO>(company), null);
            
        }
        public Result<GetCompanyDTO> Delete(int Id)
        {
            var company = _db.CompanyDbSet.Find(Id);
            if (company == null)
            {
                return new Result<GetCompanyDTO>(false, null, new List<string> { "Company Not Found" });
            }
            _db.CompanyDbSet.Remove(company);
            _db.SaveChanges();
            return new Result<GetCompanyDTO>(true, null, null);
        }
    }
}
