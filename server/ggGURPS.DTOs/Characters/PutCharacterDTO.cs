public class PutCharacterDTO
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Age { get; set; }
    public string Birthday { get; set; }
    public string PhysicalDescription { get; set; }

    public PutCharacterDTO(long id, string name, string age, string birthday, string physicalDescription)
    {
        Id = id;
        Name = name;
        Age = age;
        Birthday = birthday;
        PhysicalDescription = physicalDescription;
    }
}