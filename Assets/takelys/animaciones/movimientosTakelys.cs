using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientosTakelys : MonoBehaviour
{
    public float fuerzaSalto;
    private Rigidbody2D rigidbody2d;
    private Animator animator;
     private float Horizontal;
      public float velocidad;
      private bool tocaSuelo;
    // Start is called before the first frame update
    void Start()
    {
        animator= GetComponent<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
         Horizontal =Input.GetAxisRaw("Horizontal")*velocidad;

         Debug.DrawRay(transform.position,Vector3.down * 0.1f, Color.red);

         if(Physics2D.Raycast(transform.position,Vector3.down, 0.1f)){
            tocaSuelo=true;
         }else{
            tocaSuelo=false;
         }

       if(Horizontal<0.0f)transform.localScale= new Vector3(-1.0f,1.0f,1.0f);
         else if(Horizontal>0.0f)transform.localScale= new Vector3(1.0f,1.0f,1.0f);
         animator.SetBool("estaCaminando",Horizontal !=0.0f);

           if (Input.GetKeyDown(KeyCode.W) && tocaSuelo){
            
            animator.SetBool("estaSaltando", true);
            rigidbody2d.AddForce(new Vector2(0,fuerzaSalto));
        }

        
    }
   private void OnCollisionEnter2D(Collision2D collision){
        if( collision.gameObject.tag=="plataforma"){
            animator.SetBool("estaSaltando",false);
        }
    }

    
    private void FixedUpdate()
    
    {
rigidbody2d.velocity = new Vector2(Horizontal,rigidbody2d.velocity.y);

    }
}
