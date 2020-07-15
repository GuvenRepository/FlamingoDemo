using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creamManager : MonoBehaviour
{
    private Vector3 destinationPosition;
    private Vector3 destinationRotation;
    private Vector3 difference;
    // Start is called before the first frame update
    void Start()
    {
        destinationPosition = gameManager.singleton.anchor.GetChild(0).position;
        destinationRotation = gameManager.singleton.anchor.eulerAngles;
        difference = destinationPosition - transform.position;
        StartCoroutine(fallAnimation());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator fallAnimation()
    {
        while (true)
        {
            if (Vector3.Distance(destinationPosition, transform.position) > 0.01f)
            {
                transform.Translate(difference / 100);
                yield return new WaitForSeconds(0.001f);
            }
            else
            {
                transform.localEulerAngles = destinationRotation + new Vector3(0,0,90);
                break;
            }
        }
    }

}
