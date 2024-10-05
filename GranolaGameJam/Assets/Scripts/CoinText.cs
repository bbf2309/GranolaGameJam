using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinText : MonoBehaviour
{
    public Inventory playerInventory;
    // public PlayerHealth playerHealth;
    public TextMeshProUGUI CounterTxt;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // collectibleText.text = playerInventory.collectibleCount.ToString();

        CounterTxt.text = playerInventory.keyCount.ToString();


    }
}