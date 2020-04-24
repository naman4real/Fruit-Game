using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputButton : MonoBehaviour
{
	[SerializeField] inputMenuButtonController inputMenuButtonController;
	[SerializeField] Animator animator;
	[SerializeField] InputAnimatorFunctions animatorFunctions;
	[SerializeField] int thisIndex;
	[SerializeField] Animator MenuAnimator;


	// Update is called once per frame
	public void Update()
	{
		if (inputMenuButtonController.index == thisIndex)
		{
			animator.SetBool("selected", true);

			if (Input.GetAxis("Submit") == 1)
			{
				animator.SetBool("pressed", true);
				StartCoroutine(startScene(inputMenuButtonController.index));

			}
			else if (animator.GetBool("pressed"))
			{
				animator.SetBool("pressed", false);
				animatorFunctions.disableOnce = true;
			}
		}
		else
		{
			animator.SetBool("selected", false);
		}
	}

	IEnumerator startScene(int index)
	{
		yield return new WaitForSeconds(0.5f);
		if (index == 0)
		{
			//SceneManager.LoadScene("FruitWorld");
			MenuAnimator.SetBool("goToStartMenu",true);
			MenuAnimator.SetBool("goToInputMenu", false);

			var go = GameObject.Find("Buttons");
			go.GetComponent<MenuButtonController>().enabled = true;
			gameObject.transform.parent.GetComponent<inputMenuButtonController>().enabled = false;

		}
		else if (index == 1)
		{
			SceneManager.LoadScene("FruitWorld");
			//MenuAnimator.SetTrigger("goToStartMenu");

		}
	}

	//public void hoverButton()
	//{
	//	Debug.Log("hover");
	//	animator.SetBool("selected", true);
	//}

	public void hover()
	{
		Debug.Log("hover");
		animator.SetBool("selected", true);
	}

	public void OnMouseExit()
	{
		animator.SetBool("selected", false);
	}


}
