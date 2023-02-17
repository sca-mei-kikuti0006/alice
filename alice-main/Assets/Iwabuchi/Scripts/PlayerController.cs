using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerController : MonoBehaviour
{
    Vector3 movingDirecion;
    [SerializeField] public float speedMagnification;//�ړ��X�s�[�h
    [SerializeField] public float dashSpeed = 12;//�_�b�V���X�s�[�h
    private float DefaultS;//�ʏ�X�s�[�h
    private float DebuffS;//�f�o�t���̃X�s�[�h
    private float SmallS;
    public Rigidbody rb;
    public Vector3 movingVelocity;
    AliceSize SizeScript;
    GameObject Player;

    Vector3 latestPos;//�ړ����Ă������
    Vector3 latestPos2;//�㉺

    public bool jumpNow;
    public bool inArea;
    [SerializeField] float jumpPower = 10f;
    [SerializeField] float gravityPower = -500;

    public bool Debuff = false;//�ړ����x�̃f�o�t
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
        DefaultS = speedMagnification;//defaultS�ɑ������
        DebuffS = speedMagnification * 0.25f;//�f�o�t���̃X�s�[�h��ݒ�
        SmallS = speedMagnification * 0.8f;
        Player = GameObject.Find("Player");
        SizeScript = Player.GetComponent<AliceSize>();
    }

    void Update()
    {

        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        movingDirecion = new Vector3(x, 0, z);
        movingDirecion.Normalize();//�΂߈ړ��̋����𐧌�

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

        //�O�t���[���Ƃ̈ʒu�̍�����i�s����������o���Ă��̕����ɉ�]������
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
            //�f�o�t���̓_�b�V���s�\
            //�V�t�g�L�[��������Ă���Ȃ瑖��
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
                if(Running == true)//�펞�_�b�V���������Ă����瑖��
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
                if (Running == true)//�펞�_�b�V���������Ă����瑖��
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
        if(jumpNow == true)//�W�����v���ɏd�͂�����
        {
            rb.AddForce(new Vector3(0, gravityPower, 0));
        }
    }
    private void OnTriggerStay(Collider other)
    {//�G�ꂽ��f�o�t��������
        if (other.gameObject.CompareTag("Paint") && Debuff == false)
        {
            speedMagnification = DebuffS;
            Debuff = true;
        }
    }

//�o�Ă���ܕb��������X�s�[�h��߂�
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