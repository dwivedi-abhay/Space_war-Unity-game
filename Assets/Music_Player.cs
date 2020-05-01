using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Music_Player : MonoBehaviour
{

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
        Invoke("PlayMainScreen", 2f);
    }

    private void PlayMainScreen()
    {
        SceneManager.LoadScene(1);
    }
}
