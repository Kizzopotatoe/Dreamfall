using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float mouseSensitivity = 2f;

    private float cameraVerticalRotation = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        float inputX = GameInput.Instance.GetMouseDelta().x;
        float inputY = GameInput.Instance.GetMouseDelta().y;

        // Up / Down Movement
        cameraVerticalRotation -= inputY * mouseSensitivity * Time.deltaTime;
        cameraVerticalRotation = Mathf.Clamp(cameraVerticalRotation, -90f, 90f);
        transform.localEulerAngles = new Vector3(cameraVerticalRotation, transform.localEulerAngles.y, 0f);

        // Left / Right Movement
        player.Rotate(Vector3.up * inputX * mouseSensitivity * Time.deltaTime);
    }
}
