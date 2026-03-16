using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooter : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;

    public float shootForce = 10f;
    public float spin = 0f;

    void Update()
    {
        if (Keyboard.current.wKey.wasPressedThisFrame)
            shootForce += 1;

        if (Keyboard.current.sKey.wasPressedThisFrame)
            shootForce = Mathf.Max(0, shootForce - 1);

        if (Keyboard.current.qKey.wasPressedThisFrame)
            spin += 0.1f;

        if (Keyboard.current.eKey.wasPressedThisFrame)
            spin -= 0.1f;

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
            Shoot();
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

        MagnusEffectKicks ball = bullet.GetComponent<MagnusEffectKicks>();

        ball.Launch(shootForce, spin);
    }
}