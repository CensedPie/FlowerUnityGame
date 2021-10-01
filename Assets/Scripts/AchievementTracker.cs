using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementTracker : MonoBehaviour
{
    private float timer = 0f;
    private Queue<Achievement> achievementUnlocked = new Queue<Achievement>();
    public Achievement[] achievementsList;
    public Text achievementTitle;
    public Text achievementDescription;
    public GameObject achievementPopUp;
    public Image achievementImage;
    private Achievement displayAchievement;
    
    // Should be populated from list and have trigger in achievement class
    public AchievementTracker()
    {
        /*achievementsList.Add(new Achievement("Intermediate", "Get 5 correct answers in a row", 5, Achievement.GoalType.CorrectRow));
        achievementsList.Add(new Achievement("Experienced", "Get 10 correct answers in a row", 10, Achievement.GoalType.CorrectRow));
        achievementsList.Add(new Achievement("Expert", "Get 15 correct answers in a row", 15, Achievement.GoalType.CorrectRow));
        achievementsList.Add(new Achievement("On Fire", "Get 20 correct answers in a game", 20, Achievement.GoalType.Total));
        achievementsList.Add(new Achievement("Misclicked", "Get 3 incorrect answers in a row", 3, Achievement.GoalType.IncorrectRow));
        achievementsList.Add(new Achievement("On Purpose", "Get 5 incorrect answers in a row", 5, Achievement.GoalType.IncorrectRow));
        achievementsList.Add(new Achievement("AFK", "Get 0 correct answers in a game", 0, 0, Achievement.GoalType.TimeTotal));
        achievementsList.Add(new Achievement("Impossible", "Get only correct answers in a game", 0, 0, Achievement.GoalType.TimeCorrectRow));*/
    }

    void Awake()
    {
        
    }

    public void CheckTriggerAchievement(int score, int correctInARow, int incorrectInARow, float timeLimit)
    {
        for(int i = 0; i < achievementsList.Length; i++)
        {
            if(!achievementsList[i].Completed())
            {
                switch (achievementsList[i].GetGoal())
                {
                    case Achievement.GoalType.CorrectRow:
                        if(correctInARow == achievementsList[i].GetRequiredAmount())
                        {
                            achievementsList[i].Trigger();
                            achievementUnlocked.Enqueue(achievementsList[i]);
                        }
                        break;
                    case Achievement.GoalType.IncorrectRow:
                        if(incorrectInARow == achievementsList[i].GetRequiredAmount())
                        {
                            achievementsList[i].Trigger();
                            achievementUnlocked.Enqueue(achievementsList[i]);
                        }
                        break;
                    case Achievement.GoalType.Total:
                        if(score == achievementsList[i].GetRequiredAmount())
                        {
                            achievementsList[i].Trigger();
                            achievementUnlocked.Enqueue(achievementsList[i]);
                        }
                        break;
                    case Achievement.GoalType.TimeTotal:
                        if((int)timeLimit <= achievementsList[i].GetTime() && score == achievementsList[i].GetRequiredAmount())
                        {
                            achievementsList[i].Trigger();
                            achievementUnlocked.Enqueue(achievementsList[i]);
                        }
                        break;
                    case Achievement.GoalType.TimeCorrectRow:
                        if(correctInARow == score && timeLimit <= achievementsList[i].GetTime())
                        {
                            achievementsList[i].Trigger();
                            achievementUnlocked.Enqueue(achievementsList[i]);
                        }
                        break;
                }
            }
        }
    }
    void Update()
    {
        if(timer > 0f)
        {
            timer -= Time.deltaTime;
        }
        if(timer > 0f && !achievementPopUp.activeSelf)
        {
            achievementPopUp.SetActive(true);
        }
        else if(timer <= 0f && achievementPopUp.activeSelf)
        {
            achievementPopUp.SetActive(false);
        }
        if(timer <= 0f && achievementUnlocked.Count > 0)
        {
            timer = 3f;
            displayAchievement = achievementUnlocked.Dequeue();
            achievementTitle.text = displayAchievement.GetTitle();
            achievementDescription.text = displayAchievement.GetDescription();
            achievementImage.sprite = displayAchievement.GetSprite();
        }
    }
}
