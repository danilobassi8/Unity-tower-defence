using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {
    private GameObject turretToBuild;
    public GameObject standardTurret;

    // to make this a singleton
    public static BuildManager instance;
    private void Awake() {
        if (instance == null) {
            instance = this;
        }
        else {
            Debug.Log("error.");
            return;
        }
    }

    private void Start() {
        turretToBuild = standardTurret;
    }


    public GameObject getTurretToBuild() {
        return turretToBuild;
    }


}
