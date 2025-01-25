using UnityEngine;

public class ExplosionEffect : MonoBehaviour
{
    public GameObject[] meshParts; // Array ของ Prefab แต่ละส่วนของ Mesh
    public float explosionForce = 10f; // แรงระเบิด
    public float explosionRadius = 5f; // รัศมีการระเบิด

    public void Explode()
    {
        foreach (GameObject part in meshParts)
        {
            // สร้าง Instance ของ Mesh Part
            GameObject partInstance = Instantiate(part, transform.position, transform.rotation);

            // เพิ่มแรงระเบิด
            Rigidbody rb = partInstance.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
            }


            // ทำลาย Mesh Part หลังจากเวลาผ่านไป (Optional)
            Destroy(partInstance, 5f);
        }
    }
}