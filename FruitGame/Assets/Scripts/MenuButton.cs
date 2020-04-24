using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
	[SerializeField] MenuButtonController menuButtonController;
	[SerializeField] Animator animator;
	[SerializeField] MenuAnimatorFunctions animatorFunctions;
	[SerializeField] int thisIndex;
	[SerializeField] Animator MenuAnimator;

	// Update is called once per frame
	private void Start()
	{
		//GameObject.Find("InputFields").GetComponent<inputMenuButtonController>().enabled = false;
	}
	public void Update()
    {
		//if (menuButtonController.index == thisIndex)
		//{
		//	animator.SetBool("selected", true);

		//	if (Input.GetAxis("Submit") == 1)
		//	{
		//		animator.SetBool("pressed", true);
		//		StartCoroutine(startScene(menuButtonController.index));

		//	}
		//	else if (animator.GetBool("pressed"))
		//	{
		//		animator.SetBool("pressed", false);
		//		animatorFunctions.disableOnce = true;
		//	}
		//}
		//else
		//{
		//	animator.SetBool("selected", false);
		//}

		if (animator.GetBool("pressed"))
		{
			animator.SetBool("pressed", false);
			animatorFunctions.disableOnce = true;
		}

		if (Input.GetMouseButtonDown(0) && animator.GetBool("selected"))
		{
			animator.SetBool("pressed", true);
			StartCoroutine(startScene(menuButtonController.index));
		}
	}



	public void mouseHover()
	{
		animator.SetBool("selected", true);
	}

	public void mouseExit()
	{
		animator.SetBool("selected", false);
	}

	IEnumerator startScene(int index)
	{
		yield return new WaitForSeconds(0.5f);
		if (index == 0 || index == 1)
		{
			//SceneManager.LoadScene("FruitWorld");
			MenuAnimator.SetBool("goToInputMenu", true);
			MenuAnimator.SetBool("goToStartMenu", false);


			var go = GameObject.Find("InputFields");
			go.GetComponent<inputMenuButtonController>().enabled = true;
			gameObject.transform.parent.GetComponent<MenuButtonController>().enabled = false;

		}
	}


}
