using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Condition : MonoBehaviour
{
    public GameObject mainmenu;
    public GameObject exit;
    public GameObject again;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadmainmenu()
    {
        
        SceneManager.LoadScene(0);
    }

    public void loadexit()
    {
        
        Application.Quit();
    }

    

    public void loadagain()
    {
        
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

   


}
