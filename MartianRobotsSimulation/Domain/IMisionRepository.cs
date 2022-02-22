using Domain.Models;
using System.Collections.Generic;

namespace Domain
{
    public interface IMisionRepository
    {
        List<MisionModel> GetAllMisions();
        MisionModel GetLastMision();
        void Add(MisionModel misionModel);
    }
}
