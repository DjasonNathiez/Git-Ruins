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

        if (Input.GetButtonDown("Cancel"))
        {
            currentLine += 1;
        }


        if(currentLine > endAtLine)
        {
            textBox.SetActive(false);
            DestroyObject(gameObject);
        }
    }

}
