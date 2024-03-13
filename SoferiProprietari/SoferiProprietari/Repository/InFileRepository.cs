using SoferiProprietari.Domain;
using SoferiProprietari.Repository.utils;

namespace SoferiProprietari.Repository;

public delegate E CreateEntity<E>(string line);

public abstract class InFileRepository<ID, E> : InMemoryRepository<ID, E> where E : IHadID<ID>
{
    protected string fileName;
    protected CreateEntity<E> createEntity;

    public InFileRepository(String fileName, CreateEntity<E> createEntity)
    {
        this.fileName = fileName;
        this.createEntity = createEntity;
        if (createEntity != null)
            loadFromFile();
    }

    protected virtual void loadFromFile()
    {
        List<E> list = DataReader.ReadData(fileName, createEntity);
        list.ForEach(x => _dictionary[x.Id] = x);
    }


}
