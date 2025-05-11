
using UnityEngine;

public class Tile : MonoBehaviour
{
    public GameManager GameManager;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Destroy(gameObject, 0.05f);
            GameManager.GetComponent<GameManager>().Score += 100;
        }
    }

}
