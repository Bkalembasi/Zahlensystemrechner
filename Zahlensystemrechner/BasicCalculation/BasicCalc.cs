using System;
using System.Text.RegularExpressions;

public class BasicCalc
{
	public BasicCalc()
	{
	}

    private int counter = 0;

	private double add_sub(String[] result)
    {
        double erg = mul_div(result);

        if (counter == result.Length)
        {
            return erg;
        }

        while ("+".Equals(result[counter]) || "-".Equals(result[counter]))
        {
            if ("+".Equals(result[counter]) || "-".Equals(result[counter]))
            {
                erg = erg + mul_div(result);
            } 

            if (counter == result[counter])
            {
                return erg;
            }
        }
    }

	private double mul_div(String[] result)
    {
        double erg = expo(result);

        if (counter == result[counter])
        {
            return erg;
        }

        while ("*".Equals(result[counter]) || "/".Equals(result[counter]))
        {
            if ("*".Equals(result[counter]))
            {
                counter++;
                erg = erg * expo(result);
            }
            else if ("/".equals(result[counter]))
            {
                counter++;
                if (expo(result) == 0)
                {
                    Console.WriteLine("Division durch 0");
                    erg = 0;
                    return 0;
                }
                erg = expo(result) / erg;
            }
            if (counter == result.Length)
            {
                return erg;
            }
        }
    }

	private double expo(String[] result)
    {
        double erg = oper(result);

        if (counter == result.Length)
        {
            return erg;
        }
        while ("^".Equals(result[counter]))
        {
            if ("^".Equals(result[counter]))
            {
                counter++;
                erg = Math.Pow(erg, oper(result));
            }
            if (counter == result.Length)
            {
                return erg;
            }
        }
        return erg;
    }

    private double oper(String[] result)
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
        else if ("-".Equals(result[counter]))
        {
            faktor = -1;
            counter++;
        }
        else if ("(".Equals(result[counter]))
        {
            counter++;
            erg = add_sub(result);
            counter++;
            return erg;
        }

        erg = System.Convert.ToDouble(result[counter]) * faktor;
        counter++;
        return erg;
    }

    public static void Main(string[] args)
    {
        Regex regex = new Regex("(?<=[-+*/)(^])|(?=[-+*/)(^])");
        Regex filter = new Regex("[^0-9-+*/^)(.]");

        Console.WriteLine("Rechnung eingeben: ");
        String eingabe = Console.ReadLine();

        eingabe = filter.Replace(filter, "");
        String[] result = regex.Split(eingabe);

        BasicCalc calc = new BasicCalc();
        Double erg = calc.add_sub(result);

        Console.WriteLine(erg);
    }
}
