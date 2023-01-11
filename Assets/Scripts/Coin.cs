using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnColliderEnter2D(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            GameManager.Instance.ContadorMonedas();
        }
    }
}
