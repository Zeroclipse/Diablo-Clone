using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreReport : MonoBehaviour
{
    Dictionary<string, Text> scoreBoxes;
    private string firstPerson;
    private string secondPerson;
    private string thirdPerson;
    [SerializeField] List<GameObject> textRefs;
    private void Start()
    {
        scoreBoxes = new Dictionary<string, Text>();
        //if (photonView.IsMine)
        //{
        //    //animator = GetComponent<Animator>();

        //}
        //scoreBoxes.Add("local", GameObject.Find("My Panel").GetComponentInChildren<Text>());
        foreach (GameObject item in textRefs)
        {
            item.SetActive(false);
        }

    }
    public void ScoreUpdate(string ID, int score)
    {
        scoreBoxes[ID].text = ID + ": " + score;
    }

    public void Register(string ID)
    {
        if (ID == "local")
        {
            scoreBoxes.Add("local", textRefs[0].GetComponentInChildren<Text>());
            textRefs[0].SetActive(true);
        }

        else
        {
            scoreBoxes.Add(ID, textRefs[scoreBoxes.Count].GetComponentInChildren<Text>());
            textRefs[scoreBoxes.Count].SetActive(true);
            if (firstPerson == null)
            {
                firstPerson = ID;
            }
            else if (secondPerson == null)
            {
                secondPerson = ID;
            }
            else if (thirdPerson == null)
            {
                thirdPerson = ID;
            }
        }
    }
    public void UnRegister(string ID)
    {
        if (ID == "local")
        {

        }

        else
        {
            scoreBoxes.Remove(ID);
            if (firstPerson != null && firstPerson == ID)
            {
                textRefs[1].SetActive(false);
            }
            else if (secondPerson != null && secondPerson == ID)
            {
                textRefs[2].SetActive(false);
            }
            else if (thirdPerson != null && thirdPerson == ID)
            {
                textRefs[3].SetActive(false);
            }
        }
    }
}
