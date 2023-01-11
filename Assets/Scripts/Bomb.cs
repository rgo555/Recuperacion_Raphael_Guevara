using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private Animator animBomb;
   
    private void Awake() 
    {
        animBomb = GetComponent<Animator>();
    }
    public void BombExplosion()
    {
        animBomb.SetBool("Explosion", true);
        GameManager.Instance.VidasCounter();
    }

    public void BOOM()
    {
        Destroy(this.gameObject);
    }
   
}
