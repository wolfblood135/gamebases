using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character_c_2d_iso_V2 : MonoBehaviour
{
    public float speed;

    public float jumpdeg = 1;

    public float hitpersec = 1;

    public float coyotetm = .2F;
    public bool controllabel = true;
    public bool onlycontrol = false;

    public LayerMask whisgr;
    public float nextjmptt = 3;
    //--------------------------------------
    private float speedstart = .2F;
    
    private float coyotezone = 0;

    private float stoptime = .2F;
    private float nextjmptm = 0F;

    private bool isground;

    private bool sagmi;

    private bool uston;
    private bool ustarka;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Animator>().SetFloat("hiz", Mathf.Abs( GetComponent<Rigidbody2D>().velocity.x));
        if (coyotezone < coyotetm)
        {
            coyotezone += Time.deltaTime;
        }

        if (nextjmptm < nextjmptt)
        {
            nextjmptm += Time.deltaTime;
        }
        
        float xaxes = Input.GetAxis("Horizontal");
        float yaxes = Input.GetAxis("Vertical");
        //rigthleft
        isground = Physics2D.Raycast(transform.position, Vector2.down, .5F, whisgr);
        uston = Physics2D.Raycast( new Vector2(transform.position.x,transform.position.y+0.242F), Vector2.right*transform.localScale.x, 0.2F, whisgr);
        if (isground)
        {
            coyotezone = 0;
        }

        
        if (controllabel)
        {
            if (Input.GetAxis("Jump")> 0)
            {
                if (nextjmptm >= nextjmptt)
                {
                    
              if (isground )
               {
                   if ( 1==1)
                   {
                    GetComponent<Rigidbody2D>().AddForce(new Vector2(0,jumpdeg*GetComponent<Rigidbody2D>().mass));
              
                   }
                       
                   


               }
                  else if ( coyotezone < coyotetm)
                   {
                    GetComponent<Rigidbody2D>().velocity = new Vector2(0,GetComponent<Rigidbody2D>().velocity.y);
                    GetComponent<Rigidbody2D>().AddForce(new Vector2(0,jumpdeg*GetComponent<Rigidbody2D>().mass));
              
                   }
              // else if (uston)
              // {
              //     GetComponent<Rigidbody2D>().velocity= Vector2.zero;
              //     GetComponent<Rigidbody2D>().AddForce(new Vector2(-jumpdeg,jumpdeg));
              //     
              // }

                nextjmptm = 0;     
                }
            }
            RaycastHit2D ledgerfront = Physics2D.Raycast(new Vector2(transform.position.x,transform.position.y+0.3F), Vector2.right, 0.3F,whisgr);
            RaycastHit2D ledgerback = Physics2D.Raycast(new Vector2(transform.position.x,transform.position.y+0.3F), Vector2.left, 0.3F,whisgr);
            Debug.DrawLine(new Vector3(transform.position.x,transform.position.y+0.5F,transform.position.z),ledgerfront.point);
            Debug.DrawLine(new Vector3(transform.position.x,transform.position.y+0.5F,transform.position.z),ledgerback.point);
            uston = ledgerfront;
            ustarka = ledgerback;
            if (xaxes>0 && uston == false)
            {
                
                    
                sagmi = true;
                if (GetComponent<Rigidbody2D>().velocity.x < speed)
                {
                    GetComponent<Rigidbody2D>().velocity =     Vector2.Lerp(new Vector2(GetComponent<Rigidbody2D>().velocity.x,GetComponent<Rigidbody2D>().velocity.y),new Vector2(speed,GetComponent<Rigidbody2D>().velocity.y) , speedstart);
                }
                else
                {
                    GetComponent<Rigidbody2D>().velocity = new Vector2(speed,GetComponent<Rigidbody2D>().velocity.y);
                }
                
            }
            else if (xaxes<0 && ustarka == false)
            {
               
                sagmi = false;
                if (GetComponent<Rigidbody2D>().velocity.x > speed)
                {
                    GetComponent<Rigidbody2D>().velocity =     Vector2.Lerp(new Vector2(GetComponent<Rigidbody2D>().velocity.x,GetComponent<Rigidbody2D>().velocity.y),new Vector2(-speed,GetComponent<Rigidbody2D>().velocity.y) , speedstart);
                }
                else
                {
                    GetComponent<Rigidbody2D>().velocity = new Vector2(-speed,GetComponent<Rigidbody2D>().velocity.y);
                }
            }
            else
            {
                GetComponent<Rigidbody2D>().velocity = Vector2.Lerp(GetComponent<Rigidbody2D>().velocity,new Vector2(0, GetComponent<Rigidbody2D>().velocity.y),stoptime);
            }

                }
            if (sagmi)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                  transform.localScale = new Vector3(-1, 1, 1);
                
            }
        }
    

    public void Crttrue()
    {
        controllabel = true;
    } 
    public void crtfalse()
    {
        controllabel = false;
    }
}
