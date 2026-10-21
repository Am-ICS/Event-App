namespace Weather.Services;

public interface IStorageService
{
    public Task<String> LoadZipAsync();
    public Task Save(string zip);
}