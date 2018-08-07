using System;
namespace SDC.Coach.Auth
{
    public interface ITokenProvider
    {
        String Token { get; }
        Boolean HasToken { get; }
    }
}
