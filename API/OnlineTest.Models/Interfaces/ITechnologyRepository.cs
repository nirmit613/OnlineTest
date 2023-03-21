using OnlineTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Models.Interfaces
{
    public interface ITechnologyRepository
    {
        IEnumerable<Technology> GetTechnology();
        IEnumerable<Technology> GetTechnologyPagination(int PageNo, int RowsPerPage);
        Technology GetTechnologybyId(int id);
        Technology GetTechnologyByName(string technologyname);
        int AddTechnology(Technology technology);
        bool UpdateTechnology(Technology technology);
        bool DeleteTechnology(Technology technology);
    }
}
