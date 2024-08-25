// This file can be replaced during build by using the `fileReplacements` array.
// `ng build --prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.
import configdev from '../../auth_config_dev.json';

// Import content from auth_config_dev.json file
const { 
    cacheMode, authorizationParams: { redirect_uri, scope, audience }, 
      timeoutInSeconds, detailedResponse, domain, clientId,  apiUri, errorPath } = configdev as 
  {
    cacheMode: string,
    authorizationParams: {
      redirect_uri?: string,
      scope?: string,
      audience?: string,
    },
    timeoutInSeconds: number,
    detailedResponse: boolean,
    domain: string,
    clientId: string,
    apiUri: string,
    errorPath: string
};

// populate exported values for client use
export const environment = {
  production: false,
  auth: {
    // GetTokenSilentlyOptions format follows:
    cacheMode : configdev.cacheMode,  // 'on' | 'off' 'cache_only'
    authorizationParams: {
      audience: configdev.authorizationParams.audience,         // The audience that was used in the authentication request
      scope : configdev.authorizationParams.scope,              // The scope that was used in the authentication request
      redirect_uri: configdev.authorizationParams.redirect_uri, // required
    },
    timeoutInSeconds : configdev.timeoutInSeconds, // A maximum number of seconds to wait before declaring the background /authorize call as failed for timeout
    detailedResponse : configdev.detailedResponse, // false default: - If true, the full response from the /oauth/token endpoint (or the cache, if the cache was used) is returned (minus `refresh_token` if one was issued). Otherwise, just the access token is returned.
    // GetTokenSilentlyOptions ends
    domain : configdev.domain,
    clientId : configdev.clientId,
    apiUri: configdev.apiUri,
    errorPath: configdev.errorPath    
  },
  httpInterceptor: {
    allowedList: [`${apiUri}/*`],
  },
};

/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/plugins/zone-error';  // Included with Angular CLI.
