using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FollowAStarScript2: MonoBehaviour {

	protected bool move = false;

	protected Path path2;
	public AStarScript2 astar2;
	public Step startPos2;
	public Step destPos2;

	protected int currentStep = 1;

	protected float lerpPer = 0;
	
	protected float startTime;
	protected float travelStartTime;

	// Use this for initialization
	protected virtual void Start () {
		path2 = astar2.path2;
		startPos2 = path2.Get(0);
		destPos2  = path2.Get(currentStep);

		transform.position = startPos2.gameObject.transform.position;

//		Debug.Log(path.nodeInspected/100f);

		Invoke("StartMove", path2.nodeInspected/100f);

		startTime = Time.realtimeSinceStartup;
	}
	
	// Update is called once per frame
	protected virtual void Update () {

		if(move){
			lerpPer += Time.deltaTime/destPos2.moveCost;

			transform.position = Vector3.Lerp(startPos2.gameObject.transform.position, 
			                                  destPos2.gameObject.transform.position, 
			                                  lerpPer);

			if(lerpPer >= 1){
				lerpPer = 0;

				currentStep++;

				if(currentStep >= path2.steps){
					currentStep = 0;
					move = false;
					Debug.Log(path2.pathName + " got to the goal in: " + (Time.realtimeSinceStartup - startTime));
					Debug.Log(path2.pathName + " travel time: " + (Time.realtimeSinceStartup - travelStartTime));
				} 

				startPos2 = destPos2;
				destPos2 = path2.Get(currentStep);
			}
		}
	}

	protected virtual void StartMove(){
		move = true;
		travelStartTime = Time.realtimeSinceStartup;
	}
}

