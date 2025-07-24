using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.PackageManager;
using UnityEngine;


[System.Serializable]
public enum QuestRank
{
    Slime, Deer, Hunter, Moose, Dragon, HellHound
}
[System.Serializable]

public struct QuestInfo
{
    public string title;
    public string description;
    public QuestRank rank;

    string RandomDescription()
    {
        System.Random random = new System.Random();

        string[] words1 = { "Find", "Defeat", "Rescue", "Escort", "Collect", "Destroy", "Protect" };
        string[] words2 = { "Lost", "Hidden", "Ancient", "Mystic", "Wild", "Dark", "Cursed" };
        string[] words3 = { "Relic", "Beast", "Artifact", "Scroll", "Treasure", "Princess", "Village" };

        int wordCount = random.Next(1, 4); // 1 to 3 words
        string _description = "";

        if (wordCount >= 1)
            _description += words1[random.Next(words1.Length)];

        if (wordCount >= 2)
            _description += " " + words2[random.Next(words2.Length)];

        if (wordCount == 3)
            _description += " " + words3[random.Next(words3.Length)];

        return _description;
    }
    public void RandomSelf()
    {
        string[] nameArr = { "Get down", "Omae wa mou", "Sky so high", "Raiden Shogun", "Super Idol", "King Kong" };
        title = nameArr[UnityEngine.Random.Range(0, nameArr.Length)];
        description = RandomDescription();
        rank = Auxiliary.RandomEnum<QuestRank>();
    }
}

[System.Serializable]
public class Quest
{
    [SerializeField] private QuestInfo info;
    [SerializeField] private Objective objective;
    [SerializeField] private List<Unit> roster = new List<Unit>();

    public QuestInfo Info { get => info; }
    public Objective Objective { get => objective; }
    public Quest(QuestInfo info, Objective objectives)
    {
        this.info = info;
        this.objective = objectives;
    }

    public void AddUnit(Unit unit)
    {
        roster.Add(unit);
        objective.TryAdd(unit);
        
    }

    public bool IsCompleted()
    {
        return objective.IsComplete();
    }

}
