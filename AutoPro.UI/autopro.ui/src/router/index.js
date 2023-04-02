import { createRouter, createWebHistory } from "vue-router"

import Home from '@/views/user/Home.vue'
import About from '@/views/user/About.vue'
import News from '@/views/user/News.vue'
import Purchase from '@/views/user/Purchase.vue'
const routes = [
    { path: '/', component: Home },
    { path: '/Home', component: Home },
    { path: '/About', component: About },
    { path: '/News', component: News },
    { path: '/Purchase', component: Purchase },
    {
        path: '/:catchAll(.*)',
        component: Error
    },
]
const router = createRouter({
    history: createWebHistory(),
    routes: routes
})

export default router