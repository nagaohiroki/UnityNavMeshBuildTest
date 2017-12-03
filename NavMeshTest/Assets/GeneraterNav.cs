using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public static class NavMeshGenerator
{
	public static void Generate()
	{
		var sources = new List<NavMeshBuildSource>();
		var meshs = Object.FindObjectsOfType<MeshFilter>();
		foreach( var mesh in meshs )
		{
			if( !mesh.gameObject.isStatic )
			{
				continue;
			}
			var source = new NavMeshBuildSource();
			source.sourceObject = mesh.sharedMesh;
			source.area = 0;
			source.transform = mesh.transform.localToWorldMatrix;
			sources.Add( source );
		}
		var navMeshData = new NavMeshData();
		NavMesh.AddNavMeshData( navMeshData );
		var id = NavMesh.GetSettingsByID( 0 );
		var bounds = new Bounds( Vector3.zero, Vector3.one * 50.0f );
		bool result = NavMeshBuilder.UpdateNavMeshData( navMeshData, id, sources, bounds );
		Debug.Log( result );
		Debug.Log( id.agentRadius );
	}
}
public class GeneraterNav : MonoBehaviour
{
	void Awake()
	{
		NavMeshGenerator.Generate();
	}
}
