using System.Threading.Tasks;
using Com.Cos.Application.Interfaces;
using Com.Cos.Domain.Entity;
using Com.Cos.Infrastructure;

namespace Com.Cos.Application
{
    public class VersionNotesService:BaseService<VersionNotes>, IVersionNotesService
    {
        public VersionNotesService(CosDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<string> FindAsync(string terminal)
        {
            return (await this.VersionNotesRepository.FindAsync(v => v.Terminal == terminal)).Version;
        }
    }
}