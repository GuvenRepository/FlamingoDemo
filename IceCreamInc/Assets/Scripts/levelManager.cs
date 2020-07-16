using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelManager : MonoBehaviour
{
    // Game Instance Singleton
    private static levelManager instance = null;
    public static levelManager singleton
    {
        get
        {
            return instance;
        }
    }

    private levelManager()
    {
        instance = this;
    }

    [Range(0,1)]
    public float threshold;
    public int firstColorIndex;
    public int secondColorIndex;

    private int currentScore = 0;
    private int maxScore = 0;

    public void addScore(int colorIndex, float currentDistance)
    {
        if (gameManager.singleton.progress < threshold && colorIndex == firstColorIndex)
            currentScore++;
        if (gameManager.singleton.progress > threshold && colorIndex == secondColorIndex)
            currentScore++;
        maxScore++;
    }

    public int getScore()
    {
        return Mathf.CeilToInt(currentScore * 100 / maxScore);
    }

    public void nextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
