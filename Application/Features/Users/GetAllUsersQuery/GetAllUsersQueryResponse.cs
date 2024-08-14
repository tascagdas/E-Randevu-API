namespace Application.Features.Users.GetAllUsersQuery;

public class GetAllUsersQueryResponse
{
    public Guid Id { get; set; }
    public string? FirstName { get; set; } 
    public string? LastName { get; set; } 
    public string? FullName { get; set; } 
    public string? Email { get; set; }
    public string? UserName { get; set; } 
    public List<Guid>? RoleIds { get; set; } 
    public List<string?>? RoleNames { get; set; }
}