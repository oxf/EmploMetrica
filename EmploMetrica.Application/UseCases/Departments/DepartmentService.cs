using AutoMapper;
using EmploMetrica.Domain.Companies;
using EmploMetrica.Domain.Departments;
using EmploMetrica.Domain.Shared;
using EmploMetrica.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploMetrica.Application.UseCases.Departments
{
    public class DepartmentService(AppDbContext _db, IMapper _mapper): ICrudChildService<GetDepartmentDTO, CreateDepartmentDTO, UpdateDepartmentDTO>
    {
        public Result<List<GetDepartmentDTO>> Get(int CompanyId)
        {
            var company = _db.CompanyDbSet
                .FirstOrDefault(x => x.Id == CompanyId);
            if(company == null)
            {
                return new Result<List<GetDepartmentDTO>>(false, null, new List<string> { "Company was not found" });
            }
            var result = _db.DepartmentDbSet
                .Where(x => x.Company.Id == CompanyId)
                .Select(x => _mapper.Map<GetDepartmentDTO>(x))
                .ToList();
            return new Result<List<GetDepartmentDTO>>(true, result, null);
        }

        public Result<GetDepartmentDTO> GetById(int CompanyId, int Id)
        {
            var company = _db.CompanyDbSet
                .FirstOrDefault(x => x.Id == CompanyId);
            if (company == null)
            {
                return new Result<GetDepartmentDTO>(false, null, new List<string> { "Company was not found" });
            }
            GetDepartmentDTO? result = _db.DepartmentDbSet
                .Where(x => x.Company.Id == CompanyId && x.Id == Id)
                .Select(x => _mapper.Map<GetDepartmentDTO>(x))
                .FirstOrDefault();
            if (result == null)
            {
                return new Result<GetDepartmentDTO>(false, null, new List<string> { "Department was not found" });
            }
            return new Result<GetDepartmentDTO>(true, result, null);
        }
        public Result<GetDepartmentDTO> Create(int CompanyId, CreateDepartmentDTO DepartmentDto)
        {
            Department Department = _mapper.Map<Department>(DepartmentDto);

            Company company = _db.CompanyDbSet.Find(CompanyId);
            if (company == null)
            {
                return new Result<GetDepartmentDTO>(false, null, new List<string> { "Company was not found" });
            }
            bool DepartmentUnique = CheckDepartmentUnique(Department);
            if (!DepartmentUnique)
            {
                return new Result<GetDepartmentDTO>(false, null, new List<string> { "Department already exists" });
            }

            Department.Company = company;
            _db.DepartmentDbSet.Add(Department);
            _db.SaveChanges();

            return new Result<GetDepartmentDTO>(true, _mapper.Map<GetDepartmentDTO>(Department), null);
        }

        private bool CheckDepartmentUnique(Department department)
        {
            return true;
        }

        public Result<GetDepartmentDTO> Edit(int CompanyId, int Id, UpdateDepartmentDTO updatedDepartment)
        {
            Company company = _db.CompanyDbSet.Find(CompanyId);
            if (company == null)
            {
                return new Result<GetDepartmentDTO>(false, null, new List<string> { "Company was not found" });
            }
            Department Department = _db.DepartmentDbSet.Find(Id);
            if (Department == null)
            {
                return new Result<GetDepartmentDTO>(false, null, new List<string> { "Department was not found" });
            }
            bool DepartmentUnique = CheckDepartmentUnique(Department);
            if (!DepartmentUnique)
            {
                return new Result<GetDepartmentDTO>(false, null, new List<string> { "Department already exists" });
            }

            Department.Name = updatedDepartment.Name;
            Department.IsActive = updatedDepartment.IsActive;

            _db.SaveChanges();
            return new Result<GetDepartmentDTO>(true, _mapper.Map<GetDepartmentDTO>(Department), null);
        }

        public Result<bool> Delete(int CompanyId, int Id)
        {
            Company company = _db.CompanyDbSet.Find(CompanyId);
            if (company == null)
            {
                return new Result<bool>(false, false, new List<string> { "Company was not found" });
            }
            Department Department = _db.DepartmentDbSet.Find(Id);
            if (Department == null)
            {
                return new Result<bool>(false, false, new List<string> { "Department was not found" });
            }

            _db.DepartmentDbSet.Remove(Department);
            _db.SaveChanges();
            return new Result<bool>(true, true, null);
        }
    }
}
