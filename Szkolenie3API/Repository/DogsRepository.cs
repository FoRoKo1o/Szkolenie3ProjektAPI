using Szkolenie3API.Contrats;
using Szkolenie3API.Data;

namespace Szkolenie3API.Repository
{
    public class DogsRepository : GenericRepository<Dog>, IDogsRepository
    {
        public DogsRepository(ProjektDbContext context) : base(context)
        {
        }
    }
}
