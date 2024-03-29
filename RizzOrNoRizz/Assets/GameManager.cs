using System.Collections;
    using System.Collections.Generic;
    using TMPro;
    using UnityEngine;
    using UnityEngine.Rendering;
    using UnityEngine.SceneManagement;
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

    public TMP_Text scoreText;
    public TMP_Text finalScoreText;
    public TMP_Text gradeText;

    public List<Sprite> barsLevels;
    public Image rizzometer;
    public List<Sprite> dateLevels;
    public Image dateImg;

    public int index = 0;
    public int round = 0;

    public AudioSource ClickA;
    public AudioSource ClickB;
    public AudioSource ClickC;
    public AudioSource ClickD;

    public GameObject promptUI;
    public GameObject scoreUI;
    public GameObject finalScoreUI;

    // Start is called before the first frame update
    void Start()
    {
        AllQuestions = this.GetComponent<PopulateQuestions>().AllQuestions;
        changeText();

        round = 0;
        currentDiff.score = 0;

        promptUI.SetActive(true);
        scoreUI.SetActive(false);
        finalScoreUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (round == 5)
        {
            //set all open screens to inactive and final score to active
            promptUI.SetActive(false); scoreUI.SetActive(false);
            finalScoreUI.SetActive(true);
            if (currentDiff.difficulty == 1)
            {
                finalScoreText.text = "Score = " + currentDiff.score + "RP";
                if (currentDiff.score >= 1250)
                {
                    gradeText.text = "Grade: Ugh, get away from me creep";

                }
                if (currentDiff.score >= 1500)
                {
                    gradeText.text = "Grade: I guess I'll go out with you";
                }
                if (currentDiff.score >= 1750)
                { 
                    gradeText.text = "Grade: Rizzy"; 
                }
                if (currentDiff.score >= 2000)
                {
                    gradeText.text = "Grade: Rizzlord";
                }
                if (currentDiff.score >= 2250)
                {
                    gradeText.text = "Grade: Rizzgod";
                }
            }
            else //HARD MODE
            {
                finalScoreText.text = "Score = " + currentDiff.score + "RP";
                if (currentDiff.score <= 1250)
                    gradeText.text = "Grade: Ugh, get away from me creep";
                if (currentDiff.score >= 1500)
                    gradeText.text = "Grade: I guess I'll go out with you";
                if (currentDiff.score >= 1750)
                    gradeText.text = "Grade: Rizzy";
                if (currentDiff.score >= 2000)
                    gradeText.text = "Grade: Rizzlord";
                if (currentDiff.score >= 2250)
                    gradeText.text = "Grade: Rizzgod";
            }
        }


    }

    public void newRound()
    {
        round++;
        AllQuestions.RemoveAt(index);
        changeText();
    }
    void changeText()
    {
        if (round < AllQuestions.Count)
        {
            index = Random.Range(0, AllQuestions.Count);

            Prompt.text = AllQuestions[index].Ask.whatTheyAsked;
            bA.text = AllQuestions[index].A.CurrentAnswer;
            bB.text = AllQuestions[index].B.CurrentAnswer;
            bC.text = AllQuestions[index].C.CurrentAnswer;
            bD.text = AllQuestions[index].D.CurrentAnswer;

            Debug.Log(bA.text);
        }
    }

    public void ClickButtonA()
    {
        ClickA.Play();
        Debug.Log(ClickA.volume);
        currentDiff.score += AllQuestions[index].A.Value;
        scoreText.text = "+" + AllQuestions[index].A.Value + "RP";

        if (AllQuestions[index].A.Value < 100)
        {
            rizzometer.sprite = barsLevels[0];
            dateImg.sprite = dateLevels[0];
        }
        if (AllQuestions[index].A.Value >= 100)
        {
            rizzometer.sprite = barsLevels[1];
            dateImg.sprite = dateLevels[1];
        }
        if (AllQuestions[index].A.Value >= 300)
        {
            rizzometer.sprite = barsLevels[2];
            dateImg.sprite = dateLevels[2];
        }
        if (AllQuestions[index].A.Value >= 500)
        {
            rizzometer.sprite = barsLevels[3];
            dateImg.sprite = dateLevels[3];
        }
    }
    public void ClickButtonB()
    {
        ClickB.Play();
        currentDiff.score += AllQuestions[index].B.Value;
        scoreText.text = "+" + AllQuestions[index].B.Value + "RP";

        if (AllQuestions[index].B.Value < 100)
        {
            rizzometer.sprite = barsLevels[0];
            dateImg.sprite = dateLevels[0];
        }
        if (AllQuestions[index].B.Value >= 100)
        {
            rizzometer.sprite = barsLevels[1];
            dateImg.sprite = dateLevels[1];
        }
        if (AllQuestions[index].B.Value >= 300)
        {
            rizzometer.sprite = barsLevels[2];
            dateImg.sprite = dateLevels[2];
        }
        if (AllQuestions[index].B.Value >= 500)
        {
            rizzometer.sprite = barsLevels[3];
            dateImg.sprite = dateLevels[3];
        }
    }
    public void ClickButtonC()
    {
        ClickC.Play();
        currentDiff.score += AllQuestions[index].C.Value / currentDiff.difficulty;
        scoreText.text = "+" + AllQuestions[index].C.Value / currentDiff.difficulty + "RP";

        if (AllQuestions[index].C.Value < 100)
        {
            rizzometer.sprite = barsLevels[0];
            dateImg.sprite = dateLevels[0];
        }
        if (AllQuestions[index].C.Value >= 100)
        {
            rizzometer.sprite = barsLevels[1];
            dateImg.sprite = dateLevels[1];
        }
        if (AllQuestions[index].C.Value >= 300)
        {
            rizzometer.sprite = barsLevels[2];
            dateImg.sprite = dateLevels[2];
        }
        if (AllQuestions[index].C.Value >= 500)
        {
            rizzometer.sprite = barsLevels[3];
            dateImg.sprite = dateLevels[3];
        }
    }
    public void ClickButtonD()
    {
        ClickD.Play();
        currentDiff.score += AllQuestions[index].D.Value;
        scoreText.text = "+" + AllQuestions[index].D.Value + "RP";

        if (AllQuestions[index].D.Value < 100)
        {
            rizzometer.sprite = barsLevels[0];
            dateImg.sprite = dateLevels[0];
        }
        if (AllQuestions[index].D.Value >= 100)
        {
            rizzometer.sprite = barsLevels[1];
            dateImg.sprite = dateLevels[1];
        }
        if (AllQuestions[index].D.Value >= 300)
        {
            rizzometer.sprite = barsLevels[2];
            dateImg.sprite = dateLevels[2];
        }
        if (AllQuestions[index].D.Value >= 500)
        {
            rizzometer.sprite = barsLevels[3];
            dateImg.sprite = dateLevels[3];
        }
    }

    public void GoToMenu()
    {
        for (int i = 0; i < 5; i++)
        {
            if (currentDiff.score == 0)
            {
                currentDiff.index = i;
                break;
            }
            else
            {
                //currentDiff.index = i;
            }
        }

        SceneManager.LoadScene("Menu");
    }
    public void Restart()
    {
        if (currentDiff.difficulty == 1) 
            SceneManager.LoadScene("EasyMode");
        if (currentDiff.difficulty == 2)
            SceneManager.LoadScene("HardMode");
        
    }
}
