using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerBall : MonoBehaviour
{
    Rigidbody rigid;
    public int cnt;
    bool isJump;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        cnt = 0;
        isJump = false;
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && !isJump) //isJump�� true��
        {
            isJump = true;
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
        if(collision.gameObject.name == "Floor")
        {
            Debug.Log("Floor�� ����");
            isJump = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
            if (other.name == "Point")
            {
                rigid.AddForce(Vector3.up * 5, ForceMode.Impulse);
            }
    }

    void OnTriggerEnter(Collider other) //�ٸ� ��ü�� �浹���� �� , ohter�� �ٸ� ��ü�� �ǹ�?
    {
        if (other.tag == "Item")
        {
            PlayerBall player = GetComponent<PlayerBall>();
            player.cnt++;
            other.gameObject.SetActive(false);
        }
    }
}
