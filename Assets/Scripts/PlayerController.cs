using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float baseMass = 1f;
    public float baseMoveSpeed = 5f;
    public float baseJumpForce = 10f;
    public float sizeChangeRate = 0.2f;
    public float sizeLerpSpeed = 5f;
    public float stretch = 100f;
    public Vector3 minSize = new Vector3(0.5f, 0.5f, 0.5f);
    public Vector3 maxSize = new Vector3(3f, 3f, 3f);
    public Slider stretchBar;
    public Transform groundCheck;
    public LayerMask groundLayer;

    public bool isJump = false;
    public bool isGrounded = false;

    private Vector3 targetScale;
    private float moveSpeed = 1f;
    private float jumpForce = 0.5f;
    private float horizontal = 0f;
   [SerializeField] private Transform respawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        stretchBar.maxValue = 100;
        SetUI();
        SetPhysic();
        targetScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if(stretch > -1000000f)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                ChangeSize(sizeChangeRate);
                Debug.Log("Grow");
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                ChangeSize(-1 * sizeChangeRate);
                Debug.Log("Shrink");
            }
        }

        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime * sizeLerpSpeed);
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

        if (isGrounded)
        {
            horizontal = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);

            isJump = false;
            if (rb.velocity.y < 0)
                rb.velocity = new Vector2(rb.velocity.x, 0);
        }
        else
        {
            Vector2 velocity = rb.velocity;
            velocity.x *= Mathf.Clamp01(1f - 1f * Time.fixedDeltaTime);
            rb.velocity = velocity;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isJump && isGrounded)
            {
                isJump = true;
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                Debug.Log("Jump");
                horizontal *= 0.75f;
            }
        }

        Debug.Log($"Velocity: {rb.velocity}");

    }

    private void FixedUpdate()
    {
     

    }

    public void ChangeSize(float size)
    {
        Vector3 newSize = transform.localScale + Vector3.one * size;
        stretch -= 10f;
        SetUI();

        newSize.x = Mathf.Clamp(newSize.x, minSize.x, maxSize.x);
        newSize.y = Mathf.Clamp(newSize.y, minSize.y, maxSize.y);
        newSize.z = Mathf.Clamp(newSize.z, minSize.z, maxSize.z);

        targetScale = newSize;
        SetPhysic();
    }

    public void SetPhysic()
    {

        float scaleFactor = transform.localScale.x;
        rb.mass = baseMass * Mathf.Pow(scaleFactor, 2);
        moveSpeed = baseMoveSpeed / scaleFactor;
        jumpForce = baseJumpForce * scaleFactor;
    }

    public void SetUI()
    {
        stretchBar.value = stretch;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(groundCheck.position, 0.1f);
    }

    public void SetRespawn(Transform checkpoint)
    {
        respawnPoint = checkpoint;
    }

    public IEnumerator Popped()
    {
        stretch -= 10f;
        SetUI();
        yield return new WaitForSeconds(1f);
        transform.position = respawnPoint.position;
    }

}
