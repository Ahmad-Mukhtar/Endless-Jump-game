using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class gampplaycontroller : MonoBehaviour
{

    public static gampplaycontroller instance;

    [SerializeField]
    private GameObject platform;

    private float Distance_Between_platforms = 4f;
    private int countPlatforms;
    private float lastplatformpositionY;

    void Awake()
    {
        MakeSingelton();
        createPlatform();
    }

    void OnDisable()
    {

        instance = null;
    }
    private void MakeSingelton()
    {
        if (instance == null)
            instance = this;
    }
    public void createPlatform()
    {
        lastplatformpositionY += Distance_Between_platforms;
        GameObject newplatform = Instantiate(platform);
        newplatform.transform.position = new Vector3(0, lastplatformpositionY, 0);
        newplatform.name = "Platform" + countPlatforms;
        countPlatforms++;

    }


    public void PlayAgain()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}
