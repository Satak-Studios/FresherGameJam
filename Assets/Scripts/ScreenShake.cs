using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    public static ScreenShake instance;

    public float shakeDuration = 0.3f;
    public float shakeMagnitude = 0.7f;

    private Transform cameraTransform;
    private Vector3 initialPosition;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        //cameraTransform = Camera.main.transform;
        cameraTransform = gameObject.transform;
        initialPosition = cameraTransform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (shakeDuration > 0)
        {
            cameraTransform.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude;
            shakeDuration -= Time.deltaTime;
        }
        else
        {
            shakeDuration = 0;
            cameraTransform.localPosition = initialPosition;
        }
    }

    public void StartShake(float _duration, float magnitude)
    {
        shakeDuration = _duration;
        shakeMagnitude = magnitude;
    }
}
