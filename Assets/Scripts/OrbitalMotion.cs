using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitalMotion : MonoBehaviour {

    public Transform objectInOrbit;
    public Ellipse orbitPath;
    [Range (0f,1f)]
    public float currentPeriod = 0f;
    public float orbitPeriod = 3f;
    public bool orbitActive = true;

	void Start ()
    {
		if (objectInOrbit == null)
        {
            orbitActive = false;
            return;
        }
        SetObjectPosition();
        StartCoroutine(AnimateOrbit());
	}

    void SetObjectPosition()
    {
        Vector2 orbitPos = orbitPath.Evaluate(currentPeriod);
        objectInOrbit.localPosition = new Vector3(orbitPos.x, 0, orbitPos.y);
    }

    IEnumerator AnimateOrbit()
    {
        if (orbitPeriod < 0.1f)
        {
            orbitPeriod = 0.1f;
        }
        float orbitSpeed = 1f / orbitPeriod;
        while (orbitActive)
        {
            currentPeriod += Time.deltaTime * orbitSpeed;
            currentPeriod %= 1f;
            SetObjectPosition();
            yield return null;
        }

    }
	
	
}
