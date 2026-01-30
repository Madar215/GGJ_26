using UnityEngine;

public class UIButtonParticleVFX : MonoBehaviour
{
    [Header("Assign PSFX Prefabs")]
    [SerializeField] private GameObject vfxPrefab1;
    [SerializeField] private GameObject vfxPrefab2;

    [Header("Spawn Point (optional)")]
    [SerializeField] private Transform spawnPoint;

    [Header("Parent (usually Canvas)")]
    [SerializeField] private Transform uiParent;

    [SerializeField] private float destroyAfter = 3f;

    public void PlayVFX()
    {
        Transform parent = uiParent != null ? uiParent : transform.root;
        Vector3 pos = spawnPoint != null ? spawnPoint.position : transform.position;

        if (vfxPrefab1 != null)
        {
            var vfx1 = Instantiate(vfxPrefab1, parent);
            vfx1.transform.position = pos;
            Destroy(vfx1, destroyAfter);
        }

        if (vfxPrefab2 != null)
        {
            var vfx2 = Instantiate(vfxPrefab2, parent);
            vfx2.transform.position = pos;
            Destroy(vfx2, destroyAfter);
        }
    }
}
