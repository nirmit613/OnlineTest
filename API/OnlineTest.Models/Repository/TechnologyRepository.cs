using Microsoft.EntityFrameworkCore;
using OnlineTest.Data;
using OnlineTest.Models;
using OnlineTest.Models.Interfaces;

namespace OnlineTest.Models.Repository
{

    public class TechnologyRepository : ITechnologyRepository
    {
        private readonly OnlineTestContext _context;
        public TechnologyRepository(OnlineTestContext context)
        {
            _context = context;
        }
        public IEnumerable<Technology> GetTechnology()
        {
            return _context.Technologies.Where(t => t.IsActive == true).ToList();
        }

        public Technology GetTechnologybyId(int id)
        {
            return _context.Technologies.FirstOrDefault(t => t.Id == id && t.IsActive == true);
        }
        public Technology GetTechnologyByName(string technologyname)
        {
            return _context.Technologies.FirstOrDefault(u=>u.TechName == technologyname);
        }

        public IEnumerable<Technology> GetTechnologyPagination(int PageNo, int RowsPerPage)
        {
            return _context.Technologies.Where(t => t.IsActive == true).Skip((PageNo - 1) * RowsPerPage).Take(RowsPerPage).ToList();
        }
        public int AddTechnology(Technology technology)
        {
            _context.Add(technology);
            if (_context.SaveChanges() > 0)
                return technology.Id;
            else
                return 0;
        }

        public bool UpdateTechnology(Technology technology)
        {
            _context.Entry(technology).Property("TechName").IsModified = true;
            _context.Entry(technology).Property("ModifiedBy").IsModified = true;
            _context.Entry(technology).Property("ModifiedOn").IsModified = true;
            return _context.SaveChanges() > 0;
        }
        public bool DeleteTechnology(Technology technology)
        {
            _context.Entry(technology).Property("IsActive").IsModified = true;
            return _context.SaveChanges() > 0;
        }
    }
}
