using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

//[System.Serializable]
//public class animationParamaters{
//     public List<Animator> allAnimators;
//     public List<MenuAnimatorFunctions> allAnimatorFunctions;

//}

public class testing : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
    private Animator animator;
    private Animator lastAnimator;
    private MenuAnimatorFunctions animatorFunctions;
    public static AudioSource audio;
    [SerializeField] Animator MenuAnimator;


    private void Start()
    {
        lastAnimator = null;
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //RaycastHit hit;
        if (Physics.Raycast(ray, out hit,Mathf.Infinity))
        {
            //print(hit.collider.name);
            if (hit.collider.tag=="button")
            {
                //Debug.Log("selected");
                animator = hit.collider.gameObject.GetComponent<Animator>();
                animatorFunctions = hit.collider.gameObject.GetComponent<MenuAnimatorFunctions>();
                if (lastAnimator && lastAnimator != animator)
                {
                    lastAnimator.SetBool("selected", false);
                }
                lastAnimator = animator;


                animator.SetBool("selected", true);
                if (Input.GetMouseButtonDown(0))
                {
                    animator.SetBool("pressedButton", true);
                    animator.SetTrigger("pressed");
                    


                    Debug.Log("pressed "+animatorFunctions.index);
                    if(animatorFunctions.index==0 || animatorFunctions.index == 1)
                    {
                        StartCoroutine(toInputsMenu());
                    }
                    else if(animatorFunctions.index>=3 && animatorFunctions.index <= 8)
                    {
                        StartCoroutine(increment());
                    }
                    else if(animatorFunctions.index == 9)
                    {
                        StartCoroutine(backToStartenu());
                    }
                    else if (animatorFunctions.index == 10)
                    {
                        StartCoroutine(startGame());
                    }
                    else
                    {
                        Debug.Log("Quit Game");
                        //StartCoroutine(quit());                     
                    }
                }
            }
            else
            {
                //Debug.Log("not selected");
                animator.SetBool("selected", false);

            }
        }
        else
        {
            //Debug.Log("not selected");
            if (animator)
            {
                animator.SetBool("selected", false);

            }
        }

        if (animator && animator.GetBool("pressedButton"))
        {
            animator.SetBool("pressedButton", false);
            animatorFunctions.disableOnce = true;
        }
    }

    IEnumerator toInputsMenu()
    {
        audio.PlayOneShot(audio.clip);
        yield return new WaitForSeconds(0.1f);
        //MenuAnimator.SetBool("goToInputMenu", true);
        //MenuAnimator.SetBool("goToStartMenu", false);
        MenuAnimator.SetTrigger("toInputMenu");
    }
    IEnumerator startGame()
    {
        audio.PlayOneShot(audio.clip);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("FruitWorld");
    }
    IEnumerator backToStartenu()
    {
        audio.PlayOneShot(audio.clip);
        yield return new WaitForSeconds(0.1f);
        //SceneManager.LoadScene("FruitWorld");

        //MenuAnimator.SetBool("goToInputMenu", false);
        //MenuAnimator.SetBool("goToStartMenu", true);

        MenuAnimator.SetTrigger("toStartMenu");

    }
    IEnumerator increment()
    {
        yield return new WaitForSeconds(0);
    }
    IEnumerator quit()
    {
        audio.PlayOneShot(audio.clip);
        yield return new WaitForSeconds(0.1f);
        Application.Quit();
    }
}