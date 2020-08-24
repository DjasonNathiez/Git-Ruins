using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroy : MonoBehaviour
{

    [SerializeField] private GameObject sfx;
    Scene scene;
    // Start is called before the first frame update
    void Awake()
    {
        scene = SceneManager.GetActiveScene();
        if (scene.buildIndex < 8)
        DontDestroyOnLoad(sfx);

    }

   
}
