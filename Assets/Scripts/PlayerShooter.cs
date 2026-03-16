using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerShooter : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;
    public TMP_Text infoText;
    public Base angleViewBase;
    public Tube angleViewTube;

    


    public float shootForce = 20f;
    public float spin = 0f;
    float addSpin = 0.5f;
    float addForce = 20f;
    float angleY;
    float angleX;


    void Update()
    {
        // W/S hold to increase/decrease force over time
        if (Keyboard.current.wKey.isPressed)
            shootForce += addForce * Time.deltaTime;

        if (Keyboard.current.sKey.isPressed)
            shootForce = Mathf.Max(0, shootForce - addForce * Time.deltaTime);

        // E/Q hold to adjust spin over time
        if (Keyboard.current.eKey.isPressed)
            spin += addSpin * Time.deltaTime;

        if (Keyboard.current.qKey.isPressed)
            spin -= addSpin * Time.deltaTime;

        UpdateUI();

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
            Shoot();
    }
    void UpdateUI()
    {
        angleY = angleViewBase.angleY;
        angleX = angleViewTube.angleX;

        infoText.text =
        "Force : " + shootForce.ToString("F1") +
        "\nSpin : " + spin.ToString("F1") +
        "\nAngle X : " + angleX.ToString("F1") +
        "\nAngle Y : " + angleY.ToString("F1");
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

        MagnusEffectKicks ball = bullet.GetComponent<MagnusEffectKicks>();

        ball.Launch(shootForce, spin);
    }
}