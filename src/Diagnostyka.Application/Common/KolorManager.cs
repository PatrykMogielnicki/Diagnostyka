using Diagnostyka.Application.Common.Interfaces;
using Diagnostyka.Domain.Entities;

namespace Diagnostyka.Application.Common
{
    public class KolorManager : GenericManager<Kolor>, IKolorManager
    {
        public KolorManager(IDiagnostykaDbContext context) : base(context)
        {
        }

        public void Deactivate(int id)
        {
            Kolor kolor = Context.Set<Kolor>().SingleOrDefault(k => k.Id == id);
            kolor.Active = false;
            Context.SaveChanges();
        }
    }
}
