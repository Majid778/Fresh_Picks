using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    public int quizno;
    public List<QnA> QnA;
    public GameObject[] options;
    public Button[] button;
    public int currentQuestion;
    public GameObject Quizpanel;
    public GameObject GoPanel;

    public Text QuestionTxt;
    public Text ScoreTxt;

    int totalQuestions = 0;
    public int score;
    public int sceneIndex, levelPassed;
    private void Start()
    {
        Togglebutton();
        totalQuestions = QnA.Count;
        GoPanel.SetActive(false);
        generateQuestion();
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        levelPassed = PlayerPrefs.GetInt("LevelPassed");
        Debug.Log(sceneIndex);
        Debug.Log(levelPassed);
    }
    public void retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void GameOver()
    {
        if (score >= 4)
        {
            YouPass();
        }
        else
        {
            YouFail();
        }
        Quizpanel.SetActive(false);
        GoPanel.SetActive(true);
    }

    public void correct()
    {
        //when you are right
        score += 1;
        QnA.RemoveAt(currentQuestion);
        Togglebutton();
        StartCoroutine(waitForNext());
    }

    public void wrong()
    {
        //when you answer wrong
        QnA.RemoveAt(currentQuestion);
        Togglebutton();
        StartCoroutine(waitForNext());
      
    }

    IEnumerator waitForNext()
    {
        yield return new WaitForSeconds(1);
        generateQuestion();
    }

    void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<Image>().color = options[i].GetComponent<AnswerScript>().startColor;
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].Answers[i];

            if (QnA[currentQuestion].CorrectAnswer == i + 1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

    void generateQuestion()
    {
        Togglebutton();
        if (QnA.Count > 0)
        {
            currentQuestion = Random.Range(0, QnA.Count);

            QuestionTxt.text = QnA[currentQuestion].Question;
            SetAnswers();
        }
        else
        {
            Debug.Log("Out of Questions");
            GameOver();
        }
    }
    void YouPass()
    {
        ScoreTxt.text = "You Passed! \n \n You got ";
        ScoreTxt.text += score +"/5 questions correct";
        PlayerPrefs.SetInt("result", 1);
        Debug.Log(PlayerPrefs.GetInt("result"));
        if (levelPassed < sceneIndex)
        {
            PlayerPrefs.SetInt("LevelPassed", sceneIndex);
            PlayerPrefs.SetInt(sceneIndex.ToString(), score);
            Debug.Log(PlayerPrefs.GetInt(sceneIndex.ToString()));
        }
    }
    void YouFail()
    {
        PlayerPrefs.SetInt("result", 2);
        ScoreTxt.text = "You Failed! \n \n You got ";
        ScoreTxt.text += score + "/5 questions correct";
        if (levelPassed < sceneIndex)
        {
            PlayerPrefs.SetInt(sceneIndex.ToString(), score);
            Debug.Log(PlayerPrefs.GetInt(sceneIndex.ToString()));
        }
    }
    void Togglebutton()
    {
        for (int i = 0; i < button.Length; i++)
        {
            button[i].interactable = !button[i].interactable;
        }
    }
}
