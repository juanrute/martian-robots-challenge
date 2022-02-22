using Domain;
using Domain.Models;
using System.Collections.Generic;
using System.Linq;

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
