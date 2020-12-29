using UnityEngine;
using System.Collections;

public class Motor : MonoBehaviour {

	public float speed = 10;
    public Vector3 dir;

    public bool randomMove = false;

    void Awake() {
        if(randomMove) {
            StartCoroutine(randomDir());
        }
    }

    void Update() {
        GetComponent<Rigidbody>().velocity = speed * dir;
    }

    public void MoveDir(Vector3 _dir) {
        dir = _dir;
        GetComponent<Rigidbody>().velocity = speed * dir.normalized;
    }

    public void MoveTo(Vector3 dest) {
        dir = (dest - GetComponent<Rigidbody>().position).normalized;
        MoveDir(dir);
    }

    public void Stop() {
        dir = new Vector3(0,0,0);
        GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
    }

    IEnumerator randomDir() {
        Random.seed = (int)Time.time;

        while (true)
        {
            MoveTo(new Vector3(30 * (Random.value*2 -1) + GetComponent<Rigidbody>().position.x,
                               0,
                               30 * (Random.value*2 -1) + GetComponent<Rigidbody>().position.z));
            yield return new WaitForSeconds(1);
        }
    }
}
