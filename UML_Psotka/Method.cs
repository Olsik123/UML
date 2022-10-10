using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static UML_Psotka.Class;

namespace UML_Psotka
{
    public class Method
    {
        public string Name { get; set; }

        public List<string> Parameters { get; set; } = new List<string>();

        public string Output { get; set; }

        public accessModifiers AccessM { get; set; }

        public override string ToString()
        {
            string parameters = "";
            int p = 1;
            foreach (var item in Parameters)
            {
                parameters += "p"+p;
                parameters += " : ";
                parameters += item;
                parameters += ", ";
                p++;
            }
            if(parameters.Length >2)
            parameters = parameters.Substring(0,parameters.Length - 2);
            return $"{(char)this.AccessM}{this.Name}({parameters}) : {this.Output}";
        }

    }
}
