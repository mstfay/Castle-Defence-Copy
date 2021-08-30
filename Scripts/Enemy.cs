using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Transform wall;
    Animator animator;
    Rigidbody2D rbEnemies;
    [SerializeField] int healt = 100;
    public int currentHealt;
    [SerializeField] int goldValue = 150;
    [SerializeField] float minEnemySpeed = 3f;
    [SerializeField] float maxEnemySpeed = 5f;
    public Collider2D e_collider;

    [SerializeField] AudioClip deathSFX;
    [SerializeField] [Range(0, 1)] float deathSFXVolume = 0.02f;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask wallLayers;
    public int attackDamage = 20;
    public float attackRate = 2f;
    float nextAttackTime = 0f;
    public EnemyHealtBar healtBar;
    [SerializeField] float rangePosition = 2;
    // Start is called before the first frame update
    void Start()
    {
        if (WallProperties.isActive == true)
        {
            wall = GameObject.FindGameObjectWithTag("Wall").transform;
        }
        currentHealt = healt;
        healtBar.SetMaxHealt(healt);
        animator = GetComponent<Animator>();
        rbEnemies = GetComponent<Rigidbody2D>();
        rbEnemies.velocity = new Vector2(Random.Range(minEnemySpeed, maxEnemySpeed), 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (WallProperties.isActive == true)
        {
            StopMove();        
        }
    }

    void StopMove()
    {
        if (gameObject.transform.position.x >= wall.position.x - rangePosition)
        {
            rbEnemies.velocity = Vector2.zero;
            if (Time.time >= nextAttackTime)
            {
                animator.SetTrigger("Attack");
                nextAttackTime = Time.time + 4f / attackRate;
            }
        }
           
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.gameObject.GetComponent<DamageDealer>();
        ProcessHit(damageDealer);
        damageDealer.Hit();
    }

    void ProcessHit(DamageDealer damageDealer)
    {
        currentHealt -= damageDealer.GetArrowDamage();
        damageDealer.Hit();
        healtBar.SetHealt(currentHealt);
        if (currentHealt <= 0)
        {
            rbEnemies.velocity = Vector2.zero;
            Die();
        }
    }

    void Die()
    {
        FindObjectOfType<GameSession>().AddToGold(goldValue);
        animator.SetBool("Die", true);
        e_collider.enabled = false;
        Destroy(gameObject , 0.9f);
        AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position, deathSFXVolume);
    }

    private void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, wallLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<WallProperties>().TakeDamage(attackDamage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
