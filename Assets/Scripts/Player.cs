using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MoveObject
{
    public string endLevel = "Level10";
    private string _level;

    public override void Start()
    {
        base.Start();
        _level = SceneManager.GetActiveScene().name;
    }
    public override void FixedUpdate() 
    {
        base.FixedUpdate();
        if(Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
        if (!Input.GetKey(KeyCode.Q)) return;
        if (_level == endLevel)
        {
            SceneManager.LoadScene("MainMenu");
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
        }
    }
    public override void OnTriggerEnter(Collider other) {
        base.OnTriggerEnter(other);
        if (!other.CompareTag("Finish")) return;
        if (_level == endLevel)
        {
            SceneManager.LoadScene("MainMenu");
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
        }
    }
}
