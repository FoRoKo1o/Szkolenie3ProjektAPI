using Szkolenie3API.Contrats;
using Szkolenie3API.Data;

namespace Szkolenie3API.Repository
{
    public class CatsRepository : GenericRepository<Cat>, ICatsRepository
    {
        public CatsRepository(ProjektDbContext context) : base(context)
        {
        }
    }
}
