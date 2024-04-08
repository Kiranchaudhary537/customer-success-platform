using System.Linq;
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using Nito.AsyncEx;
namespace Test.Authorization
{

    public class DynamicOpenIdConnectSigningKeyResolver
    {
        private OpenIdConnectConfiguration _openIdConfig;
 
 

        public async Task<SecurityKey[]> GetSigningKeysAsync()
        {
            if (_openIdConfig is null)
            {
                var cm = new ConfigurationManager<OpenIdConnectConfiguration>("https://dev-p4ib51tdssuj8ngy.us.auth0.com/.well-known/openid-configuration", new OpenIdConnectConfigurationRetriever());
                _openIdConfig = await cm.GetConfigurationAsync();
            }

            return _openIdConfig.JsonWebKeySet.GetSigningKeys().ToArray();

        }
    }

}
