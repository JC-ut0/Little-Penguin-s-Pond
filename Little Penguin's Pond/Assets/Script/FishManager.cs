using UnityEngine;

public class FishManager : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject player;
    public Animator animator;

    public bool turnAble = false;

    public float speed;
    public int multiplier = 1;
    public Vector2 movement;
    private float timeWait = 2f;
    private GameObject food;
    private bool hasEaten = false;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        FindFood();

        timeWait = 0f;
        movement.x = Random.Range(0f, 5.2f);
        movement.y = Random.Range(0f, .6f);
        if (Random.Range(0f, 1f) < 0.01)
        {
            multiplier *= -1;
        }
        if (multiplier > 0 && turnAble)
        {
            transform.SetPositionAndRotation(transform.position, new Quaternion(transform.rotation.x, 180f, transform.rotation.z, transform.rotation.w));
        }
        else
        {
            transform.SetPositionAndRotation(transform.position, new Quaternion(transform.rotation.x, 0f, transform.rotation.z, transform.rotation.w));
        }
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime * multiplier);

        if (turnAble)
        {
            animator.SetFloat("MovingSpeed", Mathf.Abs(movement.x / 5.2f));
        }
    }

    private void FindFood()
    {
        food = GameObject.FindGameObjectWithTag("Food");
        if (food != null && !hasEaten)
        {
            transform.position = Vector2.MoveTowards(transform.position, food.GetComponent<Transform>().position, speed * Time.fixedDeltaTime);
        }
    }

    private void Flip()
    {
        // rotate 180
        transform.Rotate(new Vector3(0f, 180f, 0f));
    }

    private void OnEnable()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), player.GetComponent<Collider2D>());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Food" && !hasEaten)
        {
            Destroy(collision.collider.gameObject);
            food = null;
            hasEaten = true;
            Debug.Log("eat food");
        }
    }
}