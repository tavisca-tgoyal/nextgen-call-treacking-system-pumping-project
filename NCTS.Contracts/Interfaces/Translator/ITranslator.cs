using System;
using System.Collections.Generic;
using System.Text;

namespace NCTS.Contracts.Interfaces.Translator
{
    public interface ITranslator<R, T>
    {
        List<R> ToModel(List<T> proxyModelList);
    }
}
