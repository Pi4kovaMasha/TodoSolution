using System.Text.Json.Serialization;

public class TodoItem
{
    [JsonInclude]
    public Guid Id { get; private set; }

    [JsonInclude]
    public string Title { get; private set; }

    [JsonInclude]
    public bool IsDone { get; private set; }

    // ВАЖНО! Пустой конструктор для JSON
    public TodoItem() { }

    public TodoItem(string title)
    {
        Id = Guid.NewGuid();
        Title = title?.Trim() ?? throw new ArgumentNullException(nameof(title));
    }

    public void MarkDone() => IsDone = true;
    public void MarkUndone() => IsDone = false;

    public void Rename(string newTitle)
    {
        if (string.IsNullOrWhiteSpace(newTitle))
            throw new ArgumentException("Title required", nameof(newTitle));

        Title = newTitle.Trim();
    }
}
