using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flower420/Plant Collection Object")]
public class PlantCollection : ScriptableObject
{
    private List<Plant> plantsList = new List<Plant>();

    public void GenerateList()
    {
        TextAsset plantsData = Resources.Load<TextAsset>("PlantsData");

        string[] data = plantsData.text.Split(new char[] { '\n' });

        for(int i = 1; i < data.Length - 1; i++)
        {
            string[] row = data[i].Split(new char[] { ',' });
            plantsList.Add(new Plant(row[0], row[1], row[2], row[3]));
        }
    }
    public int GetLength()
    {
        return plantsList.Count;
    }
    public Plant GetPlantByID(int id)
    {
        return plantsList[id];
    }
}
