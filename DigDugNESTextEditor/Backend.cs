using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Author: Shawn M. Crawford
namespace DigDugNESTextEditor {
    class Backend {
        int textFlag = 0;

        public void getText(string path, TextBox texboxname, int length, int offset) {

            string romCodeString = "";
            string ddAsciiOut = "";
            string tempHexString = "";
            int x = 0;
            using (FileStream fileStream = new FileStream(@path, FileMode.Open, FileAccess.Read)) {
                fileStream.Seek(offset, SeekOrigin.Begin);

                while (x < length) {
                    romCodeString = fileStream.ReadByte().ToString("X");
                    //if length is single digit add a 0 ( 1 now is 01)
                    if (romCodeString.Length == 1) {
                        romCodeString = "0" + romCodeString;
                    }
                    tempHexString = romCodeString;

                    decodeRomText(tempHexString);


                    if (textFlag == 0) {
                            ddAsciiOut += decodeRomText(tempHexString);
                    }
                    x++;
                }

                // Build and append
                texboxname.Text += ddAsciiOut;
            }

        }

        public void updateROMText(string absoluteFilename, int length, TextBox textBox, int offset) {

            string newDDString = textBox.Text;

            newDDString = newDDString.PadRight(length);
            string hexReturn = "";
            string tempascii = "";
            string[] newDDStringArray = new string[length];
            byte[] newDDStringByteArray = new byte[length];
            int[] ddDecimal = new int[length];
            string[] ddFinal = new string[length];
            string[] dds = new string[length];

            int x = 0;
            while (x < length) {
                newDDStringArray[x] = newDDString[x].ToString();
                tempascii = newDDStringArray[x];
                hexReturn += encodeRomText(tempascii);
                x++;
            }

            int i = 0;
            int j = 0;
            while (i < length) {
                dds[i] = hexReturn[j].ToString() + hexReturn[j + 1].ToString();
                i++;
                j += 2;
            }

            int q = 0;
            while (q < length) {
                ddDecimal[q] = int.Parse(dds[q], System.Globalization.NumberStyles.HexNumber);
                ddFinal[q] = ddDecimal[q].ToString();
                newDDStringByteArray[q] = byte.Parse(ddFinal[q]);
                q++;
            }

            using (FileStream fileStream = new FileStream(@absoluteFilename, FileMode.Open, FileAccess.Write)) {
                fileStream.Seek(offset, SeekOrigin.Begin);
                q = 0;
                while (q < length) {
                    fileStream.WriteByte(newDDStringByteArray[q]);
                    q++;
                }
            }
        }

        private string decodeRomText(string tempHexString) {
            string lozAscii = "";
            textFlag = 0;

            switch (tempHexString) {
                case "00":
                    lozAscii += "0";
                    break;
                case "01":
                    lozAscii += "1";
                    break;
                case "02":
                    lozAscii += "2";
                    break;
                case "03":
                    lozAscii += "3";
                    break;
                case "04":
                    lozAscii += "4";
                    break;
                case "05":
                    lozAscii += "5";
                    break;
                case "06":
                    lozAscii += "6";
                    break;
                case "07":
                    lozAscii += "7";
                    break;
                case "08":
                    lozAscii += "8";
                    break;
                case "09":
                    lozAscii += "9";
                    break;
                case "0A":
                    lozAscii += "A";
                    break;
                case "0B":
                    lozAscii += "B";
                    break;
                case "0C":
                    lozAscii += "C";
                    break;
                case "0D":
                    lozAscii += "D";
                    break;
                case "0E":
                    lozAscii += "E";
                    break;
                case "0F":
                    lozAscii += "F";
                    break;
                case "10":
                    lozAscii += "G";
                    break;
                case "11":
                    lozAscii += "H";
                    break;
                case "12":
                    lozAscii += "I";
                    break;
                case "13":
                    lozAscii += "J";
                    break;
                case "14":
                    lozAscii += "K";
                    break;
                case "15":
                    lozAscii += "L";
                    break;
                case "16":
                    lozAscii += "M";
                    break;
                case "17":
                    lozAscii += "N";
                    break;
                case "18":
                    lozAscii += "O";
                    break;
                case "19":
                    lozAscii += "P";
                    break;
                case "1A":
                    lozAscii += "Q";
                    break;
                case "1B":
                    lozAscii += "R";
                    break;
                case "1C":
                    lozAscii += "S";
                    break;
                case "1D":
                    lozAscii += "T";
                    break;
                case "1E":
                    lozAscii += "U";
                    break;
                case "1F":
                    lozAscii += "V";
                    break;
                case "20":
                    lozAscii += "W";
                    break;
                case "21":
                    lozAscii += "X";
                    break;
                case "22":
                    lozAscii += "Y";
                    break;
                case "23":
                    lozAscii += "Z";
                    break;
                case "24":
                    lozAscii += " ";
                    break;
                case "25":
                    lozAscii += "!";
                    break;
                case "26":
                    lozAscii += ".";
                    break;
                case "27":
                    lozAscii += "-";
                    break;
                case "28":
                    lozAscii += "©";
                    break;
                case "2A":
                    lozAscii += ">";
                    break;
                default:
                    lozAscii += " ";
                    textFlag = 1;
                    break;
            }

            return lozAscii;
        }

