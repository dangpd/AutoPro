// Khai báo Vuex store
import { createApp } from 'vue'
import { createStore } from 'vuex'
import createPersistedState from 'vuex-persistedstate'
const store = createStore({
    state() {
        return {
            count: 100,
            cart: {
                items: [],
                totalCartItem: 0,
            },
            favorite: {
                items: [],
            }
        }
    },
    mutations: {
        addToCart(state, product) {
            // Kiểm tra xem sản phẩm đã tồn tại trong giỏ hàng hay chưa
            console.log(product);
            var item = state.cart.items.find((item) => item.productID === product.productID);
            if (item) {
                item.quantitys = item.quantitys + product.quantitys;
            } else {
                state.cart.items.push(product);
                state.cart.totalCartItem++;
            }
        },

        removeCart(state, product) {
            if (product) {
                let index = state.cart.items.findIndex(x => x.productID == product.productID);
                if (index != -1) {
                    state.cart.items.splice(index, 1);
                    if (state.cart.totalCartItem > 0) {
                        state.cart.totalCartItem--;
                    }
                }
            }
        },

        addToFavorite(state, product) {
            // Kiểm tra xem sản phẩm đã tồn tại trong giỏ hàng hay chưa
            console.log(product);
            var item = state.cart.items.find((item) => item.productID === product.productID);
            if (item) {
                alert("Sản phẩm đã có trong yêu thích")
            } else {
                state.cart.items.push(product);
            }
        },

        removeFavorite(state, product) {
            if (product) {
                let index = state.cart.items.findIndex(x => x.productID == product.productID);
                if (index != -1) {
                    state.cart.items.splice(index, 1);
                }
            }
        },
    },

    plugins: [createPersistedState()],
});

export default store;
