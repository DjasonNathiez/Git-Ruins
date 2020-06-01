using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour
{
    public GameObject textBox;

    public Text theText;

    public TextAsset textfile;
    public string[] textLines;

    public int currentLine;
    public int endAtLine;

    public float timeSet;

    public bool automaticReading;

    public CustomCharacterController player;

    public void Start()
    {
        player = FindObjectOfType<CustomCharacterController>();

        if (textfile != null)
        {
            textLines = (textfile.text.Split('\n'));
        }

        if(endAtLine == 0)
        {
            endAtLine = textLines.Length - 1;
        }
    }

    public void Update()
    {
        theText.text = textLines[currentLine];

        if (Input.GetButtonDown("Cancel") && automaticReading == false)
        {
            currentLine += 1;
        }

        if(automaticReading == true)
        {
                StartCoroutine(SkipText());
           
        }

        if(currentLine > endAtLine)
        {
            textBox.SetActive(false);
            DestroyObject(gameObject);
        }
    }

    IEnumerator SkipText()
    {
        yield return new WaitForSeconds(timeSet);
        currentLine += 1;
    }
}
