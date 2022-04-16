using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KongLadder : MonoBehaviour
{
    bool coroutine = false;
    [SerializeField] GameObject pricess;
    [SerializeField] GameObject KongJump;
    bool ok = false;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < 2.06f){
            transform.position += new Vector3(0, 1.2f, 0) * Time.deltaTime;
        }
        else{
            anim.enabled = false;
            if(transform.position.y < 3.58f){
                if(coroutine==false)
                    StartCoroutine(jump());
                else{
                    if(ok == true){
                        transform.position += new Vector3(0, 1.5f, 0) * Time.deltaTime;
                    }
                }
            }
            else{
                pricess.SetActive(true);
                Instantiate(KongJump, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }

    IEnumerator jump(){
        coroutine = true;
        yield return new WaitForSeconds(0.4f);
        ok = true;
    }
}

