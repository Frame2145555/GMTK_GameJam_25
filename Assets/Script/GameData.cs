using UnityEngine;
using System.Collections.Generic;

public class GameData : MonoBehaviour
{
    private static int day;
    public static List<Quest> quests = new List<Quest>();
    public static List<Unit> units = new List<Unit>();
    public static List<Unit> acceptedUnit = new List<Unit>();
    public static List<Unit> rejectedUnit = new List<Unit>();

    public static int Day
    {
        get { return day; }
        set { day = value; }
    }
}
