using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Prefab ของศัตรู
    public int maxEnemies = 6; // จำนวนศัตรูสูงสุด
    public float spawnRadius = 40f; // ระยะห่างจากผู้เล่นที่จะ spawn ศัตรู
    public float spawnInterval = 5f; // ระยะเวลาในการ spawn ศัตรูแต่ละตัว

    public Transform playerTransform;
    private int currentEnemies = 0;
    private float nextSpawnTime;

    void Start()
    {
        // หา Transform ของ Player
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        nextSpawnTime = Time.time;
    }

    void Update()
    {
        // ตรวจสอบว่าถึงเวลา spawn ศัตรูหรือยัง
        if (Time.time > nextSpawnTime && currentEnemies < maxEnemies)
        {
            // สุ่มตำแหน่ง spawn รอบๆ ผู้เล่น
            Vector3 randomPosition = Random.insideUnitSphere * spawnRadius;
            randomPosition += playerTransform.position;

            // กำหนดค่า y ให้เท่ากับตำแหน่ง y ของ Player
            randomPosition.y = playerTransform.position.y;

            // สร้างศัตรู
            Instantiate(enemyPrefab, randomPosition, Quaternion.identity);
            currentEnemies++;

            // กำหนดเวลา spawn ครั้งถัดไป
            nextSpawnTime = Time.time + spawnInterval;
        }

        // ตรวจสอบจำนวนศัตรูในฉาก
        if (currentEnemies >= maxEnemies)
        {
            // หากศัตรูตาย ให้ลดจำนวน currentEnemies ลง
            // (คุณต้องเพิ่มโค้ดนี้ใน Script ของศัตรูด้วย)
        }
    }
}