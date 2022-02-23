using System.Linq;
using Domain.Models;
using Domain.Interfaces;
using System.Collections.Generic;

namespace Infrastructure
{
    public class MisionRepository : IMisionRepository
    {
        public MisionDbContext dbContext { get; set; }
        public MisionRepository(MisionDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public void Add(MisionModel misionModel)
        {
            dbContext.Mision.Add(misionModel);
            dbContext.SaveChanges();
        }

        public MisionModel GetById(int id)
        {
            return dbContext.Mision.Find(id);
        }

        public MisionModel GetLastMision()
        {
            return dbContext.Mision.OrderByDescending(p => p.Id).FirstOrDefault();
        }

        public List<MisionModel> GetAllMisions()
        {
            return dbContext.Mision.ToList();
        }
    }
}
