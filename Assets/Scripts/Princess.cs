using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Princess : MonoBehaviour
{
    public Animator anim;
    [SerializeField] GameObject text;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Help());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Help()
    {
        while (true)
        {
            anim.SetBool("Scream", true);
            text.SetActive(true);
            yield return new WaitForSeconds(2f);
            text.SetActive(false);
            anim.SetBool("Scream", false);
            yield return new WaitForSeconds(10f);
        }
    }
}
