using UnityEngine;

public class playerShooter : MonoBehaviour
    
{
    public float offset;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // หาตำแหน่งของเมาส์บนหน้าจอ
        Vector2 mouseScreenPosition = Input.mousePosition;

        // หาจุดศูนย์กลางของหน้าจอ
        Vector2 screenCenter = new Vector2(Screen.width / 2f, Screen.height / 2f);

        // คำนวณเวกเตอร์จากจุดศูนย์กลางไปยังเมาส์
        Vector2 direction = mouseScreenPosition - screenCenter;

        // คำนวณมุม (ในหน่วยองศา)
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        angle = angle*(-1)+offset;

        // หมุนตัวละครรอบแกน y
        transform.rotation = Quaternion.Euler(0f, angle, 0f);

    }
    }
