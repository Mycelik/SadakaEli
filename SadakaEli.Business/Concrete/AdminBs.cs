using SadakaEli.Business.AbstractStructure;
using SadakaEli.DataAccess.AbstractStructure;
using SadakaEli.Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SadakaEli.Business.Concrete
{
    public class AdminBs :IAdminBs
    {
        IAdminRepository _repo;

        public AdminBs(IAdminRepository repo)
        {
            _repo = repo;
        }

        public int Delete(Admin admin)
        {
            return _repo.Delete(admin);
        }

        public void Delete(int id)
        {
            _repo.Delete(GetById(id));
        }

        public List<Admin> GetAll(Expression<Func<Admin, bool>> filter = null)
        {
            return _repo.GetAll(filter);
        }

        public List<Admin> GetAllActive(Expression<Func<Admin, bool>> filter = null)
        {
            return _repo.GetAll(filter).Where(x => x.IsActive.Value).ToList();
        }

        public Admin LogIn(string email, string password)
        {
            return _repo.Get(x => x.Email == email && x.Password == password);
        }
        public Admin GetById(int id)
        {
            return _repo.GetById(id);
        }


        public Admin Insert(Admin admin)
        {
            return _repo.Insert(admin);
        }



        public Admin Update(Admin admin)
        {
            return _repo.Update(admin);
        }

        public Admin Get(Expression<Func<Admin, bool>> filter)
        {
            return _repo.Get(filter);
        }
    }
}
