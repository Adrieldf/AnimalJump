using UnityEngine;

public class Coin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + 0.75f, transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("coin collected");
        //spawnar particula
        Destroy(gameObject);
        GameMasterController.Instance.AddCoins();
    }

}
