using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    // Members
    public TileChooser tileChooser;
    public GameObject redoButton;

    [SerializeField]
    private TMP_Text scoreText;

    [SerializeField]
    private GameObject endScreen;
    public GameObject pauseMenuButton;
    public GameObject instructionsScreen;
    public GameObject mainMenuScreen;
    public GameObject settingsScreen;
    public GameObject pauseScreen;

    public GameObject instructionsButton;
    public GameObject restartButton;

    [SerializeField]
    private TMP_Text endScore;


    private AudioSource audioSource;

    // Start is called before the first frame update
    void Awake()
    {
        // Create singleton
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
        tileChooser.gameObject.SetActive(false);
        redoButton.SetActive(false);
        pauseMenuButton.SetActive(false);
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// Sets the current score in the UI text field
    /// </summary>
    /// <param name="score"></param>
    public void SetScore(int score)
    {
        scoreText.text = score.ToString();
    }

    /// <summary>
    /// Toggle the main menu on or off
    /// </summary>
    public void ToggleMainMenu()
    {
        instructionsScreen.SetActive(false);
        settingsScreen.SetActive(false);

        if (mainMenuScreen.activeInHierarchy)
        {
            mainMenuScreen.SetActive(false);
            GameController.instance.ResumeLevel();

            if(instructionsButton.activeInHierarchy)
            {
                instructionsButton.SetActive(false);
                restartButton.SetActive(true);
            }
        }
        else
        {
            GameController.instance.PauseLevel();
            mainMenuScreen.SetActive(true);
        }
    }

    public void TogglePauseMenu()
    {
        if (pauseScreen.activeSelf)
        {
            pauseScreen.SetActive(false);
            GameController.instance.ResumeLevel();
        }
        else
        {
            GameController.instance.PauseLevel();
            pauseScreen.SetActive(true);
        }
    }

    public void StartGame()
    {
        mainMenuScreen.SetActive(false);
        instructionsScreen.SetActive(false);
        endScreen.SetActive(false);
        tileChooser.gameObject.SetActive(true);
        redoButton.SetActive(true);
        pauseMenuButton.SetActive(true);
        GameController.instance.StartLevel();
    }

    public void RestartGame()
    {
        mainMenuScreen.SetActive(false);
        instructionsScreen.SetActive(false);
        endScreen.SetActive(false);
        GameController.instance.RestartLevel();
    }

    public void ToggleInstructionsScreen()
    {
        mainMenuScreen.SetActive(false);

        if (instructionsScreen.activeInHierarchy)
        {
            instructionsScreen.SetActive(false);

        }
        else
        {
            instructionsScreen.SetActive(true);
        }
    }

    public void ToggleSettingsScreen()
    {
        mainMenuScreen.SetActive(false);

        if (settingsScreen.activeInHierarchy)
        {
            settingsScreen.SetActive(false);

        }
        else
        {
            settingsScreen.SetActive(true);
        }
    }

    public void ShowEndScreen(int score)
    {
        endScore.text = score.ToString();
        endScreen.SetActive(true);
        //audioSource.Play();
    }

    public void HideEndScreen()
    {
        endScreen.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
