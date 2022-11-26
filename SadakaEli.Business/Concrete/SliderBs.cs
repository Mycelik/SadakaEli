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
    public class SliderBs : ISliderBs
    {
        ISliderRepository _repo;
        public SliderBs(ISliderRepository repo)
        {
            _repo = repo;
        }
        public int Delete(Slider slider)
        {
            return _repo.Delete(slider);
        }

        public void Delete(int id)
        {
            _repo.Delete(GetById(id));
        }

        public List<Slider> GetAll(Expression<Func<Slider, bool>> filter = null)
        {
            return _repo.GetAll(filter);
        }

        public List<Slider> GetAllActive(Expression<Func<Slider, bool>> filter = null)
        {
            return _repo.GetAll(filter).Where(x => x.IsActive.Value).ToList();
        }

        public Slider GetById(int id)
        {
            return _repo.GetById(id);
        }


        public Slider Insert(Slider slider)
        {
            return _repo.Insert(slider);
        }

        public Slider Update(Slider slider)
        {
            return _repo.Update(slider);
        }

        public Slider Get(Expression<Func<Slider, bool>> filter)
        {
            return _repo.Get(filter);
        }
    }
}
