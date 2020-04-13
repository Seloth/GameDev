using UnityEngine;

public class AICrouchKickState : StateMachineBehaviour
{
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		MovementController movementController = animator.GetComponent<MovementController>();
		movementController.SetHorizontalMoveDirection(0);
	}
}
