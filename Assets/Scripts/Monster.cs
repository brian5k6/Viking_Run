using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Monster : MonoBehaviour
{

    public VikingController vk;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("Run", vk.run);
        if (vk.end)
        {
            StartCoroutine(Move(100));
            StartCoroutine(Back());
            animator.SetBool("End", vk.end);
        }
    }
    IEnumerator Move(float inTime)
    {
        for (var t = 0f; t < 1; t += Time.deltaTime / inTime)
        {
            transform.position = Vector3.Lerp(transform.position, vk.transform.position, t);
            yield return null;
        }
        
    }

    IEnumerator Back()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(0);
    }
}
