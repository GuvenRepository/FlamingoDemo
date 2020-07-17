using System.Collections;
using UnityEngine;

public class creamManager : MonoBehaviour
{
    //Dondurma index-renk look-up table
    private Color[] colors = { Color.yellow, Color.white, Color.red };

    void Start()
    {
        //Başlar başlamaz serbest düşüş
        StartCoroutine(fallAnimation());
    }

    // basit düşme animasyonu
    private IEnumerator fallAnimation()
    {
        //düşülecek yer(destination position)
        Vector3 destinationPosition = gameManager.singleton.anchor.GetChild(0).position;
        //düşüleceği zaman olması gereken açı
        Vector3 destinationRotation = gameManager.singleton.anchor.eulerAngles;
        //animasyon başlangıç ve bitiş noktası arasındaki fark
        Vector3 difference = destinationPosition - transform.position;


        while (true)
        {
            if (Vector3.Distance(destinationPosition, transform.position) > 0.01f) // hedefe varana dek devam
            {
                transform.Translate(difference / 100); //100 adımda düşme hareketi
                yield return new WaitForSeconds(0.001f);
            }
            else
            {
                transform.localEulerAngles = destinationRotation + new Vector3(0,0,90); // düştükten sonra 90 derce dön (yan yat)
                break;
            }
        }
    }


    public void UpdateColor(int colorIndex)
    {
        gameObject.GetComponent<Renderer>().material.color = colors[colorIndex];
    }

}
