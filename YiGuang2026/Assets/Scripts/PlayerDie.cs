using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDie : MonoBehaviour
{
    public bool isDead = false;

    [SerializeField] private Transform spawnPoint;   // 在 Inspector 拖入重生点
    [SerializeField] private float deathAnimDuration = 1f; // 死亡动画时长

    public void Die()
    {
        if (isDead) return;   // 防止重复触发
        isDead = true;
        StartCoroutine(DeathSequence());
    }

    private IEnumerator DeathSequence()
    {
        // 死亡后禁用移动
        GetComponent<PlayerMove>().enabled = false;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        // 等待死亡动画播放完毕
        yield return new WaitForSeconds(deathAnimDuration);

        // 回到重生点
        transform.position = spawnPoint.position;

        // 重置状态
        isDead = false;
        GetComponent<PlayerMove>().enabled = true;
    }
}
