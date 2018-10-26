using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SecondGridScript : GridScript {

	string[] gridString = new string[]{
		"----|----}wwwwwwww-|----|-rrr|",
		"--r-|----|---wppww-|----r-r--|",
		"----|w-f-|---rppwppp----|-ff-|",
		"--f-r----|---wpppw-p-f--|--r-|",
		"-rf-|-www|---wwrww-p----|----|",
		"----|w---|---p|ff--ppf--|----|",
		"ff-f|ff--|--wwwwww-fpffw|fff-|",
		"ff---ffffwwwpppppwff-wffffffw|",
		"fffrffff-|wwwwrwwwwwww--|----|",
		"f---fff--|--wrlr---fgppp|-r--|",
		"frffff---|---rllr--|-ffp|p-f-|",
		"-r--|ff--|--rrrllrrr----|p---|",
		"---rrrrrrwwwrllllllrrrrrwrwwrr",
		"rr--|----rrrrlllllrrrrr-|-r--|",
		"---r|--r-|-r-lrrl--r---r|----|",
		"-r--|r--r|---lrrl--|-r--|r-r-|",
		"--r-|----|r---rr---|----|fff-|"
	};

	// Use this for initialization
	void Start () {
		gridWidth = gridString[0].Length;
		gridHeight = gridString.Length;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override float GetMovementCost(GameObject go){
		return base.GetMovementCost(go);
	}
	
	protected override Material GetMaterial(int x, int y){

		char c = gridString[y].ToCharArray()[x];

		Material mat;

		switch(c){
		case 'r': 
			mat = mats[1];
			break;
		case 'w': 
			mat = mats[2];
			break;
		case 'l': 
			mat = mats[3];
			break;
		case 'p': 
			mat = mats[4];
			break;
		case 'f': 
			mat = mats[5];
			break;
		default: 
			mat = mats[0];
			break;
		}
	
		return mat;
	}
}
