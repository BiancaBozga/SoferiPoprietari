using SoferiProprietari.Domain;

namespace SoferiProprietari.Repository;

public class InMemoryRepository<ID, E> : IRepository<ID, E> where E : IHadID<ID>
{
    protected IDictionary<ID, E> _dictionary = new Dictionary<ID, E>();
        
   

    public IEnumerable<E> FindAll()
    {
        return _dictionary.Values;
    }

    
    
}