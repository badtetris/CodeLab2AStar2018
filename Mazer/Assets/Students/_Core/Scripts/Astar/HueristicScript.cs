using UnityEngine;
using System.Collections;

public class HueristicScript : MonoBehaviour {
		


	public virtual float Hueristic(int x, int y, Vector3 start, Vector3 goal, GridScript gridScript){
        return Mathf.Abs(start.x-goal.x) + Mathf.Abs(start.y-goal.y); 
    } 
}
