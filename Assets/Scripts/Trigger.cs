using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Trigger : MonoBehaviour {

	[SerializeField] private string[] objectTag;
	[SerializeField] private UnityEvent[] objectEvent;

	void OnTriggerEnter2D(Collider2D collider)
    {
        for (int i = 0; i < objectTag.Length; i++)
        {
            if (collider.tag == objectTag[i])
            {
                objectEvent[i].Invoke();
            }
        }
    }
}
