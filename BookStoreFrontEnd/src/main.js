import Vue from "vue";
import App from "./App.vue";
import router from "./Router";
import axios from 'axios';
import VueMaterial from 'vue-material'
import 'vue-material/dist/vue-material.min.css'
import VueResource from 'vue-resource'
// import BootstrapVue from 'bootstrap-vue/dist/bootstrap-vue.esm';

// import 'bootstrap/dist/css/bootstrap.css';
// import 'bootstrap-vue/dist/bootstrap-vue.css';

// Vue.use(BootstrapVue);

Vue.use(axios)
Vue.use(VueResource)
Vue.use(VueMaterial)

Vue.config.productionTip = false;

new Vue({
  router,
  render: h => h(App)
}).$mount("#app");
