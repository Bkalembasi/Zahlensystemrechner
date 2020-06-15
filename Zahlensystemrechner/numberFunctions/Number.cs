using System;

/// <summary>
/// Dies ist die Zahlen die Klasse. Diese Klasse enthäft alle Informationen und Methoden, die benötigt werden,
/// um zwischen den einzelnen Zahlensystemen hin und her zu wechseln. Sie speichert die Werte der Zahl in anderen Zahlensystemen und das Zahlensystem,
/// in dem sie ursprünglich eingegeben wurde.
/// </summary>
public class Number
{
	//Konstante mit dem Wert, der benötigt wird, um vom Dezimal- ins Binärsystem
	//und vom Binär- ins Dezimalsystem umzurechnen
	public const int BINARY = 2;
	//Konstante mit dem Wert, der benötigt wird, um vom Dezimal- ins Oktalsystem
	//und vom Oktal- ins Dezimalsystem umzurechnen
	public const int OCTAL = 8;
	//Konstante mit dem Wert, der benötigt wird, um vom Dezimal- ins Hexadezimalsystem
	//und vom Hexadezimal- ins Dezimalsystem umzurechnen
	public const int HEXDECIMAL = 16;

	//Die Zahl als Binärzahl
	private string binaryNumber;
	//Die Zahl als Oktalzahl
	private string octaNumber;
	//Die Zahl als Dezimalzahl
	private long decNumber;
	//Die Zahl als Hexadezimalzahl
	private string hexDecNumber;
	//Das Zahlensytem, in dem die Zahl ursprünglich erfasst wurde
	private NumberType originalNumber;

	//Default Constructor, falls eine Zahl (z.B. für das Rechenergebniss) erstellt werden muss
	public Number()
	{
	}
	//Constructor, der für Eingaben verwendet wird.
	//Der Prefix der Eingabe wird abgespalten, der ensprechende Zahlenwert wird gesetzt
	//und die Zahl wrird in die anderen Systeme umgerechnet
	public Number(string input)
    {
    }

	//gibt die Zahl als Binärzahl zurück
	public string getBinaryNumber()
    {
		return binaryNumber;
    }
	//gibt die Zahl als Oktalzahl zurück
	public string getOctaNumber()
    {
		return octaNumber;
    }
	//gibt die Zahl als Dezimalzahl zurück
	public long getDecNumber()
    {
		return decNumber;
    }
	//setzt den Wert der Dezimalzahl gleich der Eingabe
	public void setDecNumber(long numberValue)
    {
		this.decNumber = numberValue;
    }
	//gbt die Zahl als Hexadezimalzahl zurück
	public string getDecNumber()
    {
		return decNumber;
    }
	//gibt das ursprüngliche Zahlensystem der Zahl zurück
	public NumberType getOriginalNumber()
    {
		return originalNumber;
    }

	//Rechnet die Zahlen A-F des Hexadezimalzahlensystems ihre ensprechenden Werte im Dezimalzahlensystem um
	private int hexToDec(char number)
    {
		int decValue = 0;
		switch(decNumber)
        {
			case 'A': 
				decValue = 10;
				break;
			case 'B':
				decValue = 11;
				break;
			case 'C':
				decValue = 12;
				break;
			case 'D':
				decValue = 13;
				break;
			case 'E':
				decValue = 14;
				break;
			case 'F':
				decValue = 15;
				break;
        }
		return decNumber;
    }

	//Rechnet die Zahlen 10-15 des Dezimalzahlensystems in ihre ensprechenden Werte im Hexadezimalzahlensystem um
	private string decToHex(int number)
    {
		string hexDec = "";
		switch(number)
        {
			case 10:
				hexDec = "A";
				break;
			case 11:
				hexDec = "B";
				break;
			case 12:
				hexDec = "C";
				break;
			case 13:
				hexDec = "D";
				break;
			case 14:
				hexDec = "E";
				break;
			case 15:
				hexDec = "F";
				break;
        }
		return hexDec;
    }

	//splittet den Prefix der Eingabe ab und setzt den Wert des enstprechenden Zahlensystem gleich der Eingabe 
	//sollte kein Prefix eingegeben werden, wird der die Eingabe automatisch auf den den Dezimalwert der Zahl übertragen
	private void getNumberValue(string input)
    {
		string prefix = input.Split("_")[0];
		string value = input.Split("_")[1];
		switch (prefix)
        {
			case "B":
				binaryNumber = value;
				break;
			case "O":
				octaNumber = value;
				break;
			case "H":
				hexDecNumber = value;
				break;
			default:
				decNumber = long.Parse(input);
				break;
        }
    }

	//Gibt den Wert der ensprechenden Konaste des usprünglichen Zahlensystems als double zurück
	private double getNumberSystemValue()
    {
		double systemValue = 0;
		switch (originalNumber)
        {
			case NumberType.binaryNumber:
				systemValue = BINARY;
				break;
			case NumberType.octaNumber:
				systemValue = OCTAL;
				break;
			case NumberType.hexDecNumber:
				systemValue = HEXDECIMAL;
				break;
        }
		return systemValue;
    }

	//Gibt den Wert der Konstanten, der Zahlensysteme, in die die Zahl noch nicht umgerechnet wurde zurück
	private int[] getSystemsToCalculate()
    {
		switch (originalNumber)
        {
			case NumberType.binaryNumber:
				return new int[] { OCTAL, HEXDECIMAL };
			case NumberType.octaNumber:
				return new int[] { BINARY, HEXDECIMAL };
			case NumberType.hexDecNumber:
				return new int[] { BINARY, OCTAL };
			default:
				return new int[] { BINARY, OCTAL, HEXDECIMAL };
		}
    }

	//Rechnet die Eingabe in eine Dezimalzahl um
	private void toDecNumber(string number)
    {
		double system = getNumberSystemValue();
		for(i < number.Length; i >= 0; i--)
        {
			decNumber = decNumber + long.Parse(number[i]) * Math.Pow(system, i);
        }
    }

	//setzt den Wert des entprechenden Zahlensystems der umgerechneten Zahl gleich
	private void setNumberSystemValue(int system, string number)
    {
		switch (system)
        {
			case BINARY:
				binaryNumber = number;
				break;
			case OCTAL:
				octaNumber = number;
				break;
			case HEXDECIMAL:
				hexDecNumber = number;
				break;
        }
    }

	//Rechnet den gespeicherten Wert der Dezimalzahl, in die Werte, der noch nicht gespeicherten Zahlensysteme um
	private void fromDecNumer()
    {
		int[] systemsToCalculate = getSystemsToCalculate;
		for(int i = 0; i < systemsToCalculate.Length; i++)
        {	
			int decNumberCopy = decNumber;
			string number = "";
			while( decNumberCopy > 0)
            {
				number = (decNumberCopy % systemsToCalculate[i]) + number;
				decNumberCopy = decNumberCopy / systemsToCalculate[i];
			}
			setNumberSystemValue(systemsToCalculate[i], number);
        }
    }
}
