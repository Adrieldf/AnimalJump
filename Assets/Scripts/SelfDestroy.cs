using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
   [SerializeField]
   private float TimeToDestroy = 5f;

   private void Start() {
       Destroy(gameObject, TimeToDestroy);
   }
}
