using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject replacePrefab;   // น่องไก่
    public GameObject smokeEffect;     // ควัน
    public float destroyDelay = 0.5f;
    public int scoreValue = 10;        // จำนวนคะแนนที่จะให้เมื่อศัตรูถูกยิง

    Rigidbody rb;
    bool isHit = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        // ถ้าถูกยิงไปแล้ว ไม่ต้องทำซ้ำ
        if (isHit) return;

        // เช็คว่าชนกับ Object ที่มี Tag ว่า "Bullet" หรือไม่
        if (collision.gameObject.CompareTag("Bullet"))
        {
            isHit = true;

            // --- ส่วนที่เพิ่มเข้ามา: สั่งให้ ScoreManager บวกคะแนน ---
            if (ScoreManager.instance != null)
            {
                ScoreManager.instance.AddScore(scoreValue);
            }
            // ------------------------------------------------

            // เปิดระบบฟิสิกส์ให้ศัตรูกระเด็น
            rb.isKinematic = false;
            rb.useGravity = true;

            // รับแรงกระแทกจากความเร็วของกระสุน
            Rigidbody bulletRb = collision.gameObject.GetComponent<Rigidbody>();
            if (bulletRb != null)
            {
                // ใช้ค่า linearVelocity ตามเวอร์ชัน Unity ใหม่ของคุณ
                rb.AddForce(bulletRb.linearVelocity * 0.5f, ForceMode.Impulse);
            }

            // สร้างเอฟเฟคควัน
            if (smokeEffect != null)
            {
                Instantiate(smokeEffect, transform.position, Quaternion.identity);
            }

            // รอเวลาครู่หนึ่งก่อนเปลี่ยนเป็นน่องไก่
            Invoke("TransformToMeat", destroyDelay);
        }
    }

    void TransformToMeat()
    {
        if (replacePrefab != null)
        {
            Instantiate(replacePrefab, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}