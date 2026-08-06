using System;
using Unity.Mathematics;
using UnityEngine;

public class mouseMove : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    float MouseX,MouseY;
    public float MouseSensitivity = 300;
    public Transform player;
    float Xrotation;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        player = FindAnyObjectByType<PlayerHealth>().gameObject.transform;
        MouseX = Input.GetAxis("Mouse X") * MouseSensitivity * Time.deltaTime;
        MouseY = Input.GetAxis("Mouse Y")* MouseSensitivity * Time.deltaTime;

        Xrotation -= MouseY;
        Xrotation = Math.Clamp(Xrotation,-90f,90f);

        transform.localRotation = Quaternion.Euler(Xrotation,0,0);

        player.Rotate(Vector3.up*MouseX);
    }
}
