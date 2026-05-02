using UnityEngine;

public class ArrowController : MonoBehaviour
{
    public float speed = 15f;
    public float lifeTime = 2f;
    public int damage = 1;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Enemy"))
        {
            // 현재 프로젝트의 EnemyHealth는 부모 오브젝트에 있을 확률이 높으므로 GetComponentInParent 사용
            EnemyHealth enemy = collision.GetComponentInParent<EnemyHealth>();
            
            if (enemy != null)
            {
                // 현재 화살이 날아가는 방향을 계산해서 적에게 넘겨줍니다 (피격 효과용)
                Vector2 hitDirection = transform.right; 
                enemy.TakeDamage(damage, hitDirection); 
            }

            Destroy(gameObject);
        }
    }
}

