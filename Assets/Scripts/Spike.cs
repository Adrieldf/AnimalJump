using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;
        Debug.Log("spike hit");
        //spawnar particula
        GameObject player = other.gameObject;
        player.GetComponent<Rigidbody2D>().AddForce((transform.position - player.transform.position) * -500);
    }
}
