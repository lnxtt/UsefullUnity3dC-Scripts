//copyright: creator Marvin Plum github.com/lnxtt
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportController : MonoBehaviour {

    int counter = new int();
    Queue XposQ = new Queue();
    Queue YposQ = new Queue();
    Queue ZposQ = new Queue();
    public GameObject Ghost;
	public GameObject portBtn;
	public int ghostSpwanTime = 10; // in seconds
    bool logging = true;
    bool portet = false;

    void Start () {
		ghostSpwanTime = ghostSpwanTime * 100;	// seconds -> miliseconds
		counter = 0;
        InvokeRepeating("SavePos", 0.0f, 0.01f);
    }

    private void SavePos() //Saves the position of the player when he is not portet jet
    {
        if(logging)
        {
			XposQ.Enqueue(transform.position.x);
			YposQ.Enqueue(transform.position.y);
			ZposQ.Enqueue(transform.position.z);

			if (counter < ghostSpwanTime){ // spawns the ghost after given time
                counter++;
            }
            else{
                Ghost.SetActive(true);
                Ghost.transform.position = new Vector3(float.Parse(XposQ.Dequeue().ToString()), float.Parse(YposQ.Dequeue().ToString()), float.Parse(ZposQ.Dequeue().ToString())); //moves the ghost along the players past movement
            }
        }
    }
    public void Port()
    {
		if (counter >= ghostSpwanTime) {
           if (portet == false)
            {
                logging = false; //stops the saving of player coordinates
                transform.position = new Vector3(float.Parse(XposQ.Dequeue().ToString()), float.Parse(YposQ.Dequeue().ToString()), float.Parse(ZposQ.Dequeue().ToString()));  //moves the player to the ghosts current position
                portet = true;
                Ghost.SetActive(false);
				portBtn.SetActive(false);
            }
        }
    }
}

