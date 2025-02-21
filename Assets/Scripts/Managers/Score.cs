using UnityEngine;

public class Score : MonoBehaviour
{
    public int deaths = 0;
    public bool morning = false;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }  

    public void Death()
    {
        deaths++;

        if(deaths >= 5)
        {
            morning = true;
        }
    }
}
