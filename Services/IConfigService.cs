namespace Museum.Paleontology.Services;

public interface IConfigService
{
    string? GetSetting(string key);
    string? GetConnectionString(string name);
    AppSettings GetAllSettings();
}

public class AppSettings
{
    public string AppName { get; set; } = string.Empty;
    public string Version { get; set; } = string.Empty;
    public int MaxItems { get; set; }
}