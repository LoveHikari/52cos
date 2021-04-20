using Com.Cos.DAL;
using Com.Cos.IBLL;
using Com.Cos.Models;

namespace Com.Cos.BLL
{
    public class MenuModuleService : BaseService<MenuModule>, IMenuModuleService
    {
        public MenuModuleService() : base(RepositoryFactory.MenuModuleRepository)
        {
        }
    }
}