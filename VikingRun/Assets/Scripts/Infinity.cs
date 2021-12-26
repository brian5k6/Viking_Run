using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infinity : MonoBehaviour
{

    public VikingController vk;
    
    private void OnTriggerEnter(Collider other)
    {
        int a = Random.Range(0, 4);
        float deviation = 0f;
        switch (vk.map)
        {
            case 0:
                deviation = vk.transform.position.x - 0;
                break;
            case 1:
                deviation = 159.8f - vk.transform.position.z;
                break;
            case 2:
                deviation = vk.transform.position.z - 160.3f;
                break;
            case 3:
                if (vk.MovingDirection == Vector3.left)
                {
                    deviation = vk.transform.position.z + 161.2002f;
                }
                else if (vk.MovingDirection == Vector3.right)
                {
                    deviation = -161.2002f - vk.transform.position.z;
                }
                break;
        }
        if (other.transform.name == "viking")
        {
            vk.hole_1 = (Random.value > 0.5f);vk.hole_2 = (Random.value > 0.5f);vk.hole_3 = (Random.value > 0.5f);vk.hole_4 = (Random.value > 0.5f);
            switch (a)
            {
                case 0:
                    other.transform.position = new Vector3(0 + deviation, other.transform.position.y, 40.7f);
                    vk.MovingDirection = new Vector3(0, 0, 1);
                    vk.transform.rotation = Quaternion.Euler(0, 0, 0);
                    vk.map = 0;
                    vk.hole1.SetActive(vk.hole_1); vk.hole2.SetActive(vk.hole_2); vk.hole3.SetActive(vk.hole_3); vk.hole4.SetActive(vk.hole_4);
                    break;
                case 1:
                    other.transform.position = new Vector3(300 + deviation, other.transform.position.y, 40.7f);
                    vk.MovingDirection = new Vector3(0, 0, 1);
                    vk.transform.rotation = Quaternion.Euler(0, 0, 0);
                    vk.map = 1;
                    vk.hole5.SetActive(vk.hole_1); vk.hole6.SetActive(vk.hole_2); vk.hole7.SetActive(vk.hole_3); vk.hole8.SetActive(vk.hole_4);
                    break;
                case 2:
                    other.transform.position = new Vector3(deviation - 300, other.transform.position.y, 41.2f);
                    vk.MovingDirection = new Vector3(0, 0, 1);
                    vk.transform.rotation = Quaternion.Euler(0, 0, 0);
                    vk.map = 2;
                    vk.hole9.SetActive(vk.hole_1); vk.hole10.SetActive(vk.hole_2); vk.hole11.SetActive(vk.hole_3); vk.hole12.SetActive(vk.hole_4);
                    break;
                case 3:
                    other.transform.position = new Vector3(0 - deviation, other.transform.position.y, -42.10009f);
                    vk.MovingDirection = new Vector3(0, 0, -1);
                    vk.transform.rotation = Quaternion.Euler(0, 180, 0);
                    vk.map = 3;
                    vk.hole13.SetActive(vk.hole_1); vk.hole14.SetActive(vk.hole_2); vk.hole15.SetActive(vk.hole_3); vk.hole16.SetActive(vk.hole_4);
                    break;
            }
        }
    }
}
