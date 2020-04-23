using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
	[SerializeField] MenuButtonController menuButtonController;
	[SerializeField] Animator animator;
	[SerializeField] AnimatorFunctions animatorFunctions;
	[SerializeField] int thisIndex;
	[SerializeField] Animator MenuAnimator;
	public static bool enterPressed = false;

    // Update is called once per frame
    public void Update()
    {
		if(menuButtonController.index == thisIndex)
		{
			animator.SetBool ("selected", true);
			
			if(Input.GetAxis ("Submit") == 1)
			{
				enterPressed = true;
				animator.SetBool ("pressed", true);
				StartCoroutine(startScene(menuButtonController.index));
			
			}
			else if (animator.GetBool ("pressed"))
			{
				animator.SetBool ("pressed", false);
				animatorFunctions.disableOnce = true;
			}
		}
		else
		{
			animator.SetBool ("selected", false);
		}
    }

	IEnumerator startScene(int index)
	{
		yield return new WaitForSeconds(0.5f);
		if (index == 0 || index==1)
		{
			//SceneManager.LoadScene("FruitWorld");
			MenuAnimator.SetTrigger("goToInputsMenu");

		}
		yield return new WaitForSeconds(1);
		enterPressed = false;

	}

	
}
