using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public float timeLimit;
    public Text timeText;
    public Text displayText;
    public Text scoreDisplay;
    public Button[] options;
    public PlantCollection plantsListObject;
    public QuestionTypes questionTypesObject;
    public AchievementTracker achievementTracker;
    private string currentQuestion;
    private string correctAnswer;
    private int score = 0;
    private int correctInARow = 0;
    private int incorrectInARow = 0;
    private bool gameEnd = false;
    // Start is called before the first frame update
    void Awake()
    {
        plantsListObject.GenerateList();
        QuestionAndAnswersGenerate();
        for(int i = 0; i < options.Length; i++)
        {
            options[i].onClick.AddListener(ButtonClicked);
        }
        scoreDisplay.text = "" + score;
    }

    public void QuestionAndAnswersGenerate()
    {
        int randID = Random.Range(0, plantsListObject.GetLength());
        string[] questionAndAnswer = questionTypesObject.GenerateQuestionAndCorrectAnswer(plantsListObject.GetPlantByID(randID));
        currentQuestion = questionAndAnswer[0];
        correctAnswer = questionAndAnswer[1];
        displayText.text = currentQuestion;
        int randOption = Random.Range(0, options.Length);
        options[randOption].GetComponentInChildren<Text>().text = correctAnswer;
        options[randOption].GetComponentInChildren<Text>().color = Color.green;
        int randAnswerID = Random.Range(0, plantsListObject.GetLength());
        for(int i = 0; i < options.Length; i++)
        {
            if(i != randOption)
            {
                while(randAnswerID == randID)
                {
                    randAnswerID = Random.Range(0, plantsListObject.GetLength());
                }
                options[i].GetComponentInChildren<Text>().text = questionTypesObject.GenerateFakeAnswer(plantsListObject.GetPlantByID(randAnswerID));
                options[i].GetComponentInChildren<Text>().color = Color.white;
            }
        }
    }
    public void ButtonClicked()
    {
        string chosenAnswer = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text;
        if(chosenAnswer.Equals(correctAnswer))
        {
            score++;
            correctInARow++;
            incorrectInARow = 0;
            scoreDisplay.text = "" + score;
            QuestionAndAnswersGenerate();
        }
        else
        {
            correctInARow = 0;
            incorrectInARow++;
            QuestionAndAnswersGenerate();
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            SceneManager.LoadScene("MainMenu");
        }
        if(gameEnd)
        {
            return;
        }
        if(timeLimit <= 0f)
        {
            gameEnd = true;
            for(int i = 0; i < options.Length; i++)
            {
                options[i].interactable = false;
            }
        }
        if(timeLimit > 0f)
        {
            timeLimit -= Time.deltaTime;
            int seconds = (int)timeLimit;
            timeText.text = (seconds / 60).ToString() + ":" + (seconds % 60).ToString("00");
        }
        achievementTracker.CheckTriggerAchievement(score, correctInARow, incorrectInARow, timeLimit);
    }
}
