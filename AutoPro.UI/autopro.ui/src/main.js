import { createApp } from 'vue'
import App from './App.vue'
import Vue from 'vue';
import store from './js/store';
import router from './router'
/* import the fontawesome core */
import { library } from '@fortawesome/fontawesome-svg-core'

/* import font awesome icon component */
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome'

/* import specific icons */
import { faUserSecret } from '@fortawesome/free-solid-svg-icons'
import '@fortawesome/fontawesome-free/css/all.css'
/* add icons to the library */
// const EventBus = new Vue();
// Vue.prototype.$eventBus = EventBus;

// Vue.config.productionTip = false
library.add(faUserSecret)
const app = createApp(App)
app.use(store)
app.use(router)
app.component('font-awesome-icon', FontAwesomeIcon)
app.mount('#app')

