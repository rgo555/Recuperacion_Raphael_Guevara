using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField]Text monedasText;
    public float monedasCount;

    [SerializeField]Text vidasText;
    public float vidasCount;

    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        DontDestroyOnLoad(this);
        monedasCount = 0;
        vidasCount = 3;

    }

    // Update is called once per frame
    public void ContadorMonedas()
    {
        monedasText = GameObject.Find("CoinCounter").GetComponent<Text>();
        monedasCount ++;
        Debug.Log(monedasCount);
        monedasText.text = monedasCount.ToString();
    }

    public void VidasCounter()
    {
        vidasText = GameObject.Find("Vidas_Counter").GetComponent<Text>();
        vidasCount --;

        vidasText.text = vidasCount.ToString();
        if(vidasCount == 0)
        {
            SceneManager.LoadScene(2);
        }
    }
    
    public void LoadWinScene()
    {
        SceneManager.LoadScene(0);
    }
    public void LoadLoseScene()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadPlayScene()
    {
        SceneManager.LoadScene(1);
        monedasCount = 0;
        vidasCount = 3;
    }
}
