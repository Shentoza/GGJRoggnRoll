#define DEBUG

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public delegate void OnAction();

//Action is a custom  class, which stores a delegate to notify all Object, which registered to it. The signature of the delegate is:
//void FunctionName()
[System.Serializable]
public class Action
{
	//The Name of the Action (e.g. "Jump", "Fire"...)
	public string ActionName;

	//The Keys which trigger the Action Delegate
	public List<KeyCode> Keys;

	OnAction OnActionDel;


	public Action(string InActionName, List<KeyCode> InKeys)
	{
		ActionName = InActionName;
		Keys = InKeys;
	}

	//Adds an Action Method to the Delegate
	public void AddAction(OnAction Action)
	{
		OnActionDel += Action;
	}

	//This Method throws the delegate if one of the given keys is currently pressed
	//@return: whether one of the keys are currently pressed or not
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

//Axis is a custom  class, which stores a delegate to notify all Object, which registered to it. The signature of the delegate is:
//void FunctionName(float ValueParam)
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

	//Adds an Action Method to the Delegate
	public void AddAxis(OnAxis Axis)
	{
		OnAxisDel += Axis;
	}

	//This Method throws the delegate if one of the given keys is currently moved
	//@return: whether one of the keys are currently moved or not
	public bool CheckAxis()
	{
		foreach (string AxisKey in AxisKeys) 
		{
			float AxisValue = Input.GetAxis (AxisKey);
			if (AxisValue <= -0.01f || AxisValue >= 0.01f)
			{
				if (OnAxisDel != null) {
					OnAxisDel (AxisValue);
					Debug.Log (AxisValue);

				}
				return true;
			}
		}

		return false;
	}
}

[Prefab("Prefabs/Singletons/InputMapper", true)]
public class InputMapper : Singleton<InputMapper> {

	public List<Action>	ActionMappings;
	public List<Axis>   AxisMappings;

	public void Hello ()
	{
		Debug.Log ("Hello");
	}

	public void Yo (float Yo)
	{
		Debug.Log ("Yo" + Yo);
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

		Debug.LogWarning("Could not find Action: " + ActionName);
	}

	public void AddAxisMapping(string AxisName, OnAxis Axis)
	{
		foreach (Axis axis in AxisMappings) 
		{
			Debug.Log(axis.AxisName + " " + AxisName);
			if (axis.AxisName == AxisName) 
			{
				Debug.Log ("Added AxisMapping");
				axis.AddAxis (Axis);

				return;
			}
		}

		Debug.LogWarning("Could not find Axis: " + AxisName);
	}
}
