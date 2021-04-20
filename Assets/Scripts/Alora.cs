using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Alora : MonoBehaviour
{
    
    private Rigidbody2D rigid_body;
    [HideInInspector]
    public Animator animator;

    private float x_input;
    private float y_input;
    private Vector2 curr_dir;
    private SpriteRenderer spriteRenderer;

    public float speed;

    public static Alora instance;

    [HideInInspector]
    public bool is_busy;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(gameObject);
        animator = this.GetComponent<Animator>();
        rigid_body = this.GetComponent<Rigidbody2D>();
        spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        x_input = Input.GetAxisRaw("Horizontal");
        y_input = Input.GetAxisRaw("Vertical");
        if (!is_busy)
        {
            Move();
        }
        
    }

    private void Move()
    {
        if (x_input == 0 && y_input == 0)
        {
            animator.SetBool("isWalking", false);
        }
        else
        {
            if (x_input < 0)
            {
                curr_dir = Vector2.left;
                spriteRenderer.flipX = false;
            }
            else if (x_input > 0)
            {
                curr_dir = Vector2.right;
                spriteRenderer.flipX = true;
            }
            animator.SetBool("isWalking", true);
        }

        Vector2 movementVector = new Vector2(x_input, y_input) * speed;
        rigid_body.velocity = movementVector;
    }
}
