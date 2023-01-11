using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public void ReplayButton()
    {
        GameManager.Instance.LoadPlayScene();
    }
}
