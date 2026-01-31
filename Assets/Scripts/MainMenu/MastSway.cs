using UnityEngine;

public class MastSway : MonoBehaviour
{
    [Header("Sway Settings")]
    [SerializeField] private float swayAngle = 5f;   
    [SerializeField] private float swaySpeed = 1f;   

    private Quaternion startRotation;

    void Start()
    {
        startRotation = transform.localRotation;
    }

    void Update()
    {
        float angle = Mathf.Sin(Time.time * swaySpeed) * swayAngle;
        transform.localRotation = startRotation * Quaternion.Euler(0f, 0f, angle);
    }
}
