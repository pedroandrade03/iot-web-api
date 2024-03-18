using IOTWebAPI.Entities;

public class Configuration
{
    public int ConfigurationID { get; set; }
    public int GatewayID { get; set; }
    public string Details { get; set; }
    public Gateway Gateway { get; set; }
}
