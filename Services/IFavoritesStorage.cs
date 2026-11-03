using TodoExplorer.Models;

namespace TodoExplorer.Services;

public interface IFavoritesStorage
{
    public Task<List<int>> LoadFavorites();
    public Task SaveFavorites(List<int> favoriteIds);
}