using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] private GameObject pausingMenu;
    // Start is called before the first frame update
    void Start()
    {
        pausingMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pausingMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void Unpause()
    {
        pausingMenu.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
