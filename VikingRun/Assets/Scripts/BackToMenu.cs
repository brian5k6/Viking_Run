using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour, IPointerClickHandler
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }
    public void OnPointerClick(PointerEventData e)
    {
        Scene sc = SceneManager.GetActiveScene();
        if (sc.name != "SampleScene")
        {
            SceneManager.LoadScene(0);
        }
    }
}
