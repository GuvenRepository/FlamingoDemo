using System.Collections;
using UnityEngine;

public class machineManager : MonoBehaviour
{
    //Machine Manager singleton
    private static machineManager instance = null;
    public static machineManager singleton
    {
        get
        {
            return instance;
        }
    }

    //İki adet boş obje var
    //anchor parent olan ve merkezde duran
    //destination anchordan belirli bir uzaklıkta olan ve anchorun çocuğu
    //anchor döndükçe destination daire çiziyor
    public Transform anchor;
    private Transform destination;

    //Makinenin üreteceği dondurma prefabi
    public GameObject cream;

    
    private int colorIndex = 0; //üretilecek dondurma rengi
    private bool go; //makine çalışsın mı?

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
                //dondurmanın tepesine gelmediği sürece
                if (destination.localPosition.z > 0)
                {
                    //Yeni dondurma
                    creamManager creamTemp = Instantiate(cream, transform.position, Quaternion.identity).GetComponent<creamManager>();
                    creamTemp.UpdateColor(colorIndex); //Dondurma rengi

                    //pozisyon ve rengi levelManager'a bildir
                    levelManager.singleton.addScore(colorIndex, Mathf.Abs(destination.localPosition.z));

                    
                    anchor.Rotate(0, 6, 0); //Yana hareket
                    destination.localPosition -= new Vector3(0, 0, 0.003f); //Yukarı hareket
                    anchor.Translate(0, 0.004f, 0); //İçe hareket(tepeye doğru küçülme)

                    //makine dondurmanın üzerinde hareket etmeli ama yukarı çıkmamalı
                    transform.position = new Vector3(destination.position.x, transform.position.y, destination.position.z);
                    yield return new WaitForSeconds(0.01f);
                }
                else //dondurma tepesi
                {
                    gameManager.singleton.levelFinished();
                    break;
                }
            }
            yield return null;
        }
    }

    //Butona basılınca çalış
    public void creamGenerateStart(int index)
    {
        colorIndex = index;
        go = true;
    }

    //Butondan el çekilince dur
    public void creamGenerateStop()
    {
        go = false;
    }
}
