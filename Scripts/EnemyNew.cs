using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNew : MonoBehaviour
{
    [Header("Enemy Properties")]
    [SerializeField] int healt = 100;
    public int currentHealt;
    [SerializeField] int goldValue = 150;
    [SerializeField] float minEnemySpeed = 3f;
    [SerializeField] float maxEnemySpeed = 5f;
    Rigidbody2D rbEnemies;

    [Header("Projectile")]
    [SerializeField] float shotCounter = 0;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 2f;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] GameObject projectile;

    [Header("Audio")]
    [SerializeField] AudioClip deathSFX;
    [SerializeField] AudioClip projectileSFX;
    [SerializeField] [Range(0, 1)] float deathSFXVolume = 0.02f;
    [SerializeField] [Range(0, 1)] float projectileSFXVolume = 0.2f;
    public EnemyHealtBar healtBar;
    public Collider2D e_collider;
    Animator animator;
    [SerializeField] public int projectiledmg = 10;
    [SerializeField] float xProjectile = 0.5f;
    [SerializeField] float yProjectile = -0.8f;
    [SerializeField] int yRotation = 180;

    // Start is called before the first frame update
    void Start()
    {
        currentHealt = healt;
        healtBar.SetMaxHealt(healt);
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        rbEnemies = GetComponent<Rigidbody2D>();
        rbEnemies.velocity = new Vector2(Random.Range(minEnemySpeed, maxEnemySpeed), 0.0f);
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        CountDownAndShot();
    }

    void CountDownAndShot()
    {
        if (gameObject.transform.position.x > 5)
        {
            animator.SetBool("Idle", true);
            rbEnemies.velocity = Vector2.zero;
            shotCounter -= Time.deltaTime;
            if (shotCounter <= 0 && e_collider.enabled == true)
            {
                Fire();                
                animator.SetTrigger("Attack");                
            }
        }
    }

    void Fire()
    {
        if (WallProperties.isActive == true)
        {
            Vector2 projectilePosition = gameObject.transform.position;
            projectilePosition.x = gameObject.transform.position.x + xProjectile;
            projectilePosition.y = gameObject.transform.position.y - yProjectile;
            GameObject enemyWeapon = Instantiate(projectile, projectilePosition, Quaternion.Euler(0, yRotation, 0)) as GameObject;
            enemyWeapon.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileSpeed, 0);
            AudioSource.PlayClipAtPoint(projectileSFX, Camera.main.transform.position, projectileSFXVolume);
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
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
            Die();
            rbEnemies.velocity = Vector2.zero;
        }
    }

    void Die()
    {                
        animator.SetBool("Die", true);        
        FindObjectOfType<GameSession>().AddToGold(goldValue);
        Destroy(gameObject, .8f);
        e_collider.enabled = false;        
        AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position, deathSFXVolume);        
    }
}
