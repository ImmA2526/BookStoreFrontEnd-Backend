import Vue from "vue";
import App from "./App.vue";
import Routes from "./Router";
import axios from "axios";

import VueMaterial from 'vue-material'
import 'vue-material/dist/vue-material.min.css'
import VueResource from 'vue-resource'
Vue.use(axios)
Vue.use(VueResource)
Vue.use(VueMaterial)

Vue.config.productionTip = false;

new Vue({
  Routes,
  render: h => h(App),
}).$mount('#app');
