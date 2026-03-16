using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Update()
    {
        float x = 0f;
        
        if (Input.GetKey(KeyCode.D))
            x = 1f;
        else if (Input.GetKey(KeyCode.A))
            x = -1f;

        Vector3 move = new Vector3(x, 0f, 0f).normalized;
        transform.Translate(move * moveSpeed * Time.deltaTime, Space.World);

        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -10f, 10f);
        transform.position = pos;
    }
}
