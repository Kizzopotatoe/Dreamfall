using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timer;
    public Score score;

    void Start()
    {
        score = FindObjectOfType<Score>();
    }

    // Update is called once per frame
    void Update()
    {
        if(score.morning == true)
        {
            timer.text = "08:00";
            return;
        }

        switch(score.deaths)
        {
            case 0:
                timer.text = "ERROR";
                break;
            case 1:
                timer.text = "00:00";
                break;
            case 2:
                timer.text = "02:00";
                break;
            case 3:
                timer.text = "04:00";
                break;
            case 4:
                timer.text = "06:00";
                break;
            case 5:
                timer.text = "08:00";
                break;
        }
    }
}
