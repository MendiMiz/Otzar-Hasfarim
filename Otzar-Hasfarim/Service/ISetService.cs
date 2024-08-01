using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using NuGet.Protocol;
using Otzar_Hasfarim.Models;
using Otzar_Hasfarim.ViewModel;

namespace Otzar_Hasfarim.Service
{
    public interface ISetService
    {
        void CreateSet(SetVM setVM);

    }
}
