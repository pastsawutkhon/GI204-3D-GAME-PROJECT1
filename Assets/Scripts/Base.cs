using UnityEngine;

public class Base : MonoBehaviour
{
    public float rotateSpeed = 30f;
    public float angleY;

    
    void Update()
    {
        float turn = 0f;

        if (Input.GetKey(KeyCode.RightArrow))
            turn = 1f;
        else if (Input.GetKey(KeyCode.LeftArrow))
            turn = -1f;

        if (Mathf.Abs(turn) > 0f)
        {
            transform.Rotate(0f, turn * rotateSpeed * Time.deltaTime, 0f, Space.Self);

            Vector3 euler = transform.localEulerAngles;
            
            float y = euler.y;
            if (y > 180f) y -= 360f;
            y = Mathf.Clamp(y, -30f, 30f);
            transform.localEulerAngles = new Vector3(euler.x, y, euler.z);
        }

        angleY = transform.rotation.eulerAngles.y;
        if (angleY > 180f) angleY -= 360f;
    }
}
