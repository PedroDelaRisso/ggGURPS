public class Skill
{
    public long Id { get; set; }
    public long CharacterId { get; set; }
    public BaseAttribute BaseAttribute { get; set; }
    public SkillDifficulty SkillDifficulty { get; set; }
    public int PointsSpent { get; set; }
    public int SkillLevel { get; set; }
}

/*
    Each Skill starts at Attribute-X, X depends on the difficulty, starting at Easy where X is 0 and
    X = X-1 at each increase in difficulty up to Hard -3. The cost to the second level of any skill
    is 2 points, 2 additional points for the third level and 4 points per level onwards.
*/