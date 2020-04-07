using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour
{
    float currentTime = 0f;
    float startTime = 90f;

    public Text CountDownText;
    void Start()
    {
        currentTime = startTime;
    }
    void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= 1 * Time.deltaTime;
            print(currentTime);
            CountDownText.text = currentTime.ToString("0");
        }
        if (currentTime < 0)
        {
            SceneManager.LoadScene("Game Over p1");
        }
    }
}