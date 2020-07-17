using UnityEngine;
using UnityEngine.SceneManagement;
/* Current score doğru olan her durumda artıyor
 * Max score doğru da olsa yanlış da olsa artıyor
 * curren'ın max'a oranı da skoru veriyor
*/


public class levelManager : MonoBehaviour
{
    // Level Manager Singleton
    private static levelManager instance = null;
    public static levelManager singleton
    {
        get
        {
            return instance;
        }
    }

    //Constructor
    private levelManager()
    {
        instance = this;
    }

    [Range(0,1)]
    public float threshold; //İlk ve ikinci renk arasındaki sınır noktası
    public int firstColorIndex;
    public int secondColorIndex;

    private int currentScore = 0;
    private int maxScore = 0;

    public void addScore(int colorIndex, float currentDistance)
    {
        //Eğer pozisyon sınırdan küçükse dondurma renginin ilk renk olması gerek
        if (gameManager.singleton.progress < threshold && colorIndex == firstColorIndex) 
            currentScore++;
        //Eğer pozisyon sınırdan büyükse dondurma renginin ikinci renk olması gerek
        if (gameManager.singleton.progress > threshold && colorIndex == secondColorIndex)
            currentScore++;
        //maxScore her iki durumda da artıyor
        maxScore++;
    }

    //Current'ın maxa oranının yüzdelik hesabı
    public int getScore()
    {
        return Mathf.CeilToInt(currentScore * 100 / maxScore);
    }

    public void nextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
