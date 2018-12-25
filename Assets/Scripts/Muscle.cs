using UnityEngine;

public class Muscle : Synapse
{
    CRenderObject render;
    CConnector connector = new CConnector();
    //int mclass_id;
    public float strength;
    public float length;
    public Color color;

    public GameObject plane = GameObject.Find("plane");
    public GameObject plane2 = GameObject.Find("plane2");
    public GameObject plane3 = GameObject.Find("plane3");
    public GameObject plane4 = GameObject.Find("plane4");
    public GameObject plane5 = GameObject.Find("plane5");
    public GameObject plane6 = GameObject.Find("plane6");



    public Muscle(float strength, CMassPoint p1, CMassPoint p2, string name) : base(1.0f, name, new Vector3(0, 0, 0))
    {
        this.strength = strength;
        connector.status = 1;
        connector.p1 = p1;
        connector.p2 = p2;
        //mclass_id = i_mclass_id;
        length = (p1.pos - p2.pos).magnitude;
        //synapse->name = i_name;
        drawPos = (p1.pos * 2 + p2.pos * 98) / 100;
        color = new Color(0.2f, 0.2f, 0.2f);
        //color = new Color(255, 0, 0);

        //Set,Color,Alpha
        if ((Globals.renderSwitch & EWormParts.muscle) != 0) render = ResManager.CreateObject(EWormParts.muscle, color, 0.03f * Globals.scale);
    }

    public void Draw()
    {
        if (!render) return;
        Vector3 rp1 = (Globals.ort1 * (connector.p1.x - Globals.pos_rc.x) + Globals.ort2 * (connector.p1.y - Globals.pos_rc.y) + Globals.ort3 * (connector.p1.z - Globals.pos_rc.z)) * Globals.scale + Globals.vcenter;
        Vector3 rp2 = (Globals.ort1 * (connector.p2.x - Globals.pos_rc.x) + Globals.ort2 * (connector.p2.y - Globals.pos_rc.y) + Globals.ort3 * (connector.p2.z - Globals.pos_rc.z)) * Globals.scale + Globals.vcenter;

        color.r = 0.2f + activity;
        render.Setup(color);
        render.Draw(rp1, rp2);

        
    }

    public void Genpng()
    {
     //   plane.transform.position = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
   //     Debug.Log("Gen");
    }

    public Vector3 getPos()
    {
        //   plane.transform.position = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        //     Debug.Log("Gen");
        return drawPos;
    }

    public void UpdateLogic()
    {
        drawPos = (connector.p1.pos * 2 + connector.p2.pos * 98) / 100;

        //if(activity>0)
        if (income > 0)
        {
            Vector3 musclforce = connector.p1.pos - connector.p2.pos;
            musclforce /= musclforce.magnitude;

            if (income >= threshold)
            {
                income = threshold;
            }

            connector.p1.applyForce(-musclforce * (5 * income));
            connector.p2.applyForce(musclforce * (5 * income));

            income *= 0.9f;

            /*if(strength >= income - threshold)
             , {
                 , if(income >= threshold)
                 , {
                     , income = threshold;
                 , }
                 , connector.p1.applyForce(-musclforce * (income - threshold));
                 , connector.p2.applyForce(musclforce * (income - threshold));
             , }
             , else
             , {
                 , connector.p1.applyForce(-musclforce * strength);
                 , connector.p2.applyForce(musclforce * strength);
             , }*/
        }

        //Renderer rend = plane.GetComponent<Renderer>();
       // rend.material.SetFloat("_Cutoff", color.r);


    }

    public void activate(float value)
    {
        income += value;
        //activity = value;
    }

    void disactivate()
    {
        //activity = 0;
    }

    string getName()
    {
        return name;
    }

    float getLength0()
    {
        return length;
    }
}
