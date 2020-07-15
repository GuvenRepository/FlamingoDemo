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

    private void Start()
    {
        instance = this;
        destination = anchor.GetChild(0);
    }

    public void OnWhitePressDown()
    {
        machineManager.singleton.creamGenerateStart(0);
    }

    public void OnWhitePressUp()
    {
        machineManager.singleton.creamGenerateStop();
    }

}
