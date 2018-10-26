using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FirstGridScript : GridScript {

	string[] gridString = new string[]{
		"ww--|-rw-|---f|d-l----pww--",
		"-ww-|-wr-rrrr-|--prrrr--lll",
		"-f--|ppp-r--d-|-pp-r-r--www",
		"-wrr|rr--r-ll-|--l---r--ww-",
		"-wf-|----r---rfwrrlrr--dpw-",
		"-wwfflfww|-www|f---l--dwwl-",
		"-ww-r-f-fwww---|dlllffdllllf-",
		"lrrl|fplffwwlll|lllrfddfppl-",
		"-lf-|dd-www---|-f--dd--f---w",
		"--ddd----w--wff---dd--w-llw",
		"--drd--lfwwww-w--dd-p--f---w",
		"fflllf--|----wwdd--lllllllw",
		"--fll--l-|llll|wff--d---ll-l",
		"----dd---d-www|fff---lllll-l",
		"dd-p|ll-ww----|-fl-fffff---l",
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
			if (Random.value <= .25f) { //give it 75% chances of being type 3 (forest)
				mat = mats[3]; 
			} else {
				mat = mats[5]; //and 25% chance of being type 5(lava)
			}
			break;
		case 'p': 
			mat = mats[4];
			break;
		case 'f': 
			if (Random.value <= .5f) { //wanted to randomize the type so used 50/50 
				mat = mats[5]; //50% chance of being lava
			} else { 
				mat = mats[0]; //50% chance of being grass
			}
			break;
		default: 
			if (Random.value >= .6) { // give if 2/3 chances
				mat = mats [0]; //of being grass
			} else {
				mat = mats [2]; //and if not, it's rock
			}
			break;
		}
	
		return mat;
	}
}
