using System;
using System.Collections.Generic;
using System.Linq;

namespace Zahlensystemrechner { 
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
		//Array, das alle Operatoren, die unser Programm akzeptiert als String speichert. 
		private string[] operators = { "(", ")", "*", "/", "+", "-", "^", "" };

		//Die Zahl als Binärzahl
		private string binaryNumber;
		//Die Zahl als Oktalzahl
		private string octaNumber;
		//Die Zahl als Dezimalzahl
		private long decNumber;
		//Die Zahl als Hexadezimalzahl
		private string hexDecNumber;
		//Die Zahlensystem der ursprünglichen Eingabe
		private NumberType originalNumber;
		//Ist die erstellte Zahl fehlerfrei?
		private Boolean error;
		//Position im Term Array
		private int index;
		//Ist die eingegebene Zahl ein Opertaor?
		private Boolean isOperator;

		//Default Constructor, falls eine Zahl (z.B. für das Rechenergebniss) erstellt werden muss
		public Number()
		{
			error = false;
		}
		//Constructor, der für Eingaben verwendet wird.
		//Der Prefix der Eingabe wird abgespalten, der ensprechende Zahlenwert wird gesetzt
		//und die Zahl wrird in die anderen Systeme umgerechnet
		public Number(string input)
		{
			error = false;
			string value = GetNumberValue(input);
			if(originalNumber != NumberType.decNumber && !isOperator)
			{
				ToDecNumber(value);
			}
		}

		//gibt die Zahl als Binärzahl zurück
		public string GetBinaryNumber()
		{
			return binaryNumber;
		}
		//gibt die Zahl als Oktalzahl zurück
		public string GetOctaNumber()
		{
			return octaNumber;
		}
		//gibt die Zahl als Dezimalzahl zurück
		public string GetDecNumber()
		{
			return System.Convert.ToString(decNumber);
		}
		//setzt den Wert der Dezimalzahl gleich der Eingabe
		public void SetDecNumber(long numberValue)
		{
			this.decNumber = numberValue;
			this.originalNumber = NumberType.decNumber;
		}
		//gbt die Zahl als Hexadezimalzahl zurück
		public string GetHexDecNumber()
		{
			return hexDecNumber;
		}

		//gib den gespeicherten Index der Zahl zurück
		public int GetIndex()
		{
			return index;
		}

		//speichert den Index, den die Zahl im Eingabearray hat.
		public void SetIndex(int index)
		{
			this.index = index;
		}

		//Gibt error zurück
		public Boolean GetErrror()
		{
			return error;
		}

		//Gibt isOperator zurück
		public Boolean GetIsOperator()
		{
			return isOperator;
		}

		//Rechne die Zahl in die anderen Zahlensysteme um
		public void ToOtherSystems()
		{
			FromDecNumber();
		}

		//splittet den Prefix der Eingabe ab und setzt den Wert des enstprechenden Zahlensystem gleich der Eingabe
		//sollte kein Prefix eingegeben werden, wird der die Eingabe automatisch auf den den Dezimalwert der Zahl übertragen
		private string GetNumberValue(string input)
		{
			string value = "";
			if (!operators.Contains(input))
			{
				string prefix = input.Split("_")[0];
				if (input.Split("_").Length > 1)
				{
					value = input.Split("_")[1];
				}
				switch (prefix)
				{
					case "B":
						if (CheckInput(value, 2))
						{
							originalNumber = NumberType.binaryNumber;
							binaryNumber = value;
						}
						break;
					case "O":
						if (CheckInput(value, 8))
						{
							originalNumber = NumberType.octaNumber;
							octaNumber = value;
						}
						break;
					case "H":
						if (CheckInput(value, 16))
						{
							originalNumber = NumberType.hexDecNumber;
							hexDecNumber = value;
						}
						break;
					default:
						//Wenn ein falsches Prefix eingegeben wurde (zB HB_)
						if(value != "") 
						{
							error = true;
						}
						else if (CheckInput(input, 10))
						{
							originalNumber = NumberType.decNumber;
							decNumber = long.Parse(input);
						}
						break;
				}
			}
			else
			{
				isOperator = true;
			}
			return value;
		}
	
