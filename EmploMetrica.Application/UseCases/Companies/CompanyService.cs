using AutoMapper;
using EmploMetrica.Application.Interfaces;
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
    public class CompanyService(AppDbContext _db, IMapper _mapper): ICrudService<GetCompanyDTO, CreateCompanyDTO, UpdateCompanyDTO>
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
        public Result<GetCompanyDTO> Create(CreateCompanyDTO createDto)
        {
            Company company = _mapper.Map<Company>(createDto);
            //validate
            _db.CompanyDbSet.Add(company);
            _db.SaveChanges();
            return new Result<GetCompanyDTO>(true, _mapper.Map<GetCompanyDTO>(company), null);
        }

        public Result<GetCompanyDTO> Edit(int Id, UpdateCompanyDTO updateDto)
        {
            var company = _db.CompanyDbSet.Find(Id);
            if (company == null)
            {
                return new Result<GetCompanyDTO>(false, null, new List<string> { "Company Not Found" });
            }
            _mapper.Map(updateDto, company);
            _db.SaveChanges();
            return new Result<GetCompanyDTO>(true, _mapper.Map<GetCompanyDTO>(company), null);
            
        }
        public Result<bool> Delete(int Id)
        {
            var company = _db.CompanyDbSet.Find(Id);
            if (company == null)
            {
                return new Result<bool>(false, false, new List<string> { "Company Not Found" });
            }
            _db.CompanyDbSet.Remove(company);
            _db.SaveChanges();
            return new Result<bool>(true, true, null);
        }
    }
}
