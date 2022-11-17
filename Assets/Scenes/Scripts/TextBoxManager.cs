using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextBoxManager : MonoBehaviour
{
    public GameObject Panel;
    public GameObject textBox;
    public TextMeshProUGUI theText;
    public TextAsset textFile;
    public TextAsset textFilefail;
    public TextAsset textFilepass;
    public string[] textLines;
    public int currentLine;
    public int endAtLine;
    public bool temp = false;
    public bool finished;
    public string sentence;
    public QuizManager quizManager;
  
public void nextline()
    {
        temp = true;
    }

    public void OpenPanel()
    {
        if (Panel != null)
        {
            Panel.SetActive(true);
        }
    }
    // Update is called once per frame
    void Start()
    {
       
        if (PlayerPrefs.GetInt("result") == 1)
        {
            textLines = (textFilepass.text.Split('\n'));

        }
        else if (PlayerPrefs.GetInt("result") == 2)
        {
            textLines = (textFilefail.text.Split('\n'));
        }
        else
        {
            textLines = (textFile.text.Split('\n'));
        }
        if (endAtLine == 0)
        {
            endAtLine = textLines.Length - 1;
        }
        
        IEnumerator TypeSentence(string sentence)
        {

            finished = false;
            sentence = textLines[currentLine];
            theText.text = "";
            foreach (char letter in sentence.ToCharArray())
            {
                theText.text += letter;
                yield return new WaitForSeconds(0.02f);
            }
            finished = true;
        }
        StartCoroutine(TypeSentence(sentence));
    }
    void Update()
    {
        IEnumerator TypeSentence(string sentence)
        {
            finished = false;
            if (currentLine > endAtLine)
            {
                textBox.SetActive(true);
            }
            sentence = textLines[currentLine];
            theText.text = "";
            foreach (char letter in sentence.ToCharArray())
            {
                theText.text += letter;
                yield return new WaitForSeconds(0.02f);
            }
            finished = true;
        }
        if(temp == true  && currentLine +1 < endAtLine)
        {
            StopAllCoroutines();
            currentLine += 1;
            StartCoroutine(TypeSentence(sentence));
            temp = false;
        }
        else if (temp == true && currentLine > endAtLine)
        {
            temp = false;
        }
        else if (temp == true && currentLine == endAtLine-1)
        {
            temp = true;
            currentLine += 1;
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));          
            OpenPanel();            
        }
    

    }
}

    

   

