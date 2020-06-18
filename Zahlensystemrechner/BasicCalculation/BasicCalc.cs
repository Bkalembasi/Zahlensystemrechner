using System;
using System.Text.RegularExpressions;

public class BasicCalc
{
	public BasicCalc()
	{
	}
    
    //Globaler Counter zur Abfrage der Position im Result-Array
    private int counter = 0;

	private double Add_sub(String[] result)
    {
        double erg = Mul_div(result);
        
        //Erreicht der Counter die letzte position wird abgebrochen
        if (counter == result.Length)
        {
            return erg;
        }

        while ("+".Equals(result[counter]) || "-".Equals(result[counter]))
        {
            if ("+".Equals(result[counter]) || "-".Equals(result[counter]))
            {
                erg = erg + Mul_div(result);
            } 
            if (counter == result.Length)
            {
                return erg;
            }
        }
        return erg;
    }

	private double Mul_div(String[] result)
    {
        double erg = Expo(result);

        if (counter == result.Length)
        {
            return erg;
        }

        while ("*".Equals(result[counter]) || "/".Equals(result[counter]))
        {
            if ("*".Equals(result[counter]))
            {
                counter++;
                erg = erg * Expo(result);
            }
            else if ("/".Equals(result[counter]))
            {
                counter++;
                //Sollte durch 0 geteilt werden wird ein Fehler ausgegeben
                if (Convert.ToInt32(result[counter]) == 0)
                {
                    Console.WriteLine("Division durch 0");
                    return 0;
                }
                erg = erg / Expo(result);
            }
            if (counter == result.Length)
            {
                return erg;
            }
        }
        return erg;
    }

	private double Expo(String[] result)
    {
        double erg = Oper(result);

        if (counter == result.Length)
        {
            return erg;
        }
        while ("^".Equals(result[counter]))
        {
            if ("^".Equals(result[counter]))
            {
                counter++;
                erg = Math.Pow(erg, Oper(result));
            }
            if (counter == result.Length)
            {
                return erg;
            }
        }
        return erg;
    }

    private double Oper(String[] result)
    {
        int faktor = 1;
        double erg = 0;

        if (counter == result.Length)
        {
            return erg;
        }

        if ("+".Equals(result[counter]))
        {
            faktor = 1;
            counter++;
        }
        if ("-".Equals(result[counter]))
        {
            faktor = -1;
            counter++;
        }

        if ("(".Equals(result[counter]))
        {
            counter++;
            erg = Add_sub(result);
            counter++;
            return erg;
        }

        erg = System.Convert.ToDouble(result[counter]) * faktor;
        counter++;
        return erg;
    }
}
