using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CutScene_Events_CS1 : MonoBehaviour
{
    public TextBoxManager textBoxManager;
    public int index;
    
    public void Start()
    {
        textBoxManager = FindObjectOfType<TextBoxManager>();

        FindObjectOfType<SoundManager>().PlaySound("Narrator Voice");
    }

    // Update is called once per frame
    public void Update()
    {
        int currentLine = textBoxManager.currentLine;
        int endAtLine = textBoxManager.endAtLine;

        if (currentLine > endAtLine)
        {
            SceneManager.LoadScene(index);
        }
    }
}
