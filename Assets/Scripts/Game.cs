using System.Collections;
using UnityEngine;

public class Game : MonoBehaviour
{
    public Bunny Bunny;
    public Readout readout;
    public CameraMove Camera;
    public static Game Instance;
    public CanvasGroup GetReady;
    public CanvasGroup Pause;
    public GameObject Keyboard;
    public GameObject Music;
    private static bool gameIsPaused = false;
    private int lives;
    private int score;
    private int level;
    public void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this.gameObject);
        else
            Instance = this;
    }
    void Start()
    {
        lives = GameplayParameters.BunnyLives;
        score = 0;
        level = 1;
        readout.Reset(lives);
        Sounds.Instance.PlayStart();
        StartCoroutine(CountdownTilStart());
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            PauseGame();
        }
    }
    private void PauseGame()
    {
        gameIsPaused = !gameIsPaused;
        if (gameIsPaused)
        {
            Time.timeScale = 0f;
            CanvasGroupTogglers.Show(Pause);
            DisableKeyboard();
        }
        else
        {
            Time.timeScale = 1;
            CanvasGroupTogglers.Hide(Pause);
            EnableKeyboard();
        }
    }
    public void LoseBunny()
    {
        UpdateLives();
        CheckForGameOver();
    }
    private void CheckForGameOver()
    {
        if (lives == 0)
            LoseGame();
        else
            Reset();
    }
    private void LoseGame()
    {
        readout.ShowLoseResults();
        Destroy(Bunny.gameObject);
        Sounds.Instance.PlayLose();
        Music.SetActive(false);
    }
    private void Reset()
    {
        Bunny.Reset();
        Camera.isMoving = false;
        Camera.ResetCameraPostion();
        StartCoroutine(CountdownTilStart());
    }
    IEnumerator CountdownTilStart()
    {
        CanvasGroupTogglers.Show(GetReady);
        DisableKeyboard();
        yield return new WaitForSeconds(GameplayParameters.GettingReady);
        CanvasGroupTogglers.Hide(GetReady);
        EnableKeyboard();
        Camera.StartMoving();
    }
    private void DisableKeyboard()
    {
        Keyboard.SetActive(false);
    }
    private void EnableKeyboard()
    {
        Keyboard.SetActive(true);
    }
    public void GoToNextLevel()
    {
        Reset();
        IncreaseGameDifficulty();
        UpdateScore();
        UpdateLevel();
        //increase rate of spawning
    }
    private void IncreaseGameDifficulty()
    {
        IncreaseSawSpeed();
        IncreaseFlameSpeed();
        IncreaseCameraSpeed();
    }
    private void IncreaseSawSpeed()
    {
        GameplayParameters.waitToEasyWalkSeconds -= GameplayParameters.SawSpeedSubtracter;
        GameplayParameters.waitToHardWalkSeconds -= GameplayParameters.SawSpeedSubtracter;
    }
    private void IncreaseFlameSpeed()
    {
        GameplayParameters.FlameSecondsOffScreen -= GameplayParameters.FlameSpeedSubtracter;
        
    }
    private void IncreaseCameraSpeed()
    {
        GameplayParameters.CameraMoveSpeed += (GameplayParameters.GameSpeedMultiplier * level);
    }
    private void UpdateLives()
    {
        lives -= 1;
        readout.ShowLives(lives);
    }
    public void UpdateScore()
    {
        score = level * 1000;
        readout.ShowScore(score);
    }
    public void UpdateLevel()
    {
        level += 1;
        readout.ShowLevel(level);
    }
}
