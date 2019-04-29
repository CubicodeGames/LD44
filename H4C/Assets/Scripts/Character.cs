using UnityEngine;

public class Character : MonoBehaviour
{
    public int startHealth = 100;
    public float speed = 4.5f;
    public float jumpForce = 12.0f;

    public bool Active { get; set; }
    public bool HasKey { get; private set; }
    public int PickedUpItems { get; private set; }
    public int CurrentHealth { get; private set; }

    private BoxCollider2D _box;
    private Rigidbody2D _body;

    // Use this for initialization
    void Start()
    {
        HasKey = false;
        CurrentHealth = startHealth;
        PickedUpItems = 0;
        _box = GetComponent<BoxCollider2D>();
        _body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!Active) return;

        float deltaX = Input.GetAxis("Horizontal") * speed;
        Vector2 movement = new Vector2(deltaX, _body.velocity.y);
        _body.velocity = movement;

        Vector3 max = _box.bounds.max;
        Vector3 min = _box.bounds.min;
        Vector2 corner1 = new Vector2(max.x, min.y - .1f);
        Vector2 corner2 = new Vector2(min.x, min.y - .2f);
        Collider2D hit = Physics2D.OverlapArea(corner1, corner2);

        bool grounded = false;
        if (hit != null)
        {
            grounded = true;
        }

        _body.gravityScale = (grounded && Mathf.Approximately(deltaX, 0)) ? 0 : 1;
        if (grounded && Input.GetKeyDown(KeyCode.Space))
        {
            _body.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    public void Pickup()
    {
        PickedUpItems++;
    }

    public void PickupKey()
    {
        if (!HasKey)
        {
            HasKey = true;
        }
        else
        {
            GameManager.Instance.GameOver();
        }
    }
}
