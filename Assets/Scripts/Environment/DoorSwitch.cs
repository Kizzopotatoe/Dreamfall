using UnityEngine;

public class DoorSwitch : MonoBehaviour
{
    public Score score;
    public GameObject closedDoor;
    public GameObject openDoor;

    // Start is called before the first frame update
    void Start()
    {
        score = FindObjectOfType<Score>();

        if(score.morning == true)
        {
            closedDoor.SetActive(false);
            openDoor.SetActive(true);
        }
        else
        {
            closedDoor.SetActive(true);
            openDoor.SetActive(false);
        }
    }


}
