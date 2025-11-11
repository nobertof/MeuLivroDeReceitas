using System.Reflection;
using System.Resources;
using Exceptions.Enums;

namespace Exceptions;

public static class ResourceMessagesException
{
    private static readonly ResourceManager _resourceManager = new(
        "Exceptions.ResourceMessagesException",  // namespace + nome do .resx
        Assembly.GetExecutingAssembly()
    );

    public static string Get(ExceptionName key)
    {
        return _resourceManager.GetString(key.ToString()) ?? $"[Mensagem não encontrada: {key}]";
    }
}