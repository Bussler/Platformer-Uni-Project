using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlattformBehaviour : MonoBehaviour {

    public float timeBeforeDownFall;
    public float fallDownSpeed;
    public float whenToDestroy;
    private bool playerentered = false;
    private Vector3 originalPosition;

    private void Start()
    {
        originalPosition = transform.position;
    }

    private void Update()
    {
        if (playerentered == true)
        {
            transform.Translate(Vector3.down * fallDownSpeed * Time.deltaTime);
            if (transform.position.y<whenToDestroy)
            {
                gameObject.GetComponent<MeshRenderer>().enabled = false;
                StartCoroutine(reSpawn());
            }
        }
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            StartCoroutine(fallDown());
        }
    }

    IEnumerator fallDown()
    {
        yield return new WaitForSeconds(timeBeforeDownFall);
        playerentered = true;
    }

    IEnumerator reSpawn()
    {
        yield return new WaitForSeconds(2);
        playerentered = false;
        transform.position = originalPosition;
        gameObject.GetComponent<MeshRenderer>().enabled = true;
    }
}
