using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Builder
{
    public class Builder
    {
        public class Field
        {
            public string Type, Name;
            public override string ToString()
            {
                return $"public {Type} {Name}";
            }
        }

        public class Class
        {
            public string Name { get; set; }
            public List<Field> Fields = new List<Field>();
            public override string ToString()
            {
                var sb = new StringBuilder();
                sb.AppendLine($"public class {Name}").AppendLine("{");
                foreach (var f in Fields)
                    sb.AppendLine($"  {f};");
                sb.AppendLine("}");
                return sb.ToString();
            }
        }

        public class CodeBuilder
        {
            private Class theClass = new Class();
            public CodeBuilder(string rootName)
            {
                theClass.Name = rootName;
            }
            public CodeBuilder AddField(string name, string type)
            {
                theClass.Fields.Add(new Field { Name = name, Type = type });
                return this;
            }
            public override string ToString()
            {
                return theClass.ToString();
            }
        }
    }
}
