using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherControl : MonoBehaviour
{
    [Header("Archer Stats")]
    int maxArrowOnScreen;
    int currentArrowOnScreen;

    [Header("Arrow")]
    [SerializeField] GameObject arrowPrefab;
    [SerializeField] AudioClip arrowSFX;
    [SerializeField] [Range(0,1)] float arrowSFXVolume = 0.75f;

    float yMin, yMax;
    Rigidbody2D rb;
    public Animator animator;
    Vector2 velocity;

    PauseGame pause;
    public GameObject pauseUI;
    Level shoot;
    [SerializeField] float waitTime = 0.5f;

    Joystick joystick;
    JoystickButton joystickButton;
    public bool shooting;
    SliderControl sliderControl;
    PlayerStats stats;
    void Start()
    {
        stats = PlayerStats.instance;
        pause = FindObjectOfType<PauseGame>();
        shoot = FindObjectOfType<Level>();
        maxArrowOnScreen = stats.maxArrow;
        SetUpMoveBoundaries();
        joystick = FindObjectOfType<Joystick>();
        joystickButton = FindObjectOfType<JoystickButton>();
        rb = GetComponent<Rigidbody2D>();
        sliderControl = FindObjectOfType<SliderControl>();
        InvokeRepeating("RegenHealt", 1f/stats.healtRegenRate, 1f/stats.healtRegenRate);
    }    


    // Update is called once per frame
    void Update()
    {
        ArcherMovement();
        ArcherManuelAttack();
        if (shoot.canShoot == true && pauseUI.activeInHierarchy == false)
        {
            JoystickControl();
            ScreenTouch();
        }
    }
    /// <summary>
    /// Ekrana dokununca karakterin ok atmasını sağlar.Dokunma, koordinat ile sınırlıdır.Ok atma sınırlıdır.
    /// </summary>
    void ScreenTouch()
    {
        if (currentArrowOnScreen < maxArrowOnScreen)
        {
            if (Input.touchCount > 0)
            {
                Touch finger = Input.GetTouch(0);
                if (pause.gameIsPaused != true)
                {
                    if (finger.position.x > 500 && finger.position.y < 650)                       
                    {
                        if (finger.phase == TouchPhase.Began && shooting == false)
                        {
                            shooting = true;
                            animator.SetTrigger("Attack");
                            StartCoroutine(WaitForArrow());
                            ArcherStopAttack();
                            finger.phase = TouchPhase.Ended;
                        }

                        if (finger.phase == TouchPhase.Ended && shooting == true)
                        {
                            shooting = false;
                        }
                    }
                }
            }
        }            
    }

    void RegenHealt()
    {
        stats.curHealt += 1;
    }

    /// <summary>
    /// Karakerin ekran hareketini y ekseninde sınırlamak için kullanılmıştır.
    /// </summary>
    private void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + 1f;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - 7f;
    }

    void ArcherManuelAttack()
    {
        if (currentArrowOnScreen < maxArrowOnScreen)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                animator.SetTrigger("Attack");
                StartCoroutine(WaitForArrow());
                ArcherStopAttack();
            }            
        }
      
    }

    /// <summary>
    /// Ekrandaki ok sayısına göre ok prefabini ekranda var eder. Animasyon bekletme süresi tanımlıdır.
    /// </summary>
    /// <returns></returns>
    IEnumerator WaitForArrow()
    {
        yield return new WaitForSeconds(waitTime);
        Vector2 arrowPosition = gameObject.transform.position;
        arrowPosition.x = gameObject.transform.position.x - 1;
        arrowPosition.y = gameObject.transform.position.y - 0.2f;
        Instantiate(arrowPrefab, arrowPosition, Quaternion.Euler(0, 0, 180));
        AudioSource.PlayClipAtPoint(arrowSFX, Camera.main.transform.position, arrowSFXVolume);
    }

    /// <summary>
    /// Ekrandaki ok sayısını 1 arttırır ve slider' a aktarır.
    /// </summary>
    public void ArcherStopAttack()
    {
        currentArrowOnScreen++;
        sliderControl.SliderValue(maxArrowOnScreen, currentArrowOnScreen);
    }

    /// <summary>
    /// Ekrandaki ok sayısını 1 azaltır ve slider' a aktarır.
    /// </summary>
    public void AttackDecrease()
    {
        currentArrowOnScreen--;
        sliderControl.SliderValue(maxArrowOnScreen, currentArrowOnScreen);
    }

    void ArcherMovement()
    {
        var deltaY = Input.GetAxis("Vertical") * PlayerStats.instance.movementSpeed * Time.deltaTime;
        var newYPos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);
        transform.position = new Vector2(transform.position.x, newYPos);
    }    

    /* var bir float değişkendir. İki kelime de kullanılabilir. İleride bir archer yerine warrior kullanıırsak diye 
     * warrior için hareket mekanizması yazdık. Daha sonra bakılacak.
     * */
    void WarriorMovement()
    {
        float deltaX = Input.GetAxis("Horizonal") * PlayerStats.instance.movementSpeed * Time.deltaTime;
        float newXPos = transform.position.x + deltaX;
        float deltaY = Input.GetAxis("Vertical") * PlayerStats.instance.movementSpeed * Time.deltaTime;
        float newYPos = transform.position.y + deltaY;        

        transform.position = new Vector2(newXPos, newYPos);
    }
    
    /// <summary>
    /// Karakterin hareketi y koordinatında sınırlıdır ve joystick üzerinden kontrol edilmesi sağlanır.
    /// </summary>
    void JoystickControl()
    {
        float movementInput = joystick.Vertical;
        if (movementInput > 0 && transform.position.y <= 2)
        {
            rb.velocity = new Vector2(0, PlayerStats.instance.movementSpeed);
            animator.SetBool("Walk", true);
        }
        else if (movementInput < 0 && transform.position.y >= -7.8)
        {
            rb.velocity = new Vector2(0, -PlayerStats.instance.movementSpeed);
            animator.SetBool("Walk", true);
        }
        else
        {
            animator.SetBool("Walk", false);
            rb.velocity = Vector2.zero;
        }
        transform.Translate(velocity * Time.deltaTime);
    }

    public void DamagePlayer(int damage)
    {
        stats.curHealt -= damage;
        if (stats.curHealt <= 0)
        {
            //Oyuncu ölür...
            Debug.Log("Game Over");
        }
    }    
}
