import Vue from "vue";
import VueRouter from "vue-router";
import Login from "../Pages/LoginPage"
import Register from "../Pages/Register"
import ForgotPassword from "../Pages/Forgot"
import ResetPassword from "../Pages/ResetPage"
import NavBar from "../components/NavBar"
import Books from "../components/Book"
import cart from "../components/Cart"
import Wish from "../components/WishList"
import Orders from"../components/OrderSuccess"
import Home from"../components/HomePage"
import customer from "../components/CustomerDetail"
import order from "../components/Order"
Vue.use(VueRouter);

// Router Guard

function guardRoute(to, from, next) {
  var isAuthenticated = false;
  if (localStorage.getItem("AccessToken")) {
    isAuthenticated = true;
  } else {
    isAuthenticated = false;
  }
  if (isAuthenticated) {
    next();
  } else {
    next("/");
  }
}



const routes = [
  {
    path: "/nav",
    name: "nav",
    // beforeEnter: guardRoute,
    component: NavBar,

  },

  {
    
    path: "/home",
    name: "Home",
    component: Home,
    children: [
      {
        path:"/" ,
        name: "books",
        beforeEnter: guardRoute,
        component: Books,
      },
      {
        path: "wish",
        name: "wish",
        beforeEnter: guardRoute,
        component: Wish,
      },

      {
        path: "order",
        name: "order",
        beforeEnter: guardRoute,
        component: order,
      },
      {
      path: "cart",
      name: "Cart",
      beforeEnter: guardRoute,
      component: cart,
      children:[
        {
          path: "cst",
          name: "customer",
          beforeEnter: guardRoute,
          component: customer,
        },
      ]

      },
  
  ]

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
    path: "/success",
    name: "ordersc",
    component: Orders,
  },
];

const router = new VueRouter({
  mode: "history",
  routes

});

export default router;
