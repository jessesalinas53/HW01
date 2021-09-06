using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invincibility : PowerUpBase
{
    [SerializeField] Material _origMaterial;
    [SerializeField] Material _tempMaterial;
    [SerializeField] GameObject _tankBody;
    [SerializeField] GameObject _tankTurret;

    protected override void PowerUp(Player player)
    {
        base.PowerUp();

        _tankBody.GetComponent<Renderer>().material = _tempMaterial;
        _tankTurret.GetComponent<Renderer>().material = _tempMaterial;

        player.invincible = true;
        Debug.Log("Player is Invinsible");
    }

    protected override IEnumerator PowerDown()
    {
        _tankBody.GetComponent<Renderer>().material = _origMaterial;
        _tankTurret.GetComponent<Renderer>().material = _origMaterial;

        return base.PowerDown();
    }
}
