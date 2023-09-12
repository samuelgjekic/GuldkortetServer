using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuldkortetKlient
{
    public class FileLines
    {

        public FileLines() { }

        public string GetRandomLine(string filePath)
        {
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                int randomLineNumber = new Random().Next(0, lines.Length);
                return lines[randomLineNumber];
            } else {
                MessageBox.Show("Filen hittades inte!", "error");
                return "Filen hittades inte."; }
     
        }



    }
}
