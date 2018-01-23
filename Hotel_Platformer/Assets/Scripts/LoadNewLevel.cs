using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewLevel : MonoBehaviour
{
    public string LevelName;
    public int level;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")//collision with the player
        {
            Debug.Log("trigger");
            SceneManager.LoadScene("LevelName");
            SceneManager.LoadScene(level);
        }
    }
}
