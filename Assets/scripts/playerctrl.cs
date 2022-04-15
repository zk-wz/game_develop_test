using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerctrl : MonoBehaviour
{
    public Rigidbody2D player_rigidbody;
    public float speed;
    public float jumpHeight;
    public LayerMask ground;
    public float rotationSpeed;
    public Collider2D coll;
    public Collider2D boost;
    public Collider2D up;
    public Animator anim,final;
    public AudioSource jumpaudio,portalaudio;
    float jumpx, speedx; 
    int jumpnumber = 0; 
    bool jumppressed = false,iffire1 = false;
    public Collider2D cursewhite1,curseblack1,ddl,port,blho;
    public Transform white1,black1;
    // Start is called before the first frame update
    void Start()
    {
        transform.DetachChildren();
    }
    void Update()
    {
        if (Input.GetButtonDown("Jump")) //跳跃（由于跳跃放入fixedupdate会出bug所以将其单独放入update
        {
            jumpnumber += 1;
            if (jumpnumber <= 1)
            {
                if (Input.GetButton("Fire3"))
                    jumpx = 1.0f;
                else
                    jumpx = 2.5f;
                jumppressed = true;
            }
        }
        if(Input.GetButtonDown("Fire1")&&coll.IsTouching(cursewhite1))
            iffire1 = true;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //float x = 5.5f,y = 1.5f;
        switchanim();
        movement();
        jump();
        if(coll.IsTouching(ddl)||coll.IsTouching(blho))
        {
            GetComponent<AudioSource>().enabled = false;
            Invoke("Restartgame",1.0f);
        }
        if(coll.IsTouching(port)&&SceneManager.GetActiveScene().buildIndex==3)
        {
            Invoke("Nextscene",2f);
            final.SetBool("az",true);
        }
        if(coll.IsTouching(port))
        {
            Nextscene();
            final.SetBool("az",true);
        }
    }
    //玩家移动组件
    void movement()
    {
        if (Input.GetButton("Fire3")) speedx = 2.5f; else speedx = 1.0f;
        //角色左右移动
        float rlmove = Input.GetAxis("Horizontal");
        player_rigidbody.velocity = new Vector2(rlmove * speed * Time.deltaTime * speedx, player_rigidbody.velocity.y);
        //旋转
        transform.Rotate(0, 0, -1 * rlmove * rotationSpeed * speedx, Space.Self);
        if (coll.IsTouching(boost))
            player_rigidbody.velocity = new Vector2(speed * Time.deltaTime * speedx * 5, player_rigidbody.velocity.y);
        if (coll.IsTouching(up))
            player_rigidbody.velocity = new Vector2(player_rigidbody.velocity.x, jumpHeight * jumpx * 5);
            if (coll.IsTouching(cursewhite1)&&iffire1)
            {
                transform.position = black1.position;
                portalaudio.Play();
                iffire1 = false;
            }
            if (coll.IsTouching(curseblack1)&&iffire1)
            {
                transform.position = white1.position;
                portalaudio.Play();
                iffire1 = false;
            }
    }
        //角色状态切换动画
        void switchanim()
        {
            if (Input.GetButton("Fire3"))
                anim.SetBool("ifshift", true);
            else
                anim.SetBool("ifshift", false);
        }
        void jump()
        {
            if (jumppressed)
            {
                jumpaudio.Play();
                player_rigidbody.velocity = new Vector2(player_rigidbody.velocity.x, jumpHeight * jumpx);
                jumppressed = false;
            }
            if (coll.IsTouchingLayers(ground))
                jumpnumber = 0;
        }
        void Restartgame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        void Nextscene(){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
    }

