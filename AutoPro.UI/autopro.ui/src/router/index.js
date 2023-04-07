import { createRouter, createWebHistory } from "vue-router"
import Home from '@/views/user/Home.vue'
import About from '@/views/user/About.vue'
import News from '@/views/user/News.vue'
import Help from '@/views/user/Help.vue'
import Payment from '@/views/user/Payment.vue'
import Guarantee from '@/views/user/Guarantee.vue'
import FreeShip from '@/views/user/FreeShip.vue'
import Contact from '@/views/user/Contact.vue'
import Purchase from '@/views/user/Purchase.vue'
import SignUp from '@/views/user/SignUp.vue'
import Register from '@/views/user/Register.vue'
import ForgotPassword from '@/views/user/ForgotPassword.vue'
import Cart from '@/views/user/Cart.vue'
import Order from '@/views/user/Order.vue'
import FavoriteProduct from '@/views/user/FavoriteProduct.vue'
import NotFound from '@/views/NotFound.vue'
const routes = [
    { path: '/home', component: Home },
    { path: '', component: Home },
    { path: '/about', component: About },
    { path: '/news', component: News },
    {
        path: '/helps',
        component: Help,
        children:
            [
                { path: '/helps/pay-ment', component: Payment },
                { path: '/helps/guarantee', component: Guarantee },
                { path: '/helps/free-ship', component: FreeShip },
            ]
    },
    { path: '/helps/pay-ment', component: Payment },
    { path: '/helps/guarantee', component: Guarantee },
    { path: '/helps/free-ship', component: FreeShip },
    { path: '/contact', component: Contact },
    { path: '/account/sign-up', component: SignUp },
    { path: '/account/register', component: Register },
    { path: '/account/forgot-password', component: ForgotPassword },
    { path: '/cart', component: Cart },
    { path: '/order', component: Order },
    { path: '/product-favorite', component: FavoriteProduct },
    { path: '/purchase', component: Purchase },
    {
        path: '/:catchAll(.*)',
        component: NotFound
    },
]
const router = createRouter({
    history: createWebHistory(),
    routes: routes
})

export default router