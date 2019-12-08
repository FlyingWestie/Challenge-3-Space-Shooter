using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{
    public GameController coin;
    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boundary") || other.CompareTag("Enemy"))
        {
            return;
        }
        GameObject GameController = GameObject.Find("GameController");
        GameController gameScript = GameController.GetComponent<GameController>();


        if (other.tag == "Player")
        {
            gameScript.score = gameScript.score + 20;
            gameScript.UpdateScore();
            if (explosion != null)
            {
                Instantiate(explosion, transform.position, transform.rotation);
            }
            Destroy(gameObject);
           
        }
    }
}
