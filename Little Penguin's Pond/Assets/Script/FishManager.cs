using UnityEngine;

public class FishManager : MonoBehaviour
{
    private Rigidbody2D fish;
    public Transform player;

    // Start is called before the first frame update
    private void Start()
    {
        fish = GetComponent<Rigidbody2D>();
        Physics2D.IgnoreCollision(fish.transform.GetComponent<Collider2D>(), player.GetComponent<Collider2D>());
    }

    private void FixedUpdate()
    {
        float randomX = Random.Range(-.5f, 0.5f);
        float randomY = Random.Range(-.5f, 0.5f);


        fish.AddForce(new Vector2(randomX, randomY));
    }

    private void Flip()
    {
        // rotate 180
        transform.Rotate(new Vector3(0f, 180f, 0f));
    }

}