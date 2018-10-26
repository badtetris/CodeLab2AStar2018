using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AStarScript2 : MonoBehaviour {

	public bool check = true;

	public GridScript gridScript;
	public HueristicScript2 hueristic2;

	protected int gridWidth;
	protected int gridHeight;

	GameObject[,] pos;

	//A Star stuff
	protected Vector3 start2;
	protected Vector3 goal2;

	public Path path2;

	protected PriorityQueue<Vector3> frontier;
	protected Dictionary<Vector3, Vector3> cameFrom = new Dictionary<Vector3, Vector3>();
	protected Dictionary<Vector3, float> costSoFar = new Dictionary<Vector3, float>();
	protected Vector3 current;

	List<Vector3> visited = new List<Vector3>();

	// Use this for initialization
	protected virtual void Start () {
		InitAstar();
	}

	protected virtual void InitAstar(){
		InitAstar(new Path(hueristic2.gameObject.name, gridScript));
	}

	protected virtual void InitAstar(Path path2){
		this.path2 = path2;

		start2 = gridScript.start2;
		goal2 = gridScript.goal2;
		
		gridWidth = gridScript.gridWidth;
		gridHeight = gridScript.gridHeight;

		pos = gridScript.GetGrid();

		frontier = new PriorityQueue<Vector3>();
		frontier.Enqueue(start2, 0);

		cameFrom.Add(start2, start2);
		costSoFar.Add(start2, 0);

		int exploredNodes = 0;

		while(frontier.Count != 0){
			exploredNodes++;
			current = frontier.Dequeue();

			visited.Add(current);

			//pos[(int)current.x, (int)current.y].transform.localScale = 
				//Vector3.Scale(pos[(int)current.x, (int)current.y].transform.localScale, new Vector3(.8f, .8f, .8f));

			if(current.Equals(goal2)){
				Debug.Log("2nd GOOOAL!");
				break;
			}
			
			for(int x = -1; x < 2; x+=2){
				AddNodesToFrontier((int)current.x + x, (int)current.y);
			}
			for(int y = -1; y < 2; y+=2){
				AddNodesToFrontier((int)current.x, (int)current.y + y);
			}
		}

		current = goal2;

		LineRenderer line = GetComponent<LineRenderer>();

		int i = 0;
		float score = 0;

		while(!current.Equals(start2)){
			line.positionCount++;
			
			GameObject go = pos[(int)current.x, (int)current.y];
			path2.Insert(0, go, new Vector3((int)current.x, (int)current.y));

			current = cameFrom[current];

			Vector3 vec = Util.clone(go.transform.position);
			vec.z = -1;

			line.SetPosition(i, vec);
			score += gridScript.GetMovementCost(go);
			i++;
		}

		path2.Insert(0, pos[(int)current.x, (int)current.y]);
		path2.nodeInspected = exploredNodes;
		
		Debug.Log(path2.pathName + " Terrian Score: " + score);
		Debug.Log(path2.pathName + " Nodes Checked: " + exploredNodes);
		Debug.Log(path2.pathName + " Total Score: " + (score + exploredNodes));
	}

	void AddNodesToFrontier(int x, int y){
        if (visited.Contains(new Vector3(x, y))) {
            return;
        }
		if(x >=0 && x < gridWidth && 
		   y >=0 && y < gridHeight)
		{
			Vector3 next = new Vector3(x, y);
            float new_cost = costSoFar[current] + gridScript.GetMovementCost(pos[x, y]);
			if(!costSoFar.ContainsKey(next) || new_cost < costSoFar[next])
			{
				costSoFar[next] = new_cost;
				float priority = new_cost + hueristic2.Hueristic(x, y, start2, goal2, gridScript);

				frontier.Enqueue(next, priority);
				cameFrom[next] = current;
			}
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
