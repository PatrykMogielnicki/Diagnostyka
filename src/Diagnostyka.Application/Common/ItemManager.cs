using Diagnostyka.Application.Common.Interfaces;
using Diagnostyka.Domain.Entities;

namespace Diagnostyka.Application.Common
{
    public class ItemManager : GenericManager<Item>, IItemManager
    {
        public ItemManager(IDiagnostykaDbContext context) : base(context)
        {
        }
    }
}
