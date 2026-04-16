using UnityEngine;

public class RangedAttack : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab; // 1단계 프리팹
    [SerializeField] private Transform firePoint;      // 발사 위치
    [SerializeField] private float attackCooldown = 0.3f;

    private float timer;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= attackCooldown)
        {
            Vector2 dir = Vector2.zero;
            // 화살표 키 입력 즉시 감지
            if (Input.GetKey(KeyCode.UpArrow)) dir = Vector2.up;
            else if (Input.GetKey(KeyCode.DownArrow)) dir = Vector2.down;
            else if (Input.GetKey(KeyCode.LeftArrow)) dir = Vector2.left;
            else if (Input.GetKey(KeyCode.RightArrow)) dir = Vector2.right;

            if (dir != Vector2.zero)
            {
                Shoot(dir);
                timer = 0f;
            }
        }
    }

    private void Shoot(Vector2 dir)
    {
        GameObject go = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
        go.GetComponent<Projectile>().Setup(dir);
    }
}