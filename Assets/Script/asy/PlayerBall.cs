using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class PlayerBall : MonoBehaviour
{
    Rigidbody rigid;
    public int cnt;
    bool isJump;
    public float time;
    public List<int> itemsList = new List<int>();


    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        cnt = 0;
        isJump = false;
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && !isJump) //isJump가 true면
        {
            isJump = true;
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
        if(collision.gameObject.name == "Floor")
        {
            Debug.Log("Floor에 닿음");
            isJump = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.name == "Point")
        {
            rigid.AddForce(Vector3.up * 5, ForceMode.Impulse);
        }

        if(other.name == "Cube")
        {
            rigid.AddForce(Vector3.up * 2, ForceMode.Impulse);
            time += Time.deltaTime;
            Debug.Log(time);
            if(time > 5.0f)
            {
                other.gameObject.SetActive(false);
            }
        }
    }

     void OnTriggerEnter(Collider other) //다른 객체와 충돌했을 때 , ohter이 다른 객체를 의미?
     {
         if (other.tag == "Item")
         {
            other.gameObject.SetActive(false);
            itemsList.Add(cnt++);
            Debug.Log(itemsList.Count);
         }
     }
}
