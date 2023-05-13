namespace SimpleExpenseManagement.Core.Models.Units;

public class Unit : BaseEntity<Guid>, IActive
{
    public string Title { get; set; }
    public bool IsActive { get ; set ; }
}
