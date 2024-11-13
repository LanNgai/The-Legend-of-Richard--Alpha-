using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    private Button button;
    public GameObject titleScreen;

    // Start is called before the first frame update
    void Start()
    {
    button = GetComponent<Button>();
        button.onClick.AddListener(GameStart);
        titleScreen.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void GameStart()
    {
        titleScreen.gameObject.SetActive(false);
    }
}
