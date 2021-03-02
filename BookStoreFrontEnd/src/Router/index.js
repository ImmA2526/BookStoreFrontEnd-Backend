import Vue from "vue";
import VueRouter from "vue-router";
import Login from "../Pages/LoginPage"
import Register from "../Pages/Register"
import ForgotPassword from "../Pages/Forgot"
import ResetPassword from "../Pages/ResetPage"
import NavBar from "../components/NavBar"
// import Books from "../components/Books"
import cart from "../components/Cart"
import Home from"../components/HomePage"

Vue.use(VueRouter);



const routes = [
  {
    path: "/home",
    name: "Home",
    component: Home,
  },

  {
    path: "/nav",
    name: "NavBar",
    component: NavBar,
    // children: [{
    //   path: "books",
    //   name: "books",
    //   component: Books,
    // },
    // ]
  },

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
  path: "/cart",
  name: "Cart",
component:cart,

}
  
];

const router = new VueRouter({
  mode: "history",
  routes

});

export default router;
