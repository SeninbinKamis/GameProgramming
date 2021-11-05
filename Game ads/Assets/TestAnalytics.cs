using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class TestAnalytics : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Gender gender = Gender.Female;
        Analytics.SetUserGender(gender);
        int birthYear = 1998;
        Analytics.SetUserBirthYear(birthYear);
        Analytics.Transaction("5Diamons", 0.99m, "USD", null, null);
        int totalDeads = 5;
        int totalScores = 100;
        int totalTimes = 120;
        string Level = "Level5";
        Analytics.CustomEvent("Gameplay", new Dictionary<string, object>{
            { "Deads", totalDeads},
            { "Scores", totalScores},
            { "Times", totalTimes},
            { "Level", Level}
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
