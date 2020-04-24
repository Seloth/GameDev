using UnityEngine;

public class AIDeciderState : StateMachineBehaviour {

	[SerializeField]
	[Range(0.1f, 0.4f)]
	private float blockDistanceToPlayer = 0.2f;
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

		GameObject player = GameObject.FindWithTag("Player");
		Animator playerAnimator = player.GetComponent<Animator>();
		Transform playerTransform = player.transform;

		Vector3 vectorToPlayer = playerTransform.position - animator.transform.position;
		float distanceToPlayer = vectorToPlayer.magnitude;

		if (distanceToPlayer < blockDistanceToPlayer /*&& playerAnimator.GetBool("IsPunching")*/)
		{
			animator.SetTrigger("ShouldCrouch");
		}
		else
		{
			float rand = Random.value;
			if (rand <= 0.2f) { animator.SetBool("ShouldRetreat", true); }
			else if (rand <= 0.4f) { animator.SetTrigger("ShouldWait"); }
			else if (rand <= 1.0f) { animator.SetTrigger("ShouldAttack"); }
		}
	}
}
