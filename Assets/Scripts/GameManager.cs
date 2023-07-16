using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject column;
    bool Game_Started = false;
    public GameObject StartPanel;
    void Start()
    {
       
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&&Game_Started==false)
        {
            Time.timeScale = 1;
            StartCoroutine(CreateColumn());
            Game_Started = true;
            StartPanel.SetActive(false);
        }
    }

    IEnumerator  CreateColumn()
    {
        yield return new WaitForSeconds(2);
        GameObject New_Column=Instantiate(column);
        New_Column.transform.position = new Vector3(4, UnityEngine.Random.Range(-2f, 2f), 0);
        StartCoroutine(CreateColumn());

    }
      


    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

}
