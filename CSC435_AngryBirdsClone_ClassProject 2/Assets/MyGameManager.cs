using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGameManager : MonoBehaviour
{
    public static MyGameManager instance;


    private GameObject _launchPoint;

    public int availableChances = 3;

    public GameObject angryBirdPrefab;

    private GameObject _angryBirdPlayer;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("You are trying to create second instance of game manager");
            //Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _launchPoint = GameObject.Find("LaunchPoint");
    }

    // Update is called once per frame
    void Update()
    {
        // create a new angry bird when there is no bird on scene
        if (_angryBirdPlayer == null && availableChances > 0)
        {
            _angryBirdPlayer = CreateAngryBird();
        }

        if (availableChances <= 0)
        {
            availableChances = 0;
        }
    }

    private GameObject CreateAngryBird()
    {
        GameObject bird = Instantiate(angryBirdPrefab, _launchPoint.transform.position, angryBirdPrefab.transform.rotation);
        return bird;
    }
}
