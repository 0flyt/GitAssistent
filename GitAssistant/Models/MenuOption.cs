namespace GitAssistant.Models;

public class MenuOption
{
    public string Id { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public Action Action { get; set; } = default!;
}
