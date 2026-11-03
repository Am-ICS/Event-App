namespace TodoExplorer.Services;

public class JsonFavoritesStorage : IFavoritesStorage
{
    private string filePath;
    public JsonFavoritesStorage(string directory, string filePath)
    {
        this.filePath = Path.Combine(directory, filePath);
    }
    public Task<List<int>> LoadFavorites()
    {
        if (!File.Exists(filePath))
        {
            return new List<int>();
        }
        StreamReader reader = new StreamReader(filePath);
        string json = reader.ReadToEnd();
        reader.Close();
        return json;
    }

    public Task SaveFavorites(List<int> favoriteIds)
    {
        throw new NotImplementedException();
    }
}