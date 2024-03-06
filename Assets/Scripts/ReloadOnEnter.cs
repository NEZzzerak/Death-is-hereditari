using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadOnEnter : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
    }
  
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&& playerHealth.value<=0 )
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }

}
