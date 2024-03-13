using SoferiProprietari.Domain;

namespace SoferiProprietari.Repository;

public interface IRepository<ID, E> where E: IHadID<ID>
{
    IEnumerable<E> FindAll();
}