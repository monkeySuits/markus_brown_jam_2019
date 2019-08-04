using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowShooterManager : MonoBehaviour {
    [SerializeField] arrowShooter[] arrowShooters;

    public void Activate(bool _active) {
        foreach (arrowShooter shooter in arrowShooters) {
            shooter.Activate(_active);
        }
    }
}