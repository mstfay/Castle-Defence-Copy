using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] float arrowVelocity = -5f;
    ArcherControl arrow;
    bool nowAttack = false;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(arrowVelocity, 0f);
        arrow = FindObjectOfType<ArcherControl>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// Ok düşmana carpınca oku yok eder, ekrandaki ok sayısını 1 azaltır.
    /// </summary>
    /// <param name="collision"></param>
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Shredder")
        {
            if (nowAttack) { return; }
            nowAttack = true;
            arrow.AttackDecrease();
            Destroy(gameObject);

        }
    }
    private void OnDestroy()
    {
        nowAttack = false;
    }
}
