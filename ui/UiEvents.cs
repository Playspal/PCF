using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

using System;
using System.Collections;

public class UiEvents
{
	public static void AddStartDragListener(GameObject target, Action callback)
	{
		AddEventListener(target, callback, EventTriggerType.BeginDrag);
	}

    public static void AddStopDragListener(GameObject target, Action callback)
	{
		AddEventListener(target, callback, EventTriggerType.EndDrag);
	}

    public static void AddMouseOverListener(GameObject target, Action callback)
	{
		AddEventListener(target, callback, EventTriggerType.PointerEnter);
	}

    public static void AddMouseOutListener(GameObject target, Action callback)
	{
		AddEventListener(target, callback, EventTriggerType.PointerExit);
	}

    public static void AddMousePressListener(GameObject target, Action callback)
	{
		AddEventListener(target, callback, EventTriggerType.PointerDown);

		int i;

		for(i = 0; i < target.transform.childCount; i++)
		{
			AddMousePressListener (target.transform.GetChild(i).gameObject, callback);
		}
	}

    public static void AddMouseReleaseListener(GameObject target, Action callback)
	{
		AddEventListener(target, callback, EventTriggerType.PointerUp);

		int i;
		
		for(i = 0; i < target.transform.childCount; i++)
		{
			AddMouseReleaseListener (target.transform.GetChild(i).gameObject, callback);
		}
	}

    public static void AddClickListener(GameObject target, Action callback)
	{
		AddEventListener(target, callback, EventTriggerType.PointerUp);

		int i;
		
		for(i = 0; i < target.transform.childCount; i++)
		{
			AddClickListener (target.transform.GetChild(i).gameObject, callback);
		}
	}

    private static void AddEventListener(GameObject target, Action callback, EventTriggerType eventID)
	{
		EventTrigger trigger = target.GetComponent<EventTrigger>() != null ? target.GetComponent<EventTrigger>() : target.AddComponent<EventTrigger>();
		EventTrigger.Entry entry = new EventTrigger.Entry();
		entry.eventID = eventID;
		entry.callback.AddListener( (eventData) => { callback(); } );
		trigger.triggers.Add(entry);
	}
}
