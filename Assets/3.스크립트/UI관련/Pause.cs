using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{

    // 퍼즈(옵션)과 관련된 스크립트

    public static bool isPaused = false;
    public GameObject pauseMenu;

    void Start()
    {
        Time.timeScale = 1;
        isPaused = false;
        pauseMenu.SetActive(isPaused);
    }

    void Update()
    {
        if (Input.GetKeyUp("escape"))
        {
            Resume();
        }
    }

    public void Resume()
    {
        isPaused = !isPaused;
        Time.timeScale = (isPaused) ? 0 : 1;
        pauseMenu.SetActive(isPaused);
    }
}
