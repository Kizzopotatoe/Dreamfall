using UnityEngine;

public class SpaceWhale : MonoBehaviour
{
    public float speed;
    public float rotateSpeed;
    public Transform[] target;
    private int targetNumber = 0;

    // Update is called once per frame
    void Update()
    {
        var step = speed * Time.deltaTime; 
        float rotateStep = speed * Time.deltaTime;
        Vector3 targetDirection = target[targetNumber].position - transform.position;

        transform.position = Vector3.MoveTowards(transform.position, target[targetNumber].position, step);

        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, rotateStep, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDirection);

        if (Vector3.Distance(transform.position, target[targetNumber].position) < 0.001f)
        {
            if(targetNumber == 8) Destroy(this.gameObject);
            targetNumber++;
        }
    }
}
