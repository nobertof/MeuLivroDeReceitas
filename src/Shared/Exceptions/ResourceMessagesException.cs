using System.Reflection;
using System.Resources;

namespace Exceptions;

public static class ResourceMessagesException
{
    private static readonly ResourceManager _resourceManager = new(
        "Exceptions.ResourceMessagesException",  // namespace + nome do .resx
        Assembly.GetExecutingAssembly()
    );

    public static string Get(string key)
    {
        return _resourceManager.GetString(key) ?? $"[Mensagem não encontrada: {key}]";
    }
}