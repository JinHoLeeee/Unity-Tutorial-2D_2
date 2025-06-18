using System.Collections;
using UnityEngine;

public abstract class Monster : MonoBehaviour
{
    private SpriteRenderer sRenderer;
    private Animator animator;
    
    [SerializeField] protected float hp = 3f;
    [SerializeField] protected float moveSpeed = 3f;

    private int dir = 1;
    private bool isMove = true;
    private bool isHit = false;
    
    public abstract void Init();

    void Start()
    {
        sRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        
        Init();
    }

    void OnMouseDown()
    {
        StartCoroutine(Hit(1));
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        if (!isMove)
            return;

        transform.position += Vector3.right * dir * moveSpeed * Time.deltaTime;

        if (transform.position.x > 8f)
        {
            dir = -1;
            sRenderer.flipX = true;
        }
        else if (transform.position.x < -8f)
        {
            dir = 1;
            sRenderer.flipX = false;
        }
    }

    IEnumerator Hit(float damage)
    {
        if (isHit)
            yield break;
            
        isHit = true;
        isMove = false;
        
        hp -= damage;
        
        if (hp <= 0)
        {
            animator.SetTrigger("Death");
            
            yield return new WaitForSeconds(3f);
            Destroy(gameObject);
            
            yield break;
        }
        
        animator.SetTrigger("Hit");

        yield return new WaitForSeconds(0.65f);
        isHit = false;
        isMove = true;
    }
}