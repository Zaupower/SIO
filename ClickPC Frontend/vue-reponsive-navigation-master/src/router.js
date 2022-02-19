import Vue from 'vue'
import Router from 'vue-router'

Vue.use(Router)

export default new Router({
    mode: 'history',
    base: process.env.BASE_URL,
    routes: [{
            path: '/',
            name: 'Manel',
            component: () => { return import ('./views/Ceo.vue') }
        },
        {
            path: '/salesmanager',
            name: 'salesmanager',
            // route level code-splitting
            // this generates a separate chunk (about.[hash].js) for this route
            // which is lazy-loaded when the route is visited.
            component: () => { return import ('./views/SalesManager.vue') }
        },
        {
            path: '/ceo',
            name: 'ceo',
            // route level code-splitting
            // this generates a separate chunk (about.[hash].js) for this route
            // which is lazy-loaded when the route is visited.
            component: () => { return import ('./views/Ceo.vue') }
        },
        {
            path: '/PurshasingManager',
            name: 'PurshasingManager',
            // route level code-splitting
            // this generates a separate chunk (about.[hash].js) for this route
            // which is lazy-loaded when the route is visited.
            component: () => { return import ('./views/PurshasingManager.vue') }
        }
    ]
})