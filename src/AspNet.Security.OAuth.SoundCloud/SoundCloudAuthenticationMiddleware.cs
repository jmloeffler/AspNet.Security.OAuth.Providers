/*
 * Licensed under the Apache License, Version 2.0 (http://www.apache.org/licenses/LICENSE-2.0)
 * See https://github.com/aspnet-contrib/AspNet.Security.OAuth.Providers
 * for more information concerning the license and the contributors participating to this project.
 */

using Microsoft.AspNet.Authentication;
using Microsoft.AspNet.Authentication.OAuth;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.DataProtection;
using Microsoft.Extensions.Internal;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.OptionsModel;
using Microsoft.Extensions.WebEncoders;

namespace AspNet.Security.OAuth.SoundCloud {
    public class SoundCloudAuthenticationMiddleware : OAuthMiddleware<SoundCloudAuthenticationOptions> {
        public SoundCloudAuthenticationMiddleware(
            [NotNull] RequestDelegate next,
            [NotNull] SoundCloudAuthenticationOptions options,
            [NotNull] IDataProtectionProvider dataProtectionProvider,
            [NotNull] ILoggerFactory loggerFactory,
            [NotNull] IUrlEncoder encoder,
            [NotNull] IOptions<SharedAuthenticationOptions> externalOptions)
            : base(next, dataProtectionProvider, loggerFactory, encoder, externalOptions, options) {
        }

        protected override AuthenticationHandler<SoundCloudAuthenticationOptions> CreateHandler() {
            return new SoundCloudAuthenticationHandler(Backchannel);
        }
    }
}
