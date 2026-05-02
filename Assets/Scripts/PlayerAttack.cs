using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject arrowPrefab;
    public Transform firePoint;

    [Header("공격 설정")]
    public float attacksPerSecond = 3f; 
    private float lastFireTime = 0f;

    void Update()
    {
        float fireDelay = 1f / attacksPerSecond;

        if (Time.time >= lastFireTime + fireDelay)
        {
            // 방향키를 누르고 있는 동안 발사
            if (Input.GetKey(KeyCode.UpArrow)) Shoot(90f);
            else if (Input.GetKey(KeyCode.DownArrow)) Shoot(-90f);
            else if (Input.GetKey(KeyCode.LeftArrow)) Shoot(180f);
            else if (Input.GetKey(KeyCode.RightArrow)) Shoot(0f);
        }
    }

    void Shoot(float angle)
    {
        lastFireTime = Time.time;
        GameObject arrow = Instantiate(arrowPrefab, firePoint.position, Quaternion.identity);
        arrow.transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}