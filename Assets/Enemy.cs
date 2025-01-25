using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float maxHealth = 100f; // HP สูงสุด
    public float currentHealth; // HP ปัจจุบัน
    public float attackPower = 10f; // พลังโจมตี

    void Start()
    {
        currentHealth = maxHealth; // กำหนด HP เริ่มต้น
        Die();
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage; // ลด HP เมื่อโดนโจมตี

        if (currentHealth <= 0)
        {
            Die(); // เรียกใช้ฟังก์ชัน Die() เมื่อ HP หมด
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Die()
    {
        // สร้าง Effect ระเบิด
        GetComponent<ExplosionEffect>().Explode();
        // ทำลาย GameObject ของศัตรู
        Destroy(gameObject);
    }
}
