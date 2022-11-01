using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Voluntari.Services
{
    public interface IDataStore<T>
    {
        Task<bool> AddItemAsync(T item);
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);
        Task<IEnumerable<Voluntari.Models.Category>> GetCategoriesAsync();
        Task<bool> FinishRequestAsync(T item);
    }
}
