// This file can be replaced during build by using the `fileReplacements` array.
// `ng build --prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.
import configprod from '../../auth_config_prod.json';

const { domain, clientId, authorizationParams: { audience }, apiUri, errorPath } = configprod as {
  domain: string;
  clientId: string;
  authorizationParams: {
    audience?: string;
  },
  apiUri: string;
  errorPath: string;
};

export const environmentprod = {
  production: false,
  auth: {
    domain,
    clientId,
    authorizationParams: {
      redirect_uri: configprod.authorizationParams.audience,
    },
    errorPath,
  },
  httpInterceptor: {
    allowedList: [`${apiUri}/*`],
  },
};