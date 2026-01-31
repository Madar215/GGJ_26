using UnityEngine;

[ExecuteAlways]
public class BulbRingLayout : MonoBehaviour
{
    [Header("Ring")]
    [SerializeField] private Transform[] bulbs = new Transform[10];
    [SerializeField] private float radius = 1.0f;          // world units
    [SerializeField] private float startAngleDeg = 90f;    // 90 = top
    [SerializeField] private bool clockwise = true;

    [Header("Optional")]
    [SerializeField] private bool rotateBulbsOutward = true;

    private void OnValidate() => Apply();
    private void Update()
    {
#if UNITY_EDITOR
        if (!Application.isPlaying) Apply();
#endif
    }

    public void Apply()
    {
        if (bulbs == null || bulbs.Length == 0) return;

        int count = bulbs.Length;
        float dir = clockwise ? -1f : 1f;

        for (int i = 0; i < count; i++)
        {
            Transform b = bulbs[i];
            if (b == null) continue;

            float angle = (startAngleDeg + dir * (360f * i / count)) * Mathf.Deg2Rad;
            Vector3 localPos = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0f) * radius;

            b.localPosition = localPos;

            if (rotateBulbsOutward)
            {
                float rotZ = (startAngleDeg + dir * (360f * i / count)) - 90f;
                b.localRotation = Quaternion.Euler(0f, 0f, rotZ);
            }
            else
            {
                b.localRotation = Quaternion.identity;
            }
        }
    }
}
