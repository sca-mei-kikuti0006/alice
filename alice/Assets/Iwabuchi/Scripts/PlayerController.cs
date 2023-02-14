using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerController : MonoBehaviour
{
    Vector3 movingDirecion;
    [SerializeField] public float speedMagnification;//移動スピード
    [SerializeField] public float dashSpeed = 12;//ダッシュスピード
    private float DefaultS;//通常スピード
    private float DebuffS;//デバフ時のスピード
    public Rigidbody rb;
    public Vector3 movingVelocity;

    Vector3 latestPos;//移動している方向

    private bool jumpNow;
    [SerializeField] float jumpPower = 10f;
    [SerializeField] float gravityPower = -500;

    public bool Debuff = false;
    public bool Running = false;
    internal bool inArea;

    //+
    private bool ink = false;
    public GameObject inkObj;
    private float timeOut = 1.0f;
    private float timeElapsed = 0;
    private float inkSize = 0.5f;
    private bool _move = true;
    private bool _upStart = false;
    Vector3 stop;
    private bool startStop = true;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        DefaultS = speedMagnification;//defaultSに代入する
        DebuffS = speedMagnification * 0.25f;//デバフ時のスピードを設定
        
    }

    void Update()
    {

        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        movingDirecion = new Vector3(x, 0, z);
        movingDirecion.Normalize();//斜め移動の距離を制御


        //+
        if (_move == true)
        {
            Woark();
            Jump();
        }
        else {
            if (startStop == true)
            {
                stop = transform.position;
                startStop = false;
            }
            transform.position = stop;
            this.GetComponent<Renderer>().material.color -= new Color(0, 0, 0, 1);
        }
        if (_upStart == true)
        {
            _move = true;
            startStop = true;
            this.GetComponent<Renderer>().material.color += new Color(0, 0, 0, 1);
        }

        //+
        if (ink == true)
        {
            timeElapsed += Time.deltaTime;

            if (timeElapsed >= timeOut)
            {
                Instantiate(inkObj, new Vector3(transform.position.x, inkSize, transform.position.z), Quaternion.identity);
                inkSize = inkSize - 0.01f;
                if(inkSize<=0.45f)inkSize = 0.5f;
                timeElapsed = 0.0f;
            }
        }
    }

    private void FixedUpdate()
    {
        Gravity();
        //if (jumpNow == true) return;
        rb.velocity = new Vector3(movingVelocity.x, rb.velocity.y, movingVelocity.z);

        //前フレームとの位置の差から進行方向を割り出してその方向に回転させる
        Vector3 differenceDis = new Vector3(transform.position.x, 0, transform.position.z) - new Vector3(latestPos.x, 0, latestPos.z);
        latestPos = transform.position;
        if(Mathf.Abs(differenceDis.x) > 0.001f || Mathf.Abs(differenceDis.z) > 0.001f)
        {
            if(movingDirecion == new Vector3(0, 0, 0)) return;
            Quaternion rot = Quaternion.LookRotation(differenceDis);
            rot = Quaternion.Slerp(rb.transform.rotation, rot, 0.2f);
            this.transform.rotation = rot;
        }
    }

    private void Woark()
    {
        if(Running == false)
        {
            if (Input.GetKey(KeyCode.LeftShift) && Debuff == false)
            {
                movingVelocity = movingDirecion * dashSpeed;
            }
            else
            {
                movingVelocity = movingDirecion * speedMagnification;
            }
        }
        if(Running == true)
        {
            if(Debuff == false)
            {
                movingVelocity = movingDirecion * dashSpeed;
            }
            else if(Debuff == true)
            {
                movingVelocity = movingDirecion * speedMagnification;
            }
        }
    }
    
private void Jump()
    {
        if(jumpNow == true)
        {
            return;
        }
        if (jumpNow == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(transform.up * jumpPower, ForceMode.Impulse);

                jumpNow = true;
                
                Debug.Log("空中");

                //jumpNow = true;
                //Debug.Log("ジャンプ開始");
            }
        }

    }

    private void Gravity()
    {
        if(jumpNow == true)
        {
            rb.AddForce(new Vector3(0, gravityPower, 0));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(jumpNow == true)
        {
            if(collision.gameObject.CompareTag("Ground"))
            {
                jumpNow = false;
                //GetComponent<Renderer>().material.color = new Color32(0, 255, 0, 1);
                Debug.Log("着地");
            }
        }
        
        if(collision.gameObject.CompareTag("Ivy"))
        {
            if (Input.GetKey(KeyCode.G))
            {
                Transform myTransform = this.transform;
                Vector3 pos = transform.position;
                Debug.Log("押されてる");
                pos.y += 0.1f;
                myTransform.position = pos;
            }
        }
        
    }
    //触れたらデバフをかける
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Paint") && Debuff == false)
        {
            Debug.Log("鈍足");
            speedMagnification = DebuffS;
            Debuff = true;
            ink = true;
        }
    }

//出てから五秒たったらスピードを戻す
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Paint"))
        {
            Invoke("SpeedUp", 5);
            
        }
    }
    /*
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            if(jumpNow = false)
            {
                jumpNow = true;
                GetComponent<Renderer>().material.color = new Color32(255, 0, 0, 1);
                Debug.Log("空中");
            }
            if(jumpNow = true)
            {
                return;
            }
    }
    */
    private void SpeedUp()
    {
        speedMagnification = DefaultS;
        Debuff = false;
        ink = false;
    }

    //+
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hat")
        {
            _move = false;
        }
    }

    //getset
    public bool upStart
    {
        set { this._upStart = value; }
        get { return this._upStart; }
    }
    public bool move
    {
        set { this._move = value; }
        get { return this._move; }
    }
}
