using System.Collections.Generic;

namespace ImageGallery.Sevices
{
    public interface ICRUDService<T>
    {
        T Get(int id);
        IList<T> GetAll();
        T CreateOrUpdate(T item);
        bool Delete(T item);

    }
}
