import Notifications from 'vue-notification'
import Vue from 'vue';
import App from './App.vue';
import proxyConfig from './proxies/_config';
import store from './store/index';

Vue.config.productionTip = false;

Vue.use({
  install(Vue) {
    Object.defineProperty(Vue.prototype, '$proxies', {
      value: proxyConfig
    })
  }
});

Vue.use({
  install(Vue) {
    Object.defineProperty(Vue.prototype, '$user', {
      value: {
        initialize() {
          // procesando el tocken
          let token = localStorage.getItem("access_token").split("."),
            user = JSON.parse(
              decodeURIComponent(
                // funcion para decodificar BASE64
                atob(token[1])
                  .split("")
                  .map(c => {
                    // Procesamos para leer como utf-8
                    return (
                      "%" + ("00" + c.charCodeAt(0).toString(16)).slice(-2)
                    );
                  })
                  .join("")
              )
            );

          store.state.user = {
            id: user.nameid,
            name: user.unique_name,
            lastName: user.family_name,
            email: user.email,
            roles: user.role
          };
        }
      }
    })
  }
});

import router from './router';

// Notificaciones
Vue.use(Notifications);

new Vue({
  router,
  store,
  render: h => h(App)
}).$mount('#app');
