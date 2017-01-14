// Solution Name: Area.Entitia
// Project: Area.Entitia
// File: TimeSystem.cs
// 
// By: Furion
// Last Pinned Datetime: 2017 / 01 / 05 - 0:16

using UnityEngine;
using System.Collections;
using Entitas;

public class TimeSystem : IInitializeSystem, IExecuteSystem {
	#region Fields

	private Context CTX;
	private Group gNewTimeListener;
	private float _nextTime = 0;

	#endregion

	public void Execute() {
		//var newTick = CTX.tick.CurrentTick + 1;
		//CTX.ReplaceTick(newTick);
		if (Time.time >= _nextTime) {
			//CTX.ReplaceSecond(_nextTime);
			_nextTime += 1;
		}
		foreach (var entity in gNewTimeListener.GetEntities()) {
			//entity.timeListener.Notify(newTick);
		}
	}

	public void Initialize() {
		CTX = Contexts.sharedInstance.core;
		//gNewTimeListener = CTX.GetGroup(CoreMatcher.TimeListener);
		//CTX.ReplaceTick(0);
	}
}