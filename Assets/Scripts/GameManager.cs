using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject mario;
    private static GameManager instance;
    public bool play = true;
    public bool restart = false;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public static GameManager Instance()
    {
        return instance; 
    }

    private IEnumerator DeleteBarrel()
    {
        restart = true;
        play = false;
        yield return new WaitForSeconds(2f);
        restart = false;
        play = true;
    }

    public void Restart()
    {
        StartCoroutine(DeleteBarrel());
    }

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
