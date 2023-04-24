<template>
    <div>
        <TheHeader></TheHeader>
        <TheNavbar></TheNavbar>
        <div class="content">
            <TheLineLink name="Giỏ hàng"></TheLineLink>
            <div v-show="showCart">
                <table class="m-table">
                    <thead>
                        <tr>
                            <th style="min-width: 50px;padding-left: 16px;">
                                <input type="checkbox">
                            </th>
                            <th style="min-width: 300px;">Sản phẩm</th>
                            <th style="min-width: 200px;">Đơn giá</th>
                            <th style="min-width: 100px;">Số lượng</th>
                            <th style="min-width: 200px;">Thành tiền</th>
                            <th style="min-width: 100px;">Thao tác</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr v-for="(item, index) in listCart" :key="index">
                            <td style="min-width: 50px; padding-left: 16px;">
                                <input type="checkbox">
                            </td>
                            <td style="min-width: 300px;">
                                <div class="product-cart">
                                    <img :src="item.image" alt="">
                                    <div class="product-cart-name">{{ item.productName }}</div>
                                </div>
                            </td>
                            <td style="min-width: 150px;">{{ formatMoney(item.price) }}</td>
                            <td style="min-width: 150px;">
                                <MQuantity v-model="item.quantitys"></MQuantity>
                            </td>
                            <td style="min-width: 150px;">
                                {{ formatMoney(item.price * item.quantitys) }}
                            </td>
                            <td style="min-width: 100px; cursor: pointer;" @click="removeProduct(item)">
                                <div class="cart-method">Xóa</div>
                            </td>
                        </tr>
                    </tbody>
                </table>
                <div class="pay">
                    <div class="total-pay">
                        Tổng thanh toán(tạm tính) :{{ formatMoney(totalAmount) }}
                    </div>
                    <router-link to="/purchase" class="purchase"><button>Mua hàng</button></router-link>
                </div>
            </div>
            <div class="nocart" v-show="noCart">
                <img src="../../assets/Image/nocart.png" alt="">
                <h4>Không có sản phẩm ở giỏ hàng</h4>
                <router-link to="/">
                    <h5>Tiếp tục mua sắm</h5>
                </router-link>
            </div>
        </div>

        <TheFooter></TheFooter>
    </div>
</template>
  
<script>
import MInput from '@/components/MInput.vue';
import TheFooter from '@/layout/TheFooter.vue';
import TheHeader from '@/layout/TheHeader.vue';
import TheLineLink from '@/layout/TheLineLink.vue';
import TheNavbar from '@/layout/TheNavbar.vue';
import { formatMoney } from '@/js/gCommon'
import MQuantity from '@/components/MQuantity.vue';
export default {
    /**
     * Tên component
     */
    name: 'Cart',
    /**
     * Hứng nhận
     */
    props: {},
    /**
     * Component được sử dụng
     */
    components: { TheHeader, TheNavbar, MInput, TheFooter, TheLineLink, MQuantity },
    /**
     * Emit sự thay đổi
     */
    emits: [""],
    directives: {
    },
    /**
     * Data
     */
    data() {
        return {
            listCart: [],
            totalCartItem: 0,
            showCart: false,
            noCart: false,
        }
    },
    /**
     * Phương thức
     */
    methods: {
        formatMoney(menoy) {
            return formatMoney(menoy);
        },

        removeProduct(item) {
            this.$store.commit('removeCart', item);
        },


    },
    created() {
        this.listCart = this.$store.state.cart.items;
        this.totalCartItem = this.$store.state.cart.totalCartItem;
        if (this.totalCartItem > 0) {
            this.showCart = true;
            this.noCart = false;
        } else {
            this.showCart = false;
            this.noCart = true;
        }
    },
    /**
     * Theo dõi sự thay đổi
     */
    watch: {
        totalRecord(newVal) {
            if (newVal == 0) {
                this.showCart = false;
                this.noCart = true;
            }
        }
    },
    computed: {
        totalAmount() {
            return this.$store.state.cart.items.reduce((total, item) => total + (item.price * item.quantitys), 0);
        },

        totalRecord() {
            return this.$store.state.cart.totalCartItem;
        }
    },
}
</script>
  
<style>
@import url(../../css/cart.css);
</style>