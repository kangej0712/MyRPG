using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    private AudioSource audioSource;

    public AudioClip eatSound;
    public float speed = 5f;
    public float jumpForce = 10f;

    private bool isJumping = false;
    private Vector3 originalScale;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        originalScale = transform.localScale;
    }

    void Update()
    {
        // �̵� ó��
        float move = Input.GetAxis("Horizontal");

        if (move != 0)
        {
            animator.SetBool("isRunning", true);

            // �̵�
            transform.Translate(Vector2.right * move * speed * Time.deltaTime);

            // ���� ���� (ũ�� ����)
            if (move > 0)
                transform.localScale = new Vector3(Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);
            else if (move < 0)
                transform.localScale = new Vector3(-Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        // ���� ó��
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            animator.SetTrigger("isJumping");
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isJumping = true;
        }
    }

    // ���� ����
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > 0.5f)
        {
            isJumping = false;
        }
    }

    // �����۰� �浹
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("dessert"))
        {
            audioSource.PlayOneShot(eatSound);
            FindObjectOfType<ScoreManager>()?.AddScore(10);
            Destroy(other.gameObject);
        }
    }
}
