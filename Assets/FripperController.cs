﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour {

    private HingeJoint myHingeJoint;

    private float defaultAngle = 20f;
    private float flickAngle = -20f;

    private int center = Screen.width / 2;

    // Use this for initialization
    void Start () {
        this.myHingeJoint = GetComponent<HingeJoint>();
        SetAngle(this.defaultAngle);
	}
	
	// Update is called once per frame
	void Update () {

        foreach (Touch touch in Input.touches)
        {
            bool touchOnTheLeftSide = touch.position.x < center && tag == "LeftFripperTag";
            bool touchOnTheRightSide = touch.position.x >= center && tag == "RightFripperTag";

            if (touchOnTheLeftSide || touchOnTheRightSide)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    SetAngle(this.flickAngle);
                }
                if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Moved)
                {
                    SetAngle(this.defaultAngle);
                }
            }

        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            SetAngle(this.flickAngle);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngle(this.flickAngle);
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            SetAngle(this.defaultAngle);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngle(this.defaultAngle);
        }
		
	}

    public void SetAngle(float angle) {
        JointSpring jointSpring = this.myHingeJoint.spring;
        jointSpring.targetPosition = angle;
        this.myHingeJoint.spring = jointSpring;
    }
}
