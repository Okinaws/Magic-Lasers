using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Animator animator;
    [SerializeField]
    private float animDelay;
    private float timer = 0;
    [SerializeField]
    private float dieTime;
    [SerializeField]
    private ParticleSystem death;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (animDelay <= timer)
        {
            animator.SetTrigger("Cast Spell");
            timer = 0;
        }
        else
        {
            timer += Time.deltaTime;
        }
    }

    public IEnumerator Die()
    {
        gameObject.tag = "Untagged";
        death.Play();
        animator.SetTrigger("Die");
        yield return new WaitForSeconds(dieTime);
        GameManager.OnEnemyKilled?.Invoke(1);
        PoolManager.Instance.Despawn(gameObject);
    }
}
