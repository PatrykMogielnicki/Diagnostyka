using Diagnostyka.Domain.Entities;

namespace Diagnostyka.Application.Common.Interfaces
{
    public interface IKolorManager : IGenericManager<Kolor>
    {
        void Deactivate(int entity);
    }
}
