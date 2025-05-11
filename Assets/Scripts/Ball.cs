using UnityEngine;
public class Ball : MonoBehaviour
{
    public float speed = 5f;
    public Vector3 spawnPos;
    public Vector3 direction;

    void FixedUpdate()
    {
        Vector2 move = direction * speed * Time.fixedDeltaTime;
        GetComponent<Rigidbody2D>().MovePosition(GetComponent<Rigidbody2D>().position + move);
    }


    void Start()
    {
        gameObject.transform.position = spawnPos;
        int direc = Mathf.RoundToInt(Random.Range(1, 3));
        print(direc);
        switch (direc)
        {
            case 1:
                direction = new Vector3(-1, 1, 0);
                break;
            case 2:
                direction = new Vector3(1, 1, 0);
                break;
        }

        direction.Normalize();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Platform"))
        {
            ContactPoint2D contact = collision.contacts[0];
            Vector2 normal = contact.normal;

            if (collision.gameObject.CompareTag("Platform"))
            {
                float hitFactor = (transform.position.x - collision.transform.position.x) / collision.collider.bounds.size.x;

                float angle = hitFactor * 90f;

                direction = new Vector3(Mathf.Sin(angle * Mathf.Deg2Rad), Mathf.Cos(angle * Mathf.Deg2Rad), 0).normalized;

            }
            else
            {
                Vector2 reflected = Vector2.Reflect(direction, normal);
                direction = new Vector3(reflected.x, reflected.y, 0).normalized;
            }
        }
    }

}
