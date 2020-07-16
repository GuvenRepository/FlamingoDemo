using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    // Game Instance Singleton
    private static gameManager instance = null;
    public static gameManager singleton
    {
        get
        {
            return instance;
        }
    }
    

    public Transform anchor;
    private Transform destination;
    public Slider progressBar;
    public float progress;
    private float firstRadius;

    public GameObject finishPanel;
    public Text successRateText;

    private void Start()
    {
        instance = this;
        destination = anchor.GetChild(0);
        firstRadius = destination.localPosition.z;
    }

    private void Update()
    {
        progress = (firstRadius - Mathf.Abs(destination.localPosition.z)) / firstRadius;
        progressBar.value = progress;
    }

    public void OnButtonPressDown(int colorIndex)
    {
        machineManager.singleton.creamGenerateStart(colorIndex);
    }

    public void OnButtonPressUp()
    {
        machineManager.singleton.creamGenerateStop();
    }

    public void levelFinished()
    {
        finishPanel.SetActive(true);
        int score = levelManager.singleton.getScore();
        successRateText.text = score.ToString() + "%";
    }

    
}
