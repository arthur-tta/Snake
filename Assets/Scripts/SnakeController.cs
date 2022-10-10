using UnityEngine;

public class SnakeController : MonoBehaviour
{
    [SerializeField] private float speed;

    private float moveTimeMax;
    private Vector2 direction;

    private Rigidbody2D rigidbody;

    private float moveTimeCounter;
    

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();

        direction = new Vector2(1, 0);
        moveTimeMax = 1 / speed;
    }

    private void Update()
    {

        // dieu hien ASDW

        if (Input.GetKeyDown(KeyCode.W) && direction.y != -1)
        {
            direction = new Vector2(0, 1);
        }else if (Input.GetKeyDown(KeyCode.S) && direction.y != 1)
        {
            direction = new Vector2(0, -1);
        }
        else if (Input.GetKeyDown(KeyCode.A) && direction.x != 1)
        {
            direction = new Vector2(-1, 0);
        }
        else if (Input.GetKeyDown(KeyCode.D) && direction.x != -1)
        {
            direction = new Vector2(1, 0);
        }

        // update snake
        moveTimeCounter += Time.deltaTime;
        if(moveTimeCounter >= moveTimeMax)
        {
            this.transform.position = new Vector3(
                this.transform.position.x + direction.x * this.transform.localScale.x,
                this.transform.position.y + direction.y * this.transform.localScale.y,
                0.0f
                );
            moveTimeCounter = 0;
        }
    }
}
