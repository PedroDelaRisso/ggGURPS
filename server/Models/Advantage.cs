public class Advantage
{
    public long Id { get; set; }

    public string Title { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }

    public Advantage(string title, int price)
    {
        Title = title;
        Price = price;
    }
}