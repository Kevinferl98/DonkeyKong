using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject mario;
    private static GameManager instance;
    [SerializeField] GameObject hammer; 
    public bool play;
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
        //yield return new WaitForSeconds(2f);
        yield return new WaitForSeconds(0.5f);
        hammer.SetActive(true);
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
        StartCoroutine(Intro());
    }

    private IEnumerator Intro()
    {
        play = false;
        Debug.Log("Valore di play: " + play);
        MenuManager.Instance().OpenIntro();
        AudioManager.Instance().PlayIntro();
        yield return new WaitForSeconds(3f);
        MenuManager.Instance().CloseIntro();
        AudioManager.Instance().PlayBackground();
        play = true;
        Debug.Log("Valore di play: " + play);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
