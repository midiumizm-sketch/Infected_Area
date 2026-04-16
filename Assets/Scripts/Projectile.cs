using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 12f;
    [SerializeField] private int damage = 1;
    [SerializeField] private float lifeTime = 2f;

    private Vector2 moveDirection;

    public void Setup(Vector2 dir)
    {
        moveDirection = dir.normalized;
        // 방향에 맞춰 회전
        float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
        Destroy(gameObject, lifeTime); // 일정 시간 후 삭제
    }

    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 친구의 코드인 EnemyHealth 확인
        EnemyHealth enemy = collision.GetComponentInParent<EnemyHealth>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage, moveDirection); // 대미지 전달
            Destroy(gameObject);
        }
    }
}