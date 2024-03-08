using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGen : MonoBehaviour
{

    private GameObject headgo; //head Game Object
    private GameObject bodygo; // body Game Object


    public List<Color> headColors;
    public List<Color> bodyColors;


    public GameObject charPrefab;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Making Character!");
            GenerateRandomStudent();
        }
    }

    void GenerateRandomStudent()
    {
        GameObject studentInstance = Instantiate(charPrefab, new Vector3(0,0,0), Quaternion.identity);
        SpriteRenderer headGen = studentInstance.transform.GetChild(0).GetComponent<SpriteRenderer>();
        SpriteRenderer bodyGen = studentInstance.transform.GetChild(1).GetComponent<SpriteRenderer>();

        Color headColor = headColors[Random.Range(0, headColors.Count)];
        headGen.color = headColor;
            

        Color bodyColor = bodyColors[Random.Range(0, bodyColors.Count)];
        bodyGen.color = bodyColor;


    }
}
