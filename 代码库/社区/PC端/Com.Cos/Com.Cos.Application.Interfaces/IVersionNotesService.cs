using System.Threading.Tasks;
using Com.Cos.Domain.Entity;

namespace Com.Cos.Application.Interfaces
{
    public interface IVersionNotesService:IBaseService<VersionNotes>
    {
        Task<string> FindAsync(string terminal);
    }
}