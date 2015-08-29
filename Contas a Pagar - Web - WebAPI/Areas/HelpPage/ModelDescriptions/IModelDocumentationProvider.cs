using System;
using System.Reflection;

namespace Contas_a_Pagar___Web___WebAPI.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}