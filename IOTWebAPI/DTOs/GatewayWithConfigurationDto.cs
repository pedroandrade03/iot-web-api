namespace IOTWebAPI.DTOs;

public class GatewayWithConfigurationDto
{
    public int GatewayID { get; set; }
    public string Name { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public bool IsActive { get; set; }
    public string Type { get; set; }
    public DateTime LastCommunication { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public ConfigurationDto Configuration { get; set; }
}