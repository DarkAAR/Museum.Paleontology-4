namespace Museum.Paleontology.Services;
public class ConfigService : IConfigService
{
    private readonly IConfiguration _configuration;

    public ConfigService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string? GetSetting(string key)
    {
        return _configuration[key];
    }
    public string? GetConnectionString(string name)
    {
        return _configuration.GetConnectionString(name);
    }

    public AppSettings GetAllSettings()
    {
        return new AppSettings
        {
            AppName = _configuration["AppSettings:AppName"],
            Version = _configuration["AppSettings:Version"],
            MaxItems = int.Parse(_configuration["AppSettings:MaxItems"])
        };
    }
}
