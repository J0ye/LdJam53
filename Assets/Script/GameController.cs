using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class GameController : GridOperator
{
    public static GameController instance;
    public Player player;
    public Car car;
    public float spawnAnimationDuration = 0.5f;
    public GameObject destinationPrefab;
    public GameObject parcelPrefab;
    public List<GameObject> obstacles = new List<GameObject>();
    [Header("Game Options")]
    public int amountOfStartingParcels = 3;
    public int amountOfObstacles = 2;
    public float obstacleWaveCooldown = 180f;

    public GigaGrid gigaGrid;

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
        SpawnNewJobs(amountOfStartingParcels);
        SpawnObstacles();
    }

    public void SpawnNewJobs(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            SpawnNotOnGrid(destinationPrefab, GetRandomEdgeCellPosition());
            SpawnNotOnGrid(parcelPrefab, GetRandomInnerCellPosition());
        }
    }

    public void SpawnObstacles()
    {
        for(int i = 0; i < amountOfObstacles; i++)
        {
            int rand = Random.Range(0, obstacles.Count);
            Spawn(obstacles[rand], GetRandomInnerCellPosition());
        }

        Invoke("SpawnObstacles", obstacleWaveCooldown);
    }

    private void Spawn(GameObject targetObject, Vector3 targetPosition)
    {
        GameObject newObject = gigaGrid.PlaceTile(targetPosition - Vector3.up, targetObject);
        newObject.transform.DOMove(targetPosition, spawnAnimationDuration);

    }

    private void SpawnNotOnGrid(GameObject targetObject, Vector3 targetPosition)
    {
        GameObject newObject = Instantiate(targetObject, targetPosition - Vector3.up, Quaternion.identity);
        newObject.transform.DOMove(targetPosition, spawnAnimationDuration);
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
        //PauseLevel();
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
        SpawnNewJobs(amount);
    }
}
