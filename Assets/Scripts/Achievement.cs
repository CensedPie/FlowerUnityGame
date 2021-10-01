using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Achievement
{
    public string title;
    public string description;
    private bool triggered;
    public int requiredAmount;
    public int time;
    public GoalType goal;
    public Sprite image;
    public enum GoalType
    {
        CorrectRow,
        IncorrectRow,
        Total,
        TimeTotal,
        TimeCorrectRow,
        TimeIncorrectRow
    }
    public Achievement(string title, string description, int requiredAmount, GoalType goal, Image image)
    {
        triggered = false;
        this.title = title;
        this.description = description;
        this.requiredAmount = requiredAmount;
        this.goal = goal;
        time = 0;
    }
    public Achievement(string title, string description, int requiredAmount, int time, GoalType goal, Image image)
    {
        triggered = false;
        this.title = title;
        this.description = description;
        this.requiredAmount = requiredAmount;
        this.goal = goal;
        this.time = time;
    }
    public void Trigger()
    {
        triggered = true;
    }
    public bool Completed()
    {
        return triggered;
    }
    public int GetRequiredAmount()
    {
        return requiredAmount;
    }
    public int GetTime()
    {
        return time;
    }
    public GoalType GetGoal()
    {
        return goal;
    }
    public string GetTitle()
    {
        return title;
    }
    public string GetDescription()
    {
        return description;
    }
    public Sprite GetSprite()
    {
        return image;
    }
}
