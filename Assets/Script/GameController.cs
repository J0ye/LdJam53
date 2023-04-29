using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : GridOperator
{
    public static GameController instance;
    public Player player;
    public GameObject wallPrefab;

    /// <summary>
    /// The current score
    /// </summary>
    int score = 0;

    /// <summary>
    /// Game is currently paused
    /// </summary>
    bool isPaused;


    protected override void Awake()
    {
        base.Awake();
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        UIController.instance.tileChooser.GenerateRandomTiles();
        SpawnAtEdge();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnAtEdge()
    {
        Instantiate(wallPrefab, GetRandomEdgeCellPosition(), Quaternion.identity);
    }
    public void SpawnAtEdges()
    {
        List<Vector3> pos = GetEdgeCellsWorldPositions();

        foreach(Vector3 p in pos)
        {
            Instantiate(wallPrefab, p, Quaternion.identity);
        }
    }

    #region Menu Functions
    /// <summary>
    /// Starts the current level
    /// </summary>
    public void StartLevel()
    {
        // Spawn the first customer
        ResumeLevel();
    }

    /// <summary>
    /// Restarts the scene
    /// </summary>
    public void RestartLevel()
    {
        ResumeLevel();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /// <summary>
    /// Restarts the scene
    /// </summary>
    public void GoToMain()
    {
        SceneManager.LoadScene(0);
    }

    /// <summary>
    /// Pause the game
    /// </summary>
    public void PauseLevel()
    {
        Time.timeScale = 0;
        isPaused = true;
    }

    /// <summary>
    /// Resume the game
    /// </summary>
    public void ResumeLevel()
    {
        Time.timeScale = 1;
        isPaused = false;
    }

    /// <summary>
    /// Ends the level and shows score
    /// </summary>
    public void EndLevel()
    {
        // Game is over
        PauseLevel();
        UIController.instance.ShowEndScreen(score);
    }
    #endregion

    /// <summary>
    /// Add score to the game score
    /// </summary>
    /// <param name="amount">The score amount to be added</param>
    public void AddScore(int amount)
    {
        score += amount;

        UIController.instance.SetScore(score);
    }
}
