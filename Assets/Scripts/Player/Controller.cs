using UnityEngine;

public sealed class Controller : IController
{
    private string _axisX = "Horizontal";
    private string _axisZ = "Vertical";
    private string _axisFire = "Fire1";

    public float MoveAxisX()
    {
        return Input.GetAxis(_axisX);
    }

    public float MoveAxisZ()
    {
        return Input.GetAxis(_axisZ);
    }

    public float AxisFire()
    {
        return Input.GetAxis(_axisFire);
    }

    public bool AxisReload()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public int AxisChoose()
    {
        int numberWeapon;

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            return numberWeapon = 1;
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            return numberWeapon = 2;
        }
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            return numberWeapon = 3;
        }
        if(Input.GetKeyDown(KeyCode.Alpha4))
        {
            return numberWeapon = 4;
        }

        return 0;
    }

    public bool AxisJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool AxisPause()
    {
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool AxisAct()
    {
        if (Input.GetKey(KeyCode.E))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool AxisWalk()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}