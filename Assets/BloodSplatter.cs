using UnityEngine;
using UnityEngine.Rendering.Universal;

public class BloodSplatter : MonoBehaviour
{
    public GameObject decalProjectorPrefab; // Prefab ของ Decal Projector
    public float fadeSpeed = 0.1f; // ความเร็วในการ Fade (ปรับค่าตามต้องการ)

    public void CreateBloodDecal(Vector3 position, Vector3 normal)
    {
        // สร้าง Decal Projector
        GameObject decalProjectorObject = Instantiate(decalProjectorPrefab, position, Quaternion.LookRotation(normal));
        DecalProjector decalProjector = decalProjectorObject.GetComponent<DecalProjector>();

        // กำหนดตำแหน่ง y ให้เป็น 0.5
        Vector3 decalPosition = decalProjector.transform.position;
        decalPosition.y = 0.5f;
        decalProjector.transform.position = decalPosition;

        // เริ่ม Fade
        StartCoroutine(FadeDecal(decalProjector));
    }

    private System.Collections.IEnumerator FadeDecal(DecalProjector decalProjector)
    {
        while (decalProjector.fadeFactor > 0.1f) // Fade จนเหลือ fadeFactor 0.1
        {
            decalProjector.fadeFactor -= fadeSpeed * Time.deltaTime;
            yield return null;
        }
    }
}