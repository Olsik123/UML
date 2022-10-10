using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static UML_Psotka.Class;

namespace UML_Psotka
{
    public class Property
    {

        public string Name { get; set; }
        public string DataType { get; set; }
        public accessModifiers AccessM { get; set; }
        public override string ToString()
        {
            return $"{(char)this.AccessM}{this.Name} : {this.DataType}";
        }
    }
}
