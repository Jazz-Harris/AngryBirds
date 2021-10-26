using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public TextMeshProUGUI chancesText;

    public Slider piggyCastleHealthMeter;

    private GameObject[] piggiesArray;

    public int totalPigsInScene;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        totalPigsInScene = ExtractPigsCountInScene();

        // nset the maximum value of piggies count to the slider
        piggyCastleHealthMeter.maxValue = totalPigsInScene;


    }

    // Update is called once per frame
    void Update()
    {
        chancesText.text = "Chances Left: " + MyGameManager.instance.availableChances;

        piggyCastleHealthMeter.value = totalPigsInScene;
    }


    private int ExtractPigsCountInScene()
    {
        piggiesArray = GameObject.FindGameObjectsWithTag("Piggy");
        return piggiesArray.Length;
    }
}
