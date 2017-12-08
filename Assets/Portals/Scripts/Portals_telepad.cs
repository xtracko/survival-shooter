using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portals_telepad : MonoBehaviour
{
    public Portals_telepad[] destinations;
    public string tags = "|Player|";
    private bool active = true;
    private int cooldown = 0;
	
	// Update is called once per frame
	void Update ()
    {
	    if (!active)
        {
            cooldown++;
        }
        if (cooldown >= 60)
        {
            active = true;
            cooldown = 0;
        }
	}

    public void Deactivate()
    {
        active = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        if(active&&tags.Contains(string.Format("|{0}|", other.tag)))
        {
            int r = Random.Range(0, destinations.Length - 1);
            destinations[r].Deactivate();
            other.transform.position = destinations[r].GetComponent<Collider>().transform.position;
            other.transform.rotation = destinations[r].transform.rotation;
        }
    }
}
