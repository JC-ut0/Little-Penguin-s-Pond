
using System.Collections;
using UnityEngine;

public class FishManager : MonoBehaviour
{
    private Rigidbody2D fish;
    public GameObject player;
    public Animator animator;


    public float randomX;
    public float randomY;
    float timeWait = 0f;


    // Start is called before the first frame update
    private void Start()
    {
        fish = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {

        if (timeWait >= 2)
        {
            timeWait = 0f;
            randomX = Random.Range(-5f, 5f);
            randomY = Random.Range(-.5f, .5f);
            if (randomX > 0)
            {
                transform.SetPositionAndRotation(transform.position, new Quaternion(transform.rotation.x, 180f, transform.rotation.z, transform.rotation.w));
            }
            else
            {
                transform.SetPositionAndRotation(transform.position, new Quaternion(transform.rotation.x, 0f, transform.rotation.z, transform.rotation.w));
            }

            fish.AddForce(new Vector2(randomX, randomY), ForceMode2D.Force);
            animator.SetFloat("MovingSpeed", Mathf.Abs(randomX / 5));
            
        }
        timeWait = timeWait +  Time.fixedDeltaTime;
        

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
}