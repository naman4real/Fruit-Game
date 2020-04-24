using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
    private MenuAnimatorFunctions animatorFunctions;
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

                animator.SetBool("selected", true);
                if (Input.GetMouseButtonDown(0))
                {
                    animator.SetBool("ButtonPressed", true);

                    Debug.Log("pressed");
                    //StartCoroutine(startScene(menuButtonController.index));
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
            animator.SetBool("selected", false);

        }

        if (animator.GetBool("pressed"))
        {
            animator.SetBool("pressed", false);
            animatorFunctions.disableOnce = true;
        }

        if (animator && animator.GetBool("ButtonPressed"))
        {
            Debug.Log("close");
            animator.SetBool("ButtonPressed", false);
            animatorFunctions.disableOnce = true;
        }
    }
}