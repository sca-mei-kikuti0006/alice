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
    public Rigidbody rb;
    public Vector3 movingVelocity;

    Vector3 latestPos;//�ړ����Ă������

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
        DefaultS = speedMagnification;//defaultS�ɑ������
        DebuffS = speedMagnification * 0.25f;//�f�o�t���̃X�s�[�h��ݒ�
        
    }

    void Update()
    {

        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        movingDirecion = new Vector3(x, 0, z);
        movingDirecion.Normalize();//�΂߈ړ��̋����𐧌�


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
                
                Debug.Log("��");

                //jumpNow = true;
                //Debug.Log("�W�����v�J�n");
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
                Debug.Log("���n");
            }
        }
        
        if(collision.gameObject.CompareTag("Ivy"))
        {
            if (Input.GetKey(KeyCode.G))
            {
                Transform myTransform = this.transform;
                Vector3 pos = transform.position;
                Debug.Log("������Ă�");
                pos.y += 0.1f;
                myTransform.position = pos;
            }
        }
        
    }
    //�G�ꂽ��f�o�t��������
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Paint") && Debuff == false)
        {
            Debug.Log("�ݑ�");
            speedMagnification = DebuffS;
            Debuff = true;
            ink = true;
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
    /*
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            if(jumpNow = false)
            {
                jumpNow = true;
                GetComponent<Renderer>().material.color = new Color32(255, 0, 0, 1);
                Debug.Log("��");
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
