using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class Solver : MonoBehaviour
{

    public InputField Va, Vb, Vc; //input values of a, b and c factors of the equation
    public Text sortie; //text element to prompt for the user
    private float a, b, c; //coefficient values


    // Use this for initialization
    void Start()
    {
        Va.text = Vb.text = Vc.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        a = float.Parse(Va.text);
        b = float.Parse(Vb.text);
        c = float.Parse(Vc.text);
        sortie.text = EqSolver(a, b, c);
    }

    /// <summary>
    /// Solver method
    /// </summary>
    /// <param name="a">value of the coefficient of x^2</param>
    /// <param name="b">value of the coeeficient on x</param>
    /// <param name="c">value of the last coefficient</param>
    /// <returns>returns a sign table of the function</returns>
    string EqSolver(float a, float b, float c)
    {
        StringBuilder tableau = new StringBuilder();
        float disc, disc2;
        float x1, x2;

        disc = Mathf.Pow(b, 2) - 4 * a * c;

        if (disc > 0)
        {
            disc2 = Mathf.Sqrt(disc);
            x1 = (-b - disc2) / (2 * a);
            x2 = (-b + disc2) / (2 * a);

            tableau.Append("x1=" + x1 + "      x2=" + x2);

           if (x1 > 0 && x2 > 0)
            {
                if (a > 0)
                {
                    tableau.Append(string.Format("\n\n x                 | -inf           "+x1+"             "+x2+"            +inf\n" +
                                                  "___________________|_________________|__________________|________________\n" +
                                                  "(x-{0:E})(x-{1:E}) |        +        0         -        0        +       \n"));
                }
                else
                {
                    tableau.Append(string.Format(" x                 | -inf           {0:E}             {1:E}            +inf\n" +
                                                 "___________________|_________________|__________________|________________\n" +
                                                 "(x-{0:E})(x-{1:E}) |        -        0         +        0        -       \n"));
                }
            }
            else if (x1 > 0 && x2 < 0)
            {

            }
        }
        else if(disc == 0)
        {
            x1 = -b / 2 * a;
            tableau.Append("x=" + x1);
        }
        else
        {
            tableau.Append("Pas de solution réelle");
        }


        return tableau.ToString();
    }
}
