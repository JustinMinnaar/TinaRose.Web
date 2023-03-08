namespace TinaRose.BlazorApp3.Data;

public class Agent
{
    public int AgentId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? CellPhoneNumber { get; set; }
    public string? City { get; set; }
    
    public byte[]? ProfilePictureBytes { get; set; }
    public string? ProfileDescription { get; set; }

    public string? IdentityNumber { get; set; }
    public string? PhysicalAddress { get; set; }
    public byte[]? IdentityDocumentBytes { get; set; }

    public bool Approved { get; set; }
    public Guid? ApprovedByUserId { get; set; }
    public DateTime? ApprovedOnDate { get; set; }
}
