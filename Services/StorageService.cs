namespace Weather.Services;

public class StorageService:IStorageService
{
    private string filePath;

    public StorageService(string directory, string filename)
    {
        filePath = Path.Combine(directory, filename);
    }
    public async Task<string> LoadZipAsync()
    {
        if (!File.Exists(filePath))
        {
            return "";
        }

        StreamReader reader = new StreamReader(filePath);
        string zip = await reader.ReadToEndAsync();
        reader.Close();
        return zip;
    }

    public async Task Save(string zip)
    {
        StreamWriter writer = new StreamWriter(filePath);
        await writer.WriteAsync(zip);
        writer.Close();
        
    }
}