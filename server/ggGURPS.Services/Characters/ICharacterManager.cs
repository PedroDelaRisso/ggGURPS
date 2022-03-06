using System.Threading.Tasks;

public interface ICharacterManager
{
    Task<Character> Create(Character character);
    Task<Item> AddItem(int characterId, Item item);
    Task<Skill> AddSkill(int characterId, Skill skill);
    Task<Character>  GetById(int id);
    Task<CustomRoll> AddCustomRoll(int characterId, CustomRoll customRoll);
}