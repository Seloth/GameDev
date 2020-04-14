using UnityEngine;
using static Controlls;
using static StateMachineUtil;

public class MonkCrouchState : StateMachineBehaviour
{

	private MovementController movementController;

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		movementController = animator.GetComponent<MovementController>();
		movementController.Crouch();
		animator.SetBool("IsCrouching", true);
		animator.SetBool("IsInvincible", true);
	}

	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		movementController.Velocity.Set(0, 0);
		if (Input.GetKey(crouchKey))
		{
			animator.SetBool("IsCrouching", true);
		}
		else
		{
			animator.SetBool("IsCrouching", false);
		}

		if (Input.GetKeyDown(attackKey))
		{
			animator.SetTrigger("IsCrouchKicking");
		}
	}

	public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		animator.SetBool("IsInvincible", false);
	}

}
