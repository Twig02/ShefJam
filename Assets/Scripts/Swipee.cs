using UnityEngine;
using System.IO;

public class Swipee
{
    public string Name;
    public string[] Looks;
    public string Personality;
    public int Age;
    public string Height;
    public string Job;
    public string DatingIntentions;
    public int RicePurityScore;
    public string Description;

    protected static string[] hairLength = { "Short", "Medium", "Long" };
    protected static string[] hairColour = { "Blonde", "Brown", "Evie" };
    protected static string[] eyeColour = { "Brown", "Blue", "Green" };
    protected static string[] glasses = { "Glasses", "No glasses" };
    protected static string[] personalities = { "Flirty", "Chav", "Dry", "Nerd", "Northern Soul" };
    protected static string[] jobs = { "Diamond Plug Fixer", "Unemployed", "Pint pourer", "Maccies slave", "Dictator", "Failing musician", "Finance bro", "Uber Eats", "Stripper", "Cereal killer", "Bossman at kebab shop", "Celebrity (on the list)", "Eduroam support", "Politician", "Toilet cleaner", "Lockheed Martin engineer", "Denver Airport baggage handler", "Emo barista", "Uni lecturer", "Student", "Alcoholic", "Evil scientist", "Bouncer", "Drug dealer", "Endcliffe maintenance", "Vietnam veteran", "White van driver", "Fortune teller", "Benefit scrounger", "Eco warrior" };
    protected static string[] datingGoals = { "Shags", "Confused.com", "Gets aftercare", "Wifey", "Greedy" };

    public Swipee(System.Random rnd) {
        string[] allNames = File.ReadAllLines("assets/misc/Names.txt");
        Name = allNames[rnd.Next(allNames.Length)];
        
        Looks = new string[] { 
            hairLength[rnd.Next(hairLength.Length)], 
            hairColour[rnd.Next(hairColour.Length)], 
            eyeColour[rnd.Next(eyeColour.Length)], 
            glasses[rnd.Next(glasses.Length)] 
        };

        Personality = personalities[rnd.Next(personalities.Length)];
        Age = rnd.Next(18, 100);
        
        // Formatting height as X'Y"
        Height = $"{rnd.Next(4, 7)}'{rnd.Next(12)}\"";
        
        Job = jobs[rnd.Next(jobs.Length)];
        DatingIntentions = datingGoals[rnd.Next(datingGoals.Length)];
        RicePurityScore = rnd.Next(101);
        string[] allDescriptions = File.ReadAllLines("assets/misc/Descriptions.txt");
        Description = allDescriptions[rnd.Next(allDescriptions.Length)];
    }
}
