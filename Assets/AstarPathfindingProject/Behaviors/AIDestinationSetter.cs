using UnityEngine;


namespace Pathfinding
{

    public class AIDestinationSetter : VersionedMonoBehaviour
	{
		/// <summary>The object that the AI should move to</summary>

		public Transform target;
		IAstarAI ai;

		public void Start()
		{
			target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
		}

		void OnEnable () {
			ai = GetComponent<IAstarAI>();
			if (ai != null) ai.onSearchPath += Update;
		}

		void OnDisable () {
			if (ai != null) ai.onSearchPath -= Update;
		}

		void Update () {
			if (target != null && ai != null) ai.destination = target.position;
		}
	}
}
