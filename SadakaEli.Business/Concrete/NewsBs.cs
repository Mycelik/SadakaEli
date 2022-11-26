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
    public class NewsBs :INewsBs
    {
        INewsRepository _repo;

        public NewsBs(INewsRepository repo)
        {
            _repo = repo;
        }

        public int Delete(News news)
        {
            return _repo.Delete(news);
        }

        public void Delete(int id)
        {
            _repo.Delete(GetById(id));
        }

        public List<News> GetAll(Expression<Func<News, bool>> filter = null)
        {
            return _repo.GetAll(filter);
        }

        public List<News> GetAllActive(Expression<Func<News, bool>> filter = null)
        {
            return _repo.GetAll(filter).Where(x => x.IsActive.Value).ToList();
        }


        public News GetById(int id)
        {
            return _repo.GetById(id);
        }


        public News Insert(News news)
        {
            return _repo.Insert(news);
        }



        public News Update(News news)
        {
            return _repo.Update(news);
        }

        public News Get(Expression<Func<News, bool>> filter)
        {
            return _repo.Get(filter);
        }
    }
}
