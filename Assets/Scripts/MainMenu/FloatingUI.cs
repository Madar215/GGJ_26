using UnityEngine;

public class FloatingUI : MonoBehaviour
{
    [SerializeField] private float moveAmount = 10f;   
    [SerializeField] private float moveSpeed = 1f;     

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.localPosition;
    }

    void Update()
    {
        float newY = startPos.y + Mathf.Sin(Time.time * moveSpeed) * moveAmount;
        transform.localPosition = new Vector3(startPos.x, newY, startPos.z);
    }
}
