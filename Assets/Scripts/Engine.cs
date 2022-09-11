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

    SortedList<float, Transform> checkpoints = new SortedList<float, Transform>();

    public Engine()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
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

    public static void AddCheckpoint(Transform checkpoint)
    {
        instance.checkpoints.Add(checkpoint.position.x, checkpoint);
    }

    public static void UpdateRespawnPoint(Vector3 playerPos, ref Transform lastCheckpoint)
    {
        if (instance.checkpoints.Count == 0) return;

        if (playerPos.x > instance.checkpoints.Keys[0] || lastCheckpoint == null)
        {
            lastCheckpoint = instance.checkpoints.Values[0];
            instance.checkpoints.RemoveAt(0);
        }
    }

    void UpdateText()
    {
        textCoins.text = "Coins: " + Data.Coins.ToString();
    }

    public void Restart()
    {
        Data.Restart();
    }
}
