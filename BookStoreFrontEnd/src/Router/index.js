import Vue from "vue";
import VueRouter from "vue-router";
import Login from "../Pages/LoginPage"
import Register from "../Pages/Register"
import ForgotPassword from "../Pages/Forgot"
import ResetPassword from "../Pages/ResetPage"
import Home from "../components/Home"
import Books from "../components/Books"

Vue.use(VueRouter);



const routes = [
  {
    path: "/",
    name: "login",
    component: Login,
  },

  {
    path: "/register",
    name: "register",
    component: Register,
  },

  {
    path: "/forgot",
    name: "forgot",
    component: ForgotPassword,
  },

  {
    path: "/reset",
    name: "reset",
    component: ResetPassword,
  },

  {
    path: "/home",
    name: "Home",
    component: Home,
    children: [{
      path: "books",
      name: "books",
      component: Books,
    },
    ]
  }

];

const router = new VueRouter({
  mode: "history",
  routes

});

export default router;
