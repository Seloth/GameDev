using UnityEngine;

public class AIAttackDeciderState : StateMachineBehaviour {

	[SerializeField]
	[Range(0.1f, 0.4f)]
	private float wantedDistanceToPlayer = 0.4f;
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

		GameObject player = GameObject.FindWithTag("Player");
		Transform playerTransform = player.transform;

		Vector3 vectorToPlayer = playerTransform.position - animator.transform.position;
		float distanceToPlayer = vectorToPlayer.magnitude;

		if (distanceToPlayer > wantedDistanceToPlayer )
		{
			animator.SetTrigger("ShouldMoveToPlayer");
		}
		else
		{
			float rand = Random.value;
			if (rand <= 0.3f) { animator.SetTrigger("ShouldJump"); }
			else if (rand <= 0.6f) { animator.SetTrigger("ShouldMoveToPlayer"); }
			else if (rand <= 1.0f) { animator.SetTrigger("ShouldCrouch"); }
		}
		
	}
}
