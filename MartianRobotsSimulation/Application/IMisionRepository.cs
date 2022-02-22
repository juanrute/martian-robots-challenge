using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    interface IMisionRepository
    {
        //Task<List<Category>> GetCategoriesWithEvents(bool includePassedEvents);
        //Task<bool> IsCategoryName(string name);

        void Add(MisionModel misionModel);
    }
}
