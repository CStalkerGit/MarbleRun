using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Engine : MonoBehaviour
{
    public Text textCoins;
    public AudioClip sndCoin;

    static Engine instance;
    float coinScale = 1;
    const float maxScale = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        UpdateText();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (coinScale > 1)
        {
            coinScale -= Time.deltaTime * 2.0f;
            if (coinScale < 1) coinScale = 1;
            textCoins.transform.localScale = new Vector3(coinScale, coinScale, 1);
        }
    }

    public static void AddCoin(Vector3 pos)
    {
        Data.Coins++;
        instance.coinScale = maxScale;
        instance.UpdateText();
        AudioSource.PlayClipAtPoint(instance.sndCoin, pos, 1.0f);
    }

    void UpdateText()
    {
        textCoins.text = "Coins: " + Data.Coins.ToString();
    }
}
