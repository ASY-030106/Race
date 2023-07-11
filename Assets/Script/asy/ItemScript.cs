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
