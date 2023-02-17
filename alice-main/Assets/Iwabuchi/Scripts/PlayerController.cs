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
    private float SmallS;
    public Rigidbody rb;
    public Vector3 movingVelocity;
    AliceSize SizeScript;
    GameObject Player;

    Vector3 latestPos;//移動している方向
    Vector3 latestPos2;//上下

    public bool jumpNow;
    public bool inArea;
    [SerializeField] float jumpPower = 10f;
    [SerializeField] float gravityPower = -500;

    public bool Debuff = false;//移動速度のデバフ
    public bool Running = false;

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
        SmallS = speedMagnification * 0.8f;
        Player = GameObject.Find("Player");
        SizeScript = Player.GetComponent<AliceSize>();
    }

    void Update()
    {

        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        movingDirecion = new Vector3(x, 0, z);
        movingDirecion.Normalize();//斜め移動の距離を制御

        Walk();
        Jump();
        //+
        if (_move == true)
        {
            Walk();
            Jump();
        }
        else
        {
            if (startStop == true)
            {
                stop = transform.position;
                startStop = false;
            }
            transform.position = stop;
        }
        if (_upStart == true)
        {
            _move = true;
            startStop = true;
        }

        //+
        if (ink == true)
        {
            timeElapsed += Time.deltaTime;

            if (timeElapsed >= timeOut)
            {
                Instantiate(inkObj, new Vector3(transform.position.x, inkSize, transform.position.z), Quaternion.identity);
                inkSize = inkSize - 0.01f;
                if (inkSize <= 0.45f) inkSize = 0.5f;
                timeElapsed = 0.0f;
            }
        }
    }

    private void FixedUpdate()
    {
        Gravity();
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

        Vector3 differenceDis2 = new Vector3(transform.position.x, transform.position.y, transform.position.z) - new Vector3(latestPos2.x, latestPos2.y, latestPos2.z);
        latestPos2 = transform.position;
        if (Mathf.Abs(differenceDis2.y) > 0.001f || -0.001f > Mathf.Abs(differenceDis2.y))
        {
            jumpNow = true;
        }
        else
        {
            jumpNow = false;
        }
    }

    private void Walk()
    {
        bool State = SizeScript.aliceBig;
            //デバフ時はダッシュ不可能
            //シフトキーが押されているなら走る
            if (Input.GetKey(KeyCode.LeftShift))
            {
                if (Debuff == false)
                {
                    movingVelocity = movingDirecion * dashSpeed;
                }
                else
                {
                    movingVelocity = movingDirecion * speedMagnification;
                }
        }
        else 
        {
            if(State == true)
            {
                if(Running == false)
                {
                    movingVelocity = movingDirecion * speedMagnification;
                }
                if(Running == true)//常時ダッシュが入っていたら走る
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
            if (State == false)
            {
                if (Running == false)
                {
                    movingVelocity = movingDirecion * SmallS;
                }
                if (Running == true)//常時ダッシュが入っていたら走る
                {
                    if (Debuff == false)
                    {
                        movingVelocity = movingDirecion * dashSpeed * SmallS;
                    }
                    else if (Debuff == true)
                    {
                        movingVelocity = movingDirecion * speedMagnification * SmallS;
                    }
                }
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
            }
        }

    }

    private void Gravity()
    {
        if(jumpNow == true)//ジャンプ時に重力をつける
        {
            rb.AddForce(new Vector3(0, gravityPower, 0));
        }
    }
    private void OnTriggerStay(Collider other)
    {//触れたらデバフをかける
        if (other.gameObject.CompareTag("Paint") && Debuff == false)
        {
            speedMagnification = DebuffS;
            Debuff = true;
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

    private void SpeedUp()
    {
        speedMagnification = DefaultS;
        Debuff = false;
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