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
        if (Input.GetButtonDown("Jump") && !isJump) //isJump가 false면
        {
            isJump = true; //isJump가 true가 되면서 점프를 다시 못하게함 ( 무한점프 방지 )
            rigid.AddForce(new Vector3(0,50,0),ForceMode.Impulse);
        }
    }

    void FixedUpdate()
    {
        float ho = Input.GetAxisRaw("Horizontal"); //오른쪽 왼쪽
        float ve = Input.GetAxisRaw("Vertical"); // 위쪽 아래쪽
        rigid.AddForce(new Vector3(ho, 0,ve), ForceMode.Impulse); //순간적인 힘으로 무게를 적용할 때
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            Debug.Log("Floor에 닿음");
            isJump = false; //바닥에 닿으면 다시 점프가 가능하게 하기 위해서 false로 바꾸면서 다시 점프 가능
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

     void OnTriggerEnter(Collider other) //다른 객체와 충돌했을 때 , ohter이 다른 객체를 의미?
     {
         if (other.tag == "Item")
         {
            other.gameObject.SetActive(false);
            cnt++;
            ScoreUI.text = "점수 : " + cnt;
            Debug.Log(cnt);
         }
     }
}
