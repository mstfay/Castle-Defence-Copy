using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    [Header("Enemy Properies")]
    [SerializeField] float minEnemySpeed = 0.5f;
    [SerializeField] float maxEnemySpeed = 2f;
    [SerializeField] int goldValue = 50;
    public int healt = 100;
    public int currentHealt;
    public float attackRange = 0.5f;
    public int attackDamage = 20;
    public float attackRate = 2f;
    float nextAttackTime = 0f;
    BoxCollider2D boxCollider;

    [Header("Audio")]
    [SerializeField] GameObject deathVFX;
    [SerializeField] float durationOfExplosion = 1f;
    [SerializeField] AudioClip deathSFX;
    [SerializeField] [Range(0, 1)] float deathSFXVolume = 0.02f;
            
    Rigidbody2D rbEnemies;
    Transform wall;
    Animator animator;  
    public Transform attackPoint;    
    public LayerMask wallLayers;
    public EnemyHealtBar healtBar;
    public Collider2D e_collider;
    float xMin = .4f;
    float xMax = .7f;
    float tel;
    
    // Start is called before the first frame update
    void Start()
    {
        if (WallProperties.isActive == true)
        {
            wall = GameObject.FindGameObjectWithTag("Wall").transform;
        }
        boxCollider = GetComponent<BoxCollider2D>();
        currentHealt = healt;
        healtBar.SetMaxHealt(healt);
        animator = GetComponent<Animator>();
        rbEnemies = GetComponent<Rigidbody2D>();
        rbEnemies.velocity = new Vector2(Random.Range(minEnemySpeed, maxEnemySpeed), 0.0f);
        boxCollider.size = new Vector2(Random.Range(xMin, xMax), .7f);
        tel = Random.Range(1.5f, 1.5f);
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
        if (transform.position.x >= wall.position.x - tel)
        {
            rbEnemies.velocity = Vector2.zero;
            if (Time.time >= nextAttackTime)
            {
                animator.SetTrigger("Attack");
                nextAttackTime = Time.time + 4f / attackRate;
            }
        }

    }
    private void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, wallLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<WallProperties>().TakeDamage(attackDamage);
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
    public void Die()
    {
        FindObjectOfType<GameSession>().AddToGold(goldValue);
        e_collider.enabled = false;
        Destroy(gameObject);
        GameObject explosion = Instantiate(deathVFX, transform.position, transform.rotation);
        Destroy(explosion, durationOfExplosion);
        AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position, deathSFXVolume);
    }
}
