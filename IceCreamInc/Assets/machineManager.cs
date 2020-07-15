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
            if (go && destination.localPosition.z > 0)
            {
                if (destination.localPosition.z > 0)
                {
                    GameObject creamTemp = Instantiate(cream, transform.position, Quaternion.identity);
                    anchor.Rotate(0, 6, 0);
                    destination.localPosition -= new Vector3(0, 0, 0.003f);
                    anchor.Translate(0, 0.004f, 0);

                    transform.position = new Vector3(destination.position.x, transform.position.y, destination.position.z);
                    yield return new WaitForSeconds(0.01f);
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
