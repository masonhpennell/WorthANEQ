using UnityEngine;
using UnityEngine.UI;

public class Readout : MonoBehaviour
{
    public Text Score;
    public Text Lives;
    public Text Level;
    public CanvasGroup GameOver;

    public void Reset(int startingNumberOfLives)
    {
        ShowScore(0);
        ShowLevel(1);
        ShowLives(startingNumberOfLives);
    }

    public void ShowScore(int score)
    {
        if (score < 0)
            score = 0;
        if (score == 1000)
            MoveLevel();
        Score.text = "Score:" + score;
    }

    public void ShowLevel(int level)
    {
        if (level < 0)
            level = 0;
        Level.text = "Level " + level;
    }

    public void ShowLives(int lives)
    {
        if (lives < 0)
            lives = 0;
        Lives.text = "Lives:" + lives;
    }
    
    public void ShowLoseResults()
    {
        CanvasGroupTogglers.Show(GameOver);
    }

    private void MoveLevel()
    {
        RectTransform LevelPosition = Level.gameObject.GetComponent<RectTransform>();
        LevelPosition.position = new Vector3(LevelPosition.position.x+38,
            LevelPosition.position.y, LevelPosition.position.z);      
    }
}
