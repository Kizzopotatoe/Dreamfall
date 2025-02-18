using UnityEngine;

public class FPS : MonoBehaviour
{
    //Value that the framerate will target
    public int frameTarget;     

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = frameTarget;
    }
}
