using System;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace n5y.SpotifyApi {
    public interface ITokenProvider {
        string GetAuthorizationHeaderValue();
    }

    public interface ITokenValidation {
        DateTime GetNowDateTime();
        string GetRefreshToken();
        UniTask ValidateAsync(CancellationToken cancellationToken);
    }

    public class EmptyTokenProvider : ITokenProvider {
        public string GetAuthorizationHeaderValue() => "";
    }

    public class EmptyITokenValidation : ITokenValidation {
        public DateTime GetNowDateTime() => DateTime.MinValue;
        public string GetRefreshToken() => "";
        public UniTask ValidateAsync(CancellationToken cancellationToken) => UniTask.CompletedTask;
    }
}
