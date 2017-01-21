#define DEBUG

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public delegate void OnAction();


[System.Serializable]
public class Action
{
	public string ActionName;
	public List<KeyCode> Keys;

	OnAction OnActionDel;

	public Action(string InActionName, List<KeyCode> InKeys)
	{
		ActionName = InActionName;
		Keys = InKeys;
	}

	public void AddAction(OnAction Action)
	{
		OnActionDel += Action;
	}

	public bool CheckAction()
	{
		foreach (KeyCode Key in Keys) 
		{
			if (Input.GetKeyDown (Key)) 
			{
				if(OnActionDel != null)
					OnActionDel ();

				return true;
			}
		}

		return false;
	}
}

public delegate void OnAxis(float Value);

[System.Serializable]
public class Axis
{
	public string AxisName;
	public List<string> AxisKeys;

	OnAxis OnAxisDel;

	public Axis(string InAxisName, List<string> InAxisKeys)
	{
		AxisName = InAxisName;
		AxisKeys = InAxisKeys;
	}

	public void AddAxis(OnAxis Axis)
	{
		OnAxisDel += Axis;
	}

	public bool CheckAxis()
	{
		foreach (string AxisKey in AxisKeys) 
		{
			float AxisValue = Input.GetAxis (AxisKey);
			if (AxisValue <= -0.01f || AxisValue >= 0.01f)
			{
				if (OnAxisDel != null) {
					OnAxisDel (AxisValue);
					//Debug.Log (AxisValue);

				}
				return true;
			}
		}

		return false;
	}
}

public class InputMapper : MonoBehaviour {

	public List<Action>	ActionMappings;
	public List<Axis>   AxisMappings;

	public void Hello ()
	{
		Debug.Log ("Hello");
	}

	public void Yo (float Yo)
	{
		//Debug.Log ("Yo" + Yo);
	}

	// Use this for initialization
	void Start () {
		#if DEBUG
			AddActionMapping ("Jump", Hello);
			AddAxisMapping ("LeftRight", Yo);
		#endif
	}
	
	// Update is called once per frame
	void Update () {
		foreach(Action action in ActionMappings)
		{
			action.CheckAction ();
		}

		foreach(Axis axis in AxisMappings)
		{
			axis.CheckAxis ();
		}
	}

	public void AddActionMapping(string ActionName, OnAction Action)
	{
		foreach (Action action in ActionMappings) 
		{
			if (action.ActionName == ActionName) 
			{
				action.AddAction (Action);

				return;
			}
		}
	}

	public void AddAxisMapping(string AxisName, OnAxis Axis)
	{
		foreach (Axis axis in AxisMappings) 
		{
			//Debug.Log(axis.AxisName + " " + AxisName);
			if (axis.AxisName == AxisName) 
			{
				//Debug.Log ("Added AxisMapping");
				axis.AddAxis (Axis);

				return;
			}
		}
	}
}
