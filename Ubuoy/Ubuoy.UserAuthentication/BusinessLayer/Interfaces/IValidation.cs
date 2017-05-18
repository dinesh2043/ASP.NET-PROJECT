using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ubuoy.UserAuthentication.BusinessLayer.Interfaces
{
    public interface IValidation
    {
        List<string> ValidationSummary { get; set; }
        bool IsHavingValidInputs(params object[] inputs);
    }
}
