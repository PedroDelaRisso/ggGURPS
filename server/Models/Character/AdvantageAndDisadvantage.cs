public class AdvantageAndDisadvantage
{
    public long Id { get; set; }

    public string Title { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }

    public AffectedAttribute AffectedAttribute { get; set; }

    public AdvantageAndDisadvantage(string title, int price)
    {
        Title = title;
        Price = price;
    }
}