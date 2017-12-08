import { enableProdMode } from '@angular/core';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';

import { AppModule } from './app/app.module';
import { environment } from './environments/environment';

// import "materialize-css";
// import "angular2-materialize";

if (environment.production) {
	enableProdMode();
}

platformBrowserDynamic().bootstrapModule(AppModule);
