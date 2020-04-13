using UnityEngine;
using static UnityEngine.Mathf;

public class AICrouchState : StateMachineBehaviour
{

	[SerializeField]
	[Range(0.1f, 0.4f)]
	private float wantedDistanceToPlayer = 0.2f;

	private MovementController movementController;
	private Transform player;

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		movementController = animator.GetComponent<MovementController>();
		movementController.SetHorizontalMoveDirection(0);
		movementController.Crouch();

		player = GameObject.FindWithTag("Player").transform;
		float directionToPlayer = player.position.x - animator.transform.position.x;
		movementController.TurnTowards(directionToPlayer);
	}

	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		Vector3 vectorToPlayer = player.position - animator.transform.position;
		float distanceToPlayer = vectorToPlayer.magnitude;

		if (distanceToPlayer < wantedDistanceToPlayer)
		{
			animator.SetTrigger("ShouldCrouchKick");
		}

	}
}
