using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PageNavigation : MonoBehaviour

{
    public void StartPage()
    {
        SceneManager.LoadScene("StartPage");
    }
    public void HouseLevelMenu()
    {
        SceneManager.LoadScene("HouseLevelMenu");
    }
    public void SchoolLevelMenu()
    {
        SceneManager.LoadScene("SchoolLevelMenu");
    }
    
}
