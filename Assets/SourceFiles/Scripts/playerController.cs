using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float sensX;
    public float sensY;

    public Transform orientation;

    float Xrotation;
    float Yrotation;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float MouseX = Input.GetAxisRaw("Mouse X")*Time.deltaTime*sensX;
        float MouseY = Input.GetAxisRaw("Mouse Y")*Time.deltaTime*sensY;

        Yrotation -= MouseY;
        Xrotation += MouseX;

        Xrotation = Mathf.Clamp(Xrotation,-90f,90f);

        transform.rotation = Quaternion.Euler(Xrotation,Yrotation,0);
        orientation.rotation = quaternion.Euler(0,Yrotation,0);
    }
}
