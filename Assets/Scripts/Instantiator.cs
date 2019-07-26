using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiator : MonoBehaviour
{
    public static Instantiator Instance;
    public void Awake() => Instance = this;

    private void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("trigger instantiator");
        LevelGenerator.Instance.spawnChunk();
        Destroy(gameObject, 0.3f);
    }

}
