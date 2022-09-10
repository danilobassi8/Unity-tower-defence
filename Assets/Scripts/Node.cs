using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {
    public Color hoverColor;
    public Vector3 positionOffset = new Vector3(0, 0.5f, 0);

    private Color startColor;
    private Renderer _renderer;
    private GameObject turret;

    void Start() {
        _renderer = GetComponent<Renderer>();
        startColor = _renderer.material.color;
    }

    private void OnMouseDown() {
        if (turret != null) {
            Debug.Log("CANT BUILD HERE. There's already a tower.");
            return;
        }
        // BUILD A TOWER.
        GameObject turretToBuild = BuildManager.instance.getTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
        Debug.Log("I have a tower now.", turret);
    }

    private void OnMouseEnter() {
        _renderer.material.color = hoverColor;
    }

    private void OnMouseExit() {
        _renderer.material.color = startColor;
    }

}