        public string encodeRomText(string tempascii) {
            string lozHex = "";
            tempascii = tempascii.ToUpper();

            switch (tempascii) {
                case "0":
                    lozHex += "00";
                    break;
                case "1":
                    lozHex += "01";
                    break;
                case "2":
                    lozHex += "02";
                    break;
                case "3":
                    lozHex += "03";
                    break;
                case "4":
                    lozHex += "04";
                    break;
                case "5":
                    lozHex += "05";
                    break;
                case "6":
                    lozHex += "06";
                    break;
                case "7":
                    lozHex += "07";
                    break;
                case "8":
                    lozHex += "08";
                    break;
                case "9":
                    lozHex += "09";
                    break;
                case "A":
                    lozHex += "0A";
                    break;
                case "B":
                    lozHex += "0B";
                    break;
                case "C":
                    lozHex += "0C";
                    break;
                case "D":
                    lozHex += "0D";
                    break;
                case "E":
                    lozHex += "0E";
                    break;
                case "F":
                    lozHex += "0F";
                    break;
                case "G":
                    lozHex += "10";
                    break;
                case "H":
                    lozHex += "11";
                    break;
                case "I":
                    lozHex += "12";
                    break;
                case "J":
                    lozHex += "13";
                    break;
                case "K":
                    lozHex += "14";
                    break;
                case "L":
                    lozHex += "15";
                    break;
                case "M":
                    lozHex += "16";
                    break;
                case "N":
                    lozHex += "17";
                    break;
                case "O":
                    lozHex += "18";
                    break;
                case "P":
                    lozHex += "19";
                    break;
                case "Q":
                    lozHex += "1A";
                    break;
                case "R":
                    lozHex += "1B";
                    break;
                case "S":
                    lozHex += "1C";
                    break;
                case "T":
                    lozHex += "1D";
                    break;
                case "U":
                    lozHex += "1E";
                    break;
                case "V":
                    lozHex += "1F";
                    break;
                case "W":
                    lozHex += "20";
                    break;
                case "X":
                    lozHex += "21";
                    break;
                case "Y":
                    lozHex += "22";
                    break;
                case "Z":
                    lozHex += "23";
                    break;
                case " ":
                    lozHex += "24";
                    break;
                case "!":
                    lozHex += "25";
                    break;
                case ".":
                    lozHex += "26";
                    break;
                case "-":
                    lozHex += "27";
                    break;
                case "©":
                    lozHex += "28";
                    break;
                case ">":
                    lozHex += "29";
                    break;
                default:
                    lozHex += "24";
                    break;
            }

            return lozHex;
        }


    }
}
