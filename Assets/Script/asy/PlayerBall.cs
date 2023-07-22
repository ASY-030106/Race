using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class PlayerBall : MonoBehaviour
{
    Rigidbody rigid;
    public int cnt;
    bool isJump;
    public float time;
    //public List<int> itemsList = new List<int>();
    public Text lifeUI, ScoreUI, FinishUI;


    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        cnt = 0;
        isJump = false;
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && !isJump) //isJump�� false��
        {
            isJump = true; //isJump�� true�� �Ǹ鼭 ������ �ٽ� ���ϰ��� ( �������� ���� )
            rigid.AddForce(new Vector3(0,50,0),ForceMode.Impulse);
        }
    }

    void FixedUpdate()
    {
        float ho = Input.GetAxisRaw("Horizontal"); //������ ����
        float ve = Input.GetAxisRaw("Vertical"); // ���� �Ʒ���
        rigid.AddForce(new Vector3(ho, 0,ve), ForceMode.Impulse); //�������� ������ ���Ը� ������ ��
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            Debug.Log("Floor�� ����");
            isJump = false; //�ٴڿ� ������ �ٽ� ������ �����ϰ� �ϱ� ���ؼ� false�� �ٲٸ鼭 �ٽ� ���� ����
        }
    }

    private void OnTriggerStay(Collider other)
    {
        
        Debug.Log(cnt);

        if (cnt >= 9)
        {
            if (other.name == "Point")
            {
                rigid.AddForce(Vector3.up * 5, ForceMode.Impulse);
            }
        }

        if (cnt >= 30)
        {
            if (other.name == "Point2")
            {
                rigid.AddForce(Vector3.up * 5, ForceMode.Impulse);
            }
        }

        if (cnt >= 48)
        {
            if (other.name == "Finish")
            {
                FinishUI.text = "Finish!!";
            }
        }
    }

     void OnTriggerEnter(Collider other) //�ٸ� ��ü�� �浹���� �� , ohter�� �ٸ� ��ü�� �ǹ�?
     {
         if (other.tag == "Item")
         {
            other.gameObject.SetActive(false);
            cnt++;
            ScoreUI.text = "���� : " + cnt;
            Debug.Log(cnt);
         }
     }
}
