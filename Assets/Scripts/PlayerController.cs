using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public float salto = 5;
    public float velocity = 10;
    public int saltosHechos;
    public int limiteSaltos = 3;
    Rigidbody2D rb; 
    SpriteRenderer sr;
    Animator animator;
    const int ANIMATION_QUIETO = 0;
    const int ANIMATION_CORRER = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        
        Debug.Log("Iniciando Script de player");
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        saltosHechos = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //rb.velocity.x;
        //rb.velocity.y;

        /**
         *! Eventos del Teclado 
        ** GetKey: Mientras mantenemos presionana la tecla
        ** GetKeyUp: Al soltar la tecla
        ** GetKeyDow: Al momento de presionar la tecla una sola vez
        */
 
         rb.velocity = new Vector2(0, rb.velocity.y);
          //animator.SetInteger("Estado", 0);
          ChangeAnimation(ANIMATION_QUIETO);

        if(Input.GetKey(KeyCode.RightArrow)){
            
            rb.velocity = new Vector2(velocity, rb.velocity.y);
            sr.flipX = false;
          //  animator.SetInteger("Estado", 1);
          ChangeAnimation(ANIMATION_CORRER);
        }

        if(Input.GetKey(KeyCode.LeftArrow)){

            rb.velocity = new Vector2(-velocity, rb.velocity.y);
            sr.flipX = true;
           // animator.SetInteger("Estado", 1);
           ChangeAnimation(ANIMATION_CORRER);
        }

        if(Input.GetKeyDown(KeyCode.Space)){
            if(saltosHechos<limiteSaltos){
            rb.AddForce(new Vector2(0, salto), ForceMode2D.Impulse);
            //rb.velocity = new Vector2(rb.velocity.x, +salto);
            saltosHechos++;
            }
        }
       
    }

    void ChangeAnimation(int animation){
        animator.SetInteger("Estado", animation);

    }
    void OnCollisionEnter2D(Collision2D objeto){
        if(objeto.collider.tag=="Suelo"){
          saltosHechos = 0;  
        }
    }
}
