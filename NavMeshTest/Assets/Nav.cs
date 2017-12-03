using UnityEngine;
using UnityEngine.AI;

public class Nav : MonoBehaviour
{
	[SerializeField]
	GameObject mTarget;
	[SerializeField]
	NavMeshAgent mAgent;
	void Start()
	{
		mAgent.enabled = true;
	}
	void Update()
	{
		mAgent.SetDestination(mTarget.transform.position);
	}
}
