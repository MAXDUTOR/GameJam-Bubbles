using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public BoxCollider attackCollider; // ลาก Box Collider ที่ใช้กำหนดระยะโจมตีมาใส่ในช่องนี้
    public float attackDelay = 0.5f; // หน่วงเวลาหลังจากคลิกซ้ายก่อนที่จะทำการโจมตี (หน่วยเป็นวินาที)
    public float attackDamage = 10f; // ความเสียหายพื้นฐาน
    public float damageMultiplierPerSecond = 2f; // ตัวคูณความเสียหายต่อวินาที

    private bool isAttacking = false;
    private float attackStartTime;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isAttacking) // ตรวจสอบว่าคลิกซ้ายและไม่ได้อยู่ในสถานะโจมตี
        {
            StartAttack();
        }

        if (isAttacking)
        {
            // คำนวณเวลาที่ผ่านไปตั้งแต่เริ่มโจมตี
            float elapsedTime = Time.time - attackStartTime;

            // ตรวจสอบว่าถึงเวลาโจมตีหรือยัง
            if (elapsedTime >= attackDelay)
            {
                PerformAttack();
                isAttacking = false;
            }
        }
    }

    void StartAttack()
    {
        isAttacking = true;
        attackStartTime = Time.time;
    }

    void PerformAttack()
    {
        // คำนวณความเสียหาย
        float elapsedTime = Time.time - attackStartTime;
        float damage = attackDamage + (damageMultiplierPerSecond * elapsedTime);

        // ตรวจสอบการชนกับศัตรูภายในระยะ (ใช้ Box Collider)
        Collider[] hitColliders = Physics.OverlapBox(attackCollider.bounds.center, attackCollider.bounds.extents, attackCollider.transform.rotation, LayerMask.GetMask("Enemy"));
        foreach (Collider hitCollider in hitColliders)
        {
            // ทำดาเมจใส่ศัตรู 
            Enemy enemyHealth = hitCollider.GetComponent<Enemy>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
            }
        }
    }
    // ใน Script PlayerAttack หรือ Script Enemy

}