		//Überprüft, ob der eingegebene Zahlenstring richtig ist.
		private Boolean CheckInput(String input, int system) {
			Boolean isOk = true;            
			List<string> symbols = new List<string>();
			//Erstelle eine Liste mit allen Zeichen, die eine Zahl im gewählten Zahlensystem enthalten darf
			for (int i = 0; i < system; i++)
			{
				symbols.Add(System.Convert.ToString(i));
				if (i > 9)
				{
					char hexNum = System.Convert.ToChar(HexConvert(i, true));
					symbols.Add(System.Convert.ToString(hexNum));
				}
			}
			for (int i = 0; i < input.Length; i++)
			{
				//Falls die Eingabe ein ungültiges Zeichen enhält setzte isOk auf false
				if (!symbols.Contains(System.Convert.ToString(input[i])))
				{
					isOk = false;
				}
			}
			
			//Setze error auf das Gegenteil von isOk. Denn wenn der String ok ist (isOk = true), enhält die Eingabe keinen Fehler
			//(und damit error = false)
			error = !isOk;
			return isOk;
		}

		//Gibt den Wert der ensprechenden Konaste des usprünglichen Zahlensystems als double zurück
		private double GetNumberSystemValue()
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
		private int[] GetSystemsToCalculate()
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
		private void ToDecNumber(string number)
		{
			double system = GetNumberSystemValue();
			for(int i = 0; i < number.Length; i++)
			{
				//-'0' da ein char bei einer Konvertierung nach int immer in seinen Ascii-Wert umgewandelt wird.
				char numberChar = number[i];
				int indexNumber;
				int numCode = (numberChar);

				if ( numCode > 9)
				{	
					char decNum = System.Convert.ToChar(HexConvert(numCode, false));
					indexNumber = decNum ;
				}
				else
				{
					indexNumber = AsciiToValue(number[i]);
				}
				int exponent = number.Length - (i + 1);
				decNumber = decNumber + System.Convert.ToInt64(indexNumber * Math.Pow(system, exponent));
			}
		}

		//setzt den Wert des entprechenden Zahlensystems der umgerechneten Zahl gleich
		private void SetNumberSystemValue(int system, string number)
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
		private void FromDecNumber()
		{
			int[] systemsToCalculate = GetSystemsToCalculate();
			for(int i = 0; i < systemsToCalculate.Length; i++)
			{	
				long decNumberCopy = System.Convert.ToInt64(decNumber);
				string number = "";
				while( decNumberCopy > 0 )
				{
					int num = System.Convert.ToInt32(decNumberCopy % systemsToCalculate[i]);

					if (num > 9)
                    {	
						char hexChar = System.Convert.ToChar(HexConvert(num, true));
						number = hexChar + number;
                    }
                    else
                    {
						number = num + number;
                    }
					
					decNumberCopy = decNumberCopy / systemsToCalculate[i];
				}
				SetNumberSystemValue(systemsToCalculate[i], number);
			}
		}

		//Wandelt einen Dezimalwert in einen Hexadezimalwert, bzw einen Hexadezimalwert in einen Dezimalwert um. 
		//(Verändert den ASCII-Code)
		private int HexConvert(int number, Boolean isDez) 
		{
			int evaluater = -55;
			if(isDez) {
				evaluater = 55;
			}
			number = number + evaluater;
			return number;
		}

		//Wandelt den Ascii-Wert einer Zahl in ihre tatsächliche Value um.
		private int AsciiToValue(char numberChar)
        {
			int number = numberChar - '0';
			return number;
        }
		public String GetAllSystems()
        {
			String allSystemSolution = "";

			this.ToOtherSystems();
			allSystemSolution += "Binär: " + this.GetBinaryNumber() + "\n";
			allSystemSolution += "Dezimal: " + this.GetDecNumber() +"\n";
			allSystemSolution += "Hexadezimal: " + this.GetHexDecNumber() + "\n";
			allSystemSolution += "Oktalsystem:" + this.GetOctaNumber();

			return allSystemSolution;
        }
	}
}
