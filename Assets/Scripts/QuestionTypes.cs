using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flower420/Question Types Object")]
public class QuestionTypes : ScriptableObject
{
    string[] questionType = { "What species does (insert) belong to?", "What is the common name for (insert)?", "With which family is (insert) associated with?", "What is the correct order for (insert)?" };

    public string[] GenerateQuestionAndCorrectAnswer(Plant plant)
    {
        string[] questionAndAnswer = new string[2];
        int type = Random.Range(0, questionType.Length);
        int randomProperty = type;
        while(randomProperty == type)
        {
            randomProperty = Random.Range(0, plant.GetPropertiesLength());
        }
        questionAndAnswer[0] = questionType[type].Replace("(insert)", plant.GetByID(randomProperty));
        questionAndAnswer[1] = plant.GetByID(type);
        return questionAndAnswer;
    }
    public string GenerateFakeAnswer(Plant plant)
    {
        int randomProperty = Random.Range(0, plant.GetPropertiesLength());
        return plant.GetByID(randomProperty);
    }
}
