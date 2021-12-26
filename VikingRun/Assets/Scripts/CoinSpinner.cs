using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpinner : MonoBehaviour
{

    bool rotating = false;
    MeshRenderer mr;
    public VikingController vk;

    // Start is called before the first frame update
    void Start()
    {
        mr = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!rotating)
        {
            rotating = true;
            StartCoroutine(RotateMe(Vector3.up * 90, 0.5f));
        }
    }

    IEnumerator RotateMe(Vector3 byAngles, float inTime)
    {
        var fromAngle = transform.rotation;
        var toAngle = Quaternion.Euler(transform.eulerAngles + byAngles);
        for (var t = 0f; t < 1; t += Time.deltaTime / inTime)
        {
            transform.rotation = Quaternion.Slerp(fromAngle, toAngle, t);
            yield return null;
        }
        rotating = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(Invisible());
        vk.score += 1;
    }

    IEnumerator Invisible()
    {
        mr.enabled = false;
        yield return new WaitForSeconds(5);
        mr.enabled = true;
    }
}
