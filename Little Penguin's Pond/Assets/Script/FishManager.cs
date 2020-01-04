using UnityEngine;

public class FishManager : MonoBehaviour
{
    private Rigidbody2D fish;
    public GameObject player;
    public Animator animator;

    public bool turnAble = false;

    public float speed;
    public float randomX;
    public float randomY;
    private float timeWait = 2f;
    GameObject food;
    bool hasEaten = false;

    // Start is called before the first frame update
    private void Start()
    {
        fish = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        FindFood();
        if (timeWait >= 2)
        {
            timeWait = 0f;
            randomX = Random.Range(-5f, 5.2f);
            randomY = Random.Range(-.5f, .6f);
            if (randomX > 0 && turnAble)
            {
                transform.SetPositionAndRotation(transform.position, new Quaternion(transform.rotation.x, 180f, transform.rotation.z, transform.rotation.w));
            }
            else
            {
                transform.SetPositionAndRotation(transform.position, new Quaternion(transform.rotation.x, 0f, transform.rotation.z, transform.rotation.w));
            }

            fish.AddForce(new Vector2(randomX, randomY), ForceMode2D.Force);
            if (turnAble)
            {
                animator.SetFloat("MovingSpeed", Mathf.Abs(randomX / 5));
            }
        }
        timeWait = timeWait + Time.fixedDeltaTime;
        
    }
    void FindFood()
    {
        food =  GameObject.FindGameObjectWithTag("Food");
        if (food != null && ! hasEaten)
        {
            transform.position = Vector2.MoveTowards(transform.position, food.GetComponent<Transform>().position,  speed * Time.fixedDeltaTime);
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