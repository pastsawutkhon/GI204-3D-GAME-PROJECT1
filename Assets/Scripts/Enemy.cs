using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int scoreValue = 10;
    [SerializeField] private GameObject replacePrefab;
    [SerializeField] private GameObject smokeEffect;
    [SerializeField] private float transformDelay = 0.3f;

    private bool isHit = false;

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Hit Something"); // เช็คว่าชนไหม

        if (isHit) return;

        if (!collision.gameObject.CompareTag("Bullet")) return;

        isHit = true;

        Debug.Log("Hit Bullet"); // ต้องขึ้นอันนี้

        // เพิ่มคะแนน
        if (ScoreManager.instance != null)
        {
            ScoreManager.instance.AddScore(scoreValue);
        }

        // เอฟเฟกต์
        if (smokeEffect != null)
        {
            Instantiate(smokeEffect, transform.position, Quaternion.identity);
        }

        // ลบกระสุน
        Destroy(collision.gameObject);

        // แปลงร่าง
        StartCoroutine(TransformRoutine());
    }

    private IEnumerator TransformRoutine()
    {
        yield return new WaitForSeconds(transformDelay);

        if (replacePrefab != null)
        {
            Instantiate(replacePrefab, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }
}