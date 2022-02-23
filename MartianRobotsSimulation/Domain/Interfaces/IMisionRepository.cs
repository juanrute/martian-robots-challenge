using Domain.Models;
using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface IMisionRepository
    {
        List<MisionModel> GetAllMisions();
        MisionModel GetLastMision();
        MisionModel GetById(int id);
        void Add(MisionModel misionModel);
    }
}
