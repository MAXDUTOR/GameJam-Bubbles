using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float maxHealth = 100f; // HP สูงสุด
    public float currentHealth; // HP ปัจจุบัน
    public float attackPower = 10f; // พลังโจมตี

    public GameObject prefabToInstantiate; // ลาก Prefab ที่ต้องการสร้างมาใส่ในช่องนี้


    void SpawnPrefabAtEnemyPosition()
    {
        // หาตำแหน่งของศัตรู
        Vector3 enemyPosition = transform.position;

        // กำหนดค่า y ให้เป็น 0
        enemyPosition.y = 0.1f;

        float randomZRotation = Random.Range(0f, 360f);

        // สร้าง Instance ของ Prefab พร้อมกำหนด Rotation
        Instantiate(prefabToInstantiate, enemyPosition, Quaternion.Euler(90f, 0f, 0f));
    }

    void SpawnPrefabAtEnemyPositionRandom()
    {
        // หาตำแหน่งของศัตรู
        Vector3 enemyPosition = transform.position;

        // กำหนดค่า y ให้เป็น 0
        enemyPosition.y = 0.1f;

        // สุ่มค่าการหมุนแกน z
        float randomZRotation = Random.Range(0f, 360f);

        // สุ่มขนาด
        float randomScale = Random.Range(0.05f, 0.25f);

        // สร้าง Instance ของ Prefab พร้อมกำหนด Rotation
        GameObject instantiatedPrefab = Instantiate(prefabToInstantiate, enemyPosition, Quaternion.Euler(90f, 0f, randomZRotation));

        // กำหนดขนาด
        instantiatedPrefab.transform.localScale = Vector3.one * randomScale;
    }

    void Start()
    {
        currentHealth = maxHealth; // กำหนด HP เริ่มต้น
        // ลบ Die(); ออก 
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage; // ลด HP เมื่อโดนโจมตี
        SpawnPrefabAtEnemyPositionRandom();

        if (currentHealth <= 0)
        {
            Die(); // เรียกใช้ฟังก์ชัน Die() เมื่อ HP หมด
        }
    }

    void Update()
    {

    }

    void Die()
    {
        SpawnPrefabAtEnemyPosition();
        // ถ้าไม่มี Script ExplosionEffect ให้ลบหรือ comment บรรทัดนี้
        GetComponent<ExplosionEffect>().Explode();

        // ทำลาย GameObject ของศัตรู
        Destroy(gameObject);
    }
}