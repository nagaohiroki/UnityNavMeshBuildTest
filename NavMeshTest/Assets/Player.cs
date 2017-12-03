using UnityEngine;
using UnityEngine.AI;
public class Player : MonoBehaviour
{
	NavMeshAgent mAgent;
	[SerializeField]
	Nav mNav;
	void Move( float inSpeed )
	{
		if( Input.GetKey( KeyCode.W ) )
		{
			mAgent.Move( Vector3.forward * inSpeed );
		}
		if( Input.GetKey( KeyCode.A ) )
		{
			mAgent.Move( Vector3.left * inSpeed );
		}
		if( Input.GetKey( KeyCode.D ) )
		{
			mAgent.Move( Vector3.right * inSpeed );
		}
		if( Input.GetKey( KeyCode.S ) )
		{
			mAgent.Move( Vector3.back * inSpeed );
		}

	}
	void GenerateAgent()
	{
		if( mNav == null )
		{
			return;
		}
		var go = Instantiate( mNav );
		go.gameObject.SetActive( true );
	}
	void Start()
	{
		mAgent = GetComponent<NavMeshAgent>();
		mAgent.enabled = true;
	}
	void Update()
	{
		Move( 0.2f );
		if( Input.GetKeyDown( KeyCode.Space ) )
		{
			GenerateAgent();
		}
	}
}
