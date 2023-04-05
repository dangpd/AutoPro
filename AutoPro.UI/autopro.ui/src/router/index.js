import { createRouter, createWebHistory } from "vue-router"
import Home from '@/views/user/Home.vue'
import About from '@/views/user/About.vue'
import News from '@/views/user/News.vue'
import Help from '@/views/user/Help.vue'
import Contact from '@/views/user/Contact.vue'
import Purchase from '@/views/user/Purchase.vue'
import SignUp from '@/views/user/SignUp.vue'
import Register from '@/views/user/Register.vue'
import ForgotPassword from '@/views/user/ForgotPassword.vue'
import Cart from '@/views/user/Cart.vue'
import NotFound from '@/views/NotFound.vue'
const routes = [
    { path: '/home', name: 'Home', component: Home },
    { path: '', name: 'Home', component: Home },
    { path: '/about', name: 'About', component: About },
    { path: '/news', name: 'News', component: News },
    { path: '/helps', name: 'Help', component: Help },
    { path: '/contact', name: 'Contact', component: Contact },
    { path: '/account/sign-up', name: 'SignUp', component: SignUp },
    { path: '/account/register', name: 'Register', component: Register },
    { path: '/account/forgot-password', name: 'ForgotPassword', component: ForgotPassword },
    { path: '/cart', name: 'Cart', component: Cart },
    { path: '/purchase', name: 'Purchase', component: Purchase },
    {
        path: '/:catchAll(.*)',
        name: 'NotFound', component: NotFound
    },
]
const router = createRouter({
    history: createWebHistory(),
    routes: routes
})

export default router