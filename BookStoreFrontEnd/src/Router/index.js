import Vue from "vue";
import VueRouter from "vue-router";
import Register from "../Pages/Registeration"
import Login from "../Pages/Login"

Vue.use(VueRouter);


const routes = [ {
        path: "/login",
        name: "login",
        component: Login,
    },
    {
        path: "/add",
        name: "registration",
        component: Register,
    },
];


const router = new VueRouter({
    mode: "history",
    routes
});

export default router;