using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    // Game Manager Singleton
    private static gameManager instance = null;
    public static gameManager singleton
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

    //Levelin sürecini gösteren bar
    public Slider progressBar;
    public float progress;

    //dairenin baştaki çapı
    private float firstRadius;

    //Oyun sonu materyalleri
    public GameObject finishPanel;
    public Text successRateText;

    private void Start()
    {
        instance = this; //singleton
        destination = anchor.GetChild(0);
        firstRadius = destination.localPosition.z; //Anchor 0'da olduğu için uzaklık destination'un pozisyonu
    }

    //Destination'ın anchora yakınlığı oyunu tamamlanma yüzdesini gösteriyor
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
