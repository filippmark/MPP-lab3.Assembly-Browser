using System.Linq;
using System.Reflection;

namespace Model
{
    public class Method
    {
        public string Signature { get; set; }

        public Method(MethodInfo methodInfo)
        {
            Signature = GetSignatureFromType(methodInfo);
        }

        private string GetSignatureFromType(MethodInfo methodInfo)
        {
            var parametrs = methodInfo.GetParameters().Select(t => t.ParameterType + " " + t.Name);
            var parametrInfo = string.Join(',', parametrs);
            string info = $"{methodInfo.ReturnType} {methodInfo.Name}({parametrs})";
            return info;
        }

    }
}
