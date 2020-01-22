using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpScript : MonoBehaviour
{

    public static PlayerJumpScript instance;
    private Rigidbody2D myBody;
    private Animator anim;

    [SerializeField]
    private float forceX;

    [SerializeField]
    private float forceY;

    private float thresholdX =7f;
    private float thresholdY = 14f;

    private bool setPower, didJump;

    void Awake()
    {
        makeInstance();
        Initilize();
    }
    void makeInstance()
    {
        if(instance==null)
        {
            instance = this;
        }
    }
    void Initilize()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>(); 
    }
    void SetPower()
    {
        if(setPower)
        {
            forceX += thresholdX * Time.deltaTime;

            forceY += thresholdY * Time.deltaTime;
            if (forceX > 6.5f)
                forceX = 6.5f;

            if (forceY > 13.5f)
                forceY = 13.5f;
        }
        else
        {

        }
    }
    public void SetPower(bool setPower)
    {

        this.setPower = setPower;
        if(!setPower)
        {
            Jump();
        }
    }
    public void Jump()
    {
        myBody.velocity = new Vector2(forceX, forceY);
        forceX = forceY = 0f;
        didJump = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(didJump)
        {
            didJump = false;
            if (collision.tag == "platform")
            {
                if(gManager.instance!=null)
                {
                    gManager.instance.lerpAndPlatform(collision.transform.position.x);
                }
            }
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetPower();
    }
}
