using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    public Customer customer;
        
    void Update()
    {
        if (customer.complete)
        {
            Invoke("LoadNextScene", 2);
        }
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
