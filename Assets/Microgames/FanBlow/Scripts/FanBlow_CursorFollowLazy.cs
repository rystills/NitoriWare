using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FanBlow_CursorFollowLazy : MonoBehaviour {
	//list of previous angles between fan and mouse; treated as a queue with faster access
	List<Quaternion> angleHistory = new List<Quaternion>(new Quaternion[10]);
	//average of angle history
	Quaternion averageAngle;

	/** 
	 * recalculate the average Quaternion rotation from our current angle history
	 * logic from https://forum.unity.com/threads/average-quaternions.86898/#post-3153548 
	 */
	void recalcuateAverageAngle() {
		averageAngle = angleHistory[0];
		float weight;
		for (int i = 1; i < angleHistory.Count; ++i) {
			weight = 1.0f / (float)(i + 1);
			averageAngle = Quaternion.Slerp(averageAngle, angleHistory[i], weight);
		}
	}

	void Update() {
		//push the new angle difference between me and the cursor to our history
		Vector3 cursorPosition = CameraHelper.getCursorPosition();
		cursorPosition.z = transform.position.z;
		//Quaternion newAngle = Quaternion.FromToRotation(-cus.transform.parent.forward, transform.parent.forward);

	}
}
