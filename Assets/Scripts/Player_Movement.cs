using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [SerializeField]float speed;
    [SerializeField]float jumpForce;

    //Awake
    private Rigidbody2D rb;
    private Animator anim;
    
    //Ground Sensor 
    bool isGrounded;
    [SerializeField]Transform groundSensor;
    [SerializeField]float sensorRadius;
    [SerializeField]LayerMask ground;



    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(x * speed * Time.deltaTime, 0, 0);
        if(x == 1)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            anim.SetBool("Run", true);
        }
        else if(x == -1)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            anim.SetBool("Run", true);
        }
        else
        {
            anim.SetBool("Run", false);
        }
    }

    void Jump()
    {
        isGrounded = Physics2D.OverlapCircle(groundSensor.position, sensorRadius, ground);
        
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            anim.SetBool("Jump", true);
        }
        else
        {
            anim.SetBool("Jump", false);
        }
    }
    //Ave maria cuando seras mia
    //Si me quisieras tooodo te daria

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Coin"))
        {
            GameManager.Instance.ContadorMonedas();
            Destroy(other.gameObject);
        }
        if(other.CompareTag("DeadZone"))
        {
            GameManager.Instance.LoadLoseScene();
            
        }
        if(other.CompareTag("Star"))
        {
            GameManager.Instance.LoadWinScene();
           
           
        }
        if(other.CompareTag("Bomb"))
        {
            other.GetComponent<Bomb>().BombExplosion();
        }
    
    }
}
