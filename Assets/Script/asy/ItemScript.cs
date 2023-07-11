using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.down * 17 * Time.deltaTime, Space.World);
    }

    void OnTriggerEnter(Collider other) //다른 객체와 충돌했을 때 , ohter이 다른 객체를 의미?
    {
        if (other.tag == "Item")
        {
            PlayerBall player = GetComponent<PlayerBall>();
            player.cnt++;
            other.gameObject.SetActive(false);
        }
    }
}
