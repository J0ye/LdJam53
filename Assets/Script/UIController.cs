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

    [SerializeField]
    private GameObject mainMenu;

    [SerializeField]
    private TMP_Text scoreText;

    [SerializeField]
    private GameObject endScreen;
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
        if (mainMenu.activeInHierarchy)
        {
            mainMenu.SetActive(false);
            GameController.instance.PauseLevel();
        }
        else
        {
            GameController.instance.ResumeLevel();
            mainMenu.SetActive(true);
        }
    }

    public void ShowEndScreen(int score)
    {
        endScore.text = score.ToString();
        endScreen.SetActive(true);
        audioSource.Play();
    }

    public void HideEndScreen()
    {
        endScreen.SetActive(false);
    }
}
