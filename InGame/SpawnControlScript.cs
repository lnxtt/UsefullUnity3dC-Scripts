//copyright: creator Marvin Plum github.com/lnxtt
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnControlScript : MonoBehaviour {

	public Vector3[] SpawnPointValues;
	public Vector3[] SpawnPointRanges; 	// as unity can not show 2d arrays in editor jet I use a vector for the range from a point the objets should spawn.
	public Vector3[] SpawnPointRotations; 
	public GameObject[] ObjectsToSpawn;

	public bool spawnOnAllPositons;

	public float SpawnInterval;
	public float StartSpawningAfterTime;

	void Start() {
		InvokeRepeating ("Spawn", StartSpawningAfterTime, SpawnInterval);	// repeats the spawn event by the parameters
	}

	void Spawn() {
		if (spawnOnAllPositons) {
			for (int i = 0; i < SpawnPointValues.Length; i++) {
				CreateSpawnLocation(i);
			}
		} else {
			int r = Random.Range (0, SpawnPointValues.Length);
			CreateSpawnLocation(r);
		}
	}

	void CreateSpawnLocation(int SpawnPointValuesIndex){
		int i = SpawnPointValuesIndex;

		float xpos = Random.Range(SpawnPointValues[i].x - SpawnPointRanges[i].x,SpawnPointValues[i].x + SpawnPointRanges[i].x);	//(e.g.[10,0,0] spawn an object in range of +- 10 of the x value of the spawn-point)
		float ypos = Random.Range(SpawnPointValues[i].y - SpawnPointRanges[i].y,SpawnPointValues[i].y + SpawnPointRanges[i].y);
		float zpos = Random.Range(SpawnPointValues[i].z - SpawnPointRanges[i].z,SpawnPointValues[i].z + SpawnPointRanges[i].z);
		Vector3 SpawnPos = new Vector3(xpos,ypos,zpos);

		SpawnOnLocation(SpawnPos, SpawnPointRotations[i]);
	}

	void SpawnOnLocation(Vector3 SpawnPos, Vector3 SpawnRotation){
		int ObjectIndex = Random.Range (0, ObjectsToSpawn.Length);	// loads a random object from the given array
		Quaternion spawnRotation = Quaternion.Euler(SpawnRotation.x,SpawnRotation.y,SpawnRotation.z);
		Instantiate(ObjectsToSpawn[ObjectIndex], SpawnPos, spawnRotation);
	}
}
