using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class machineManager : MonoBehaviour
{
    private static machineManager instance = null;
    public static machineManager singleton
    {
        get
        {
            return instance;
        }
    }


    public Transform anchor;
    private Transform destination;
    public GameObject cream;


    private int colorIndex = 0;
    private bool go;

    private void Start()
    {
        instance = this;
        StartCoroutine(creamGenerator());
        destination = anchor.GetChild(0);
    }

    

    private IEnumerator creamGenerator()
    {
        while (true)
        {
            if (go)
            {
                if (destination.localPosition.z > 0)
                {
                    creamManager creamTemp = Instantiate(cream, transform.position, Quaternion.identity).GetComponent<creamManager>();
                    creamTemp.UpdateColor(colorIndex);

                    levelManager.singleton.addScore(colorIndex, Mathf.Abs(destination.localPosition.z));

                    anchor.Rotate(0, 6, 0);
                    destination.localPosition -= new Vector3(0, 0, 0.003f);
                    anchor.Translate(0, 0.004f, 0);

                    transform.position = new Vector3(destination.position.x, transform.position.y, destination.position.z);
                    yield return new WaitForSeconds(0.01f);
                }
                else
                {
                    gameManager.singleton.levelFinished();
                    break;
                }
            }
            yield return null;
        }
    }

    public void creamGenerateStart(int index)
    {
        colorIndex = index;
        go = true;
    }

    public void creamGenerateStop()
    {
        go = false;
    }
}
