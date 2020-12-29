using UnityEngine;
using System.Collections;

public class Driver : MonoBehaviour {

    Vector3 dest;

    void Awake() {
        Vector3 pos = GameObject.Find("node3").transform.position;
        UnityEngine.AI.NavMeshAgent nva = GetComponent<UnityEngine.AI.NavMeshAgent>();
        nva.SetDestination(pos);
        nva.updateRotation = false;
    }
}
