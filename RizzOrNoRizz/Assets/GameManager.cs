using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    [SerializeField]
    private DifficultySO currentDiff;
    public TMP_Text Prompt;
    public List<FullQuestion> AllQuestions;
    public TMP_Text bA;
    public TMP_Text bB;
    public TMP_Text bC;
    public TMP_Text bD;
    public int score = 0;
    public int index = 0;
    public int round = 1;
    // Start is called before the first frame update
    void Start()
    {
        AllQuestions = this.GetComponent<PopulateQuestions>().AllQuestions;

        index = Random.Range(0, AllQuestions.Count);

        changeText(index);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void changeText(int index)
    {
        Prompt.text = AllQuestions[index].Ask.whatTheyAsked;

        bA.text = AllQuestions[index].A.CurrentAnswer;

        bB.text = AllQuestions[index].B.CurrentAnswer;

        bC.text = AllQuestions[index].C.CurrentAnswer;

        bD.text = AllQuestions[index].D.CurrentAnswer;

    }
    public void ClickButtonA()
    {
        score += AllQuestions[index].A.Value;
        AllQuestions.RemoveAt(index);
        index = Random.Range(0, AllQuestions.Count);

        changeText(index);
        AllQuestions.RemoveAt(index);
        round++;
    }
    public void ClickButtonB()
    {
        score += AllQuestions[index].B.Value;
        AllQuestions.RemoveAt(index);
        index = Random.Range(0, AllQuestions.Count);

        changeText(index);
        AllQuestions.RemoveAt(index);
        round++;
    }
    public void ClickButtonC()
    {
        score += AllQuestions[index].C.Value;
        AllQuestions.RemoveAt(index);
        index = Random.Range(0, AllQuestions.Count);

        changeText(index);
        AllQuestions.RemoveAt(index);
        round++;
        
    }
    public void ClickButtonD()
    {
        score += AllQuestions[index].D.Value;
        AllQuestions.RemoveAt(index);
        index = Random.Range(0, AllQuestions.Count);

        changeText(index);
        AllQuestions.RemoveAt(index);
        round++;
    }
}