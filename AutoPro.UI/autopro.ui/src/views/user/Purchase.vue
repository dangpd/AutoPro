<template>
    <div>
        <TheHeader></TheHeader>
        <TheNavbar></TheNavbar>
        <div class="content">
            <TheLineLink name="Đặt hàng"></TheLineLink>
            <div class="purcharse">
                <div class="information-user-order">
                    <div class="title-purcharse-user">
                        <h6>Thông tin khách hàng</h6>
                        <router-link to="/user/:id" class="user-update">Chỉnh sửa thông tin nhận hàng</router-link>
                    </div>
                    <div class="content-purcharse-user">
                        <div class="purcharse-name">
                            <h6>Họ và tên: </h6>
                            <input type="text" class="m-inputp" v-model="orders.fullName"
                                style="width: 350px;height: 30px;padding-left: 10px;border-radius: 4px;border: 1px solid #bbb;">
                        </div>
                        <div class="purcharse-address">
                            <h6>Địa chỉ: </h6>
                            <input type="text" class="m-inputp" v-model="orders.address"
                                style="width: 350px;height: 30px;padding-left: 10px;border-radius: 4px;border: 1px solid #bbb;">
                        </div>
                        <div class="purcharse-phone-number">
                            <h6>Số điện toại: </h6>
                            <input type="text" class="m-inputp" v-model="orders.phoneNumber"
                                style="width: 350px;height: 30px;padding-left: 10px;border-radius: 4px;border: 1px solid #bbb;">
                        </div>
                        <div class="purcharse-payment-methods">
                            <h6>Phương thức thanh toán</h6>
                            <MRadio :data="[
                                    { Gender: 'Thanh toán tại nhà', GenderValue: 0 },
                                    { Gender: 'Thanh toán qua VNPay', GenderValue: 1 },
                                ]" v-model="orders.paymentsID"></MRadio>
                        </div>
                        <div class="purcharse-phone-number">
                            <h6>Ghi chú</h6>
                            <textarea v-model="orders.description"
                                style="width: 350px;height: 100px;padding-left: 10px;border-radius: 4px;border: 1px solid #bbb;word-break: break-word;margin-top: 70px;"></textarea>
                        </div>
                        <div style="position: absolute;bottom: 0;right: 40px;" v-if="showPayVnPay">
                            <button style="padding: 0 10px;border:1px solid #bbb;border-radius: 4px;">Đi tới thanh toán
                                VNPAY</button>
                        </div>
                    </div>
                </div>
                <div class="information-product">
                    <h6>Thông tin đơn hàng</h6>
                    <div class="list-purchase-product" v-for="(item, index) in listCart" :key="index">
                        <div class="product-purchase">
                            <div class="product-purchase-image">
                                <img :src="item.image" alt="">
                            </div>
                            <div class="product-purchase-name">
                                {{ item.productName }}
                                <br>
                                Giá sản phẩm: {{ formatMoney(item.price) }}
                                <br>
                                Số lượng*{{ item.quantitys }}
                            </div>
                            <div class="product-purchase-totalmoney">
                                {{ formatMoney(item.price * item.quantitys) }}
                            </div>
                        </div>
                    </div>
                    <div class="total">
                        <div>Tổng cộng: </div>
                        <div> {{ formatMoney(totalAmount) }}</div>
                    </div>
                </div>
            </div>
            <router-link to="/order">
                <div class="order-purchase">
                    <button>Đặt hàng</button>
                </div>
            </router-link>
        </div>
        <TheFooter></TheFooter>
        <MLoading v-if="showLoading"></MLoading>
    </div>
</template>
  
<script>
import MInput from '@/components/MInput.vue';
import TheFooter from '@/layout/TheFooter.vue';
import TheHeader from '@/layout/TheHeader.vue';
import TheLineLink from '@/layout/TheLineLink.vue';
import { formatMoney } from '@/js/gCommon'
import TheNavbar from '@/layout/TheNavbar.vue';
import axios from 'axios';
import ApiUser from '../../js/apiUser';
import MLoading from '@/components/MLoading.vue';
import MRadio from '@/components/MRadio.vue';

export default {
    /**
     * Tên component
     */
    name: 'Purchase',
    /**
     * Hứng nhận
     */
    props: [""],
    /**
     * Component được sử dụng
     */
    components: { TheHeader, TheNavbar, TheFooter, TheLineLink, MInput, MLoading, MRadio },
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
            user: {},
            description: '',
            showPayVnPay: false,
            showLoading: false,
            orders: {
                fullName: '',
                address: '',
                phoneNumber: '',
            },
        }
    },
    /**
     * Phương thức
     */
    methods: {
        formatMoney(menoy) {
            return formatMoney(menoy);
        },
    },
    created() {
        this.showLoading = true;
        const id = localStorage.getItem("UserID");
        setTimeout(() => {
            this.showLoading = false;
            axios.get(ApiUser.getUserById(id))
                .then((res) => {
                    if (res.status == 200) {
                        this.user = res.data;
                        // console.log(this.user);
                        this.orders.fullName = this.user.fullName
                        this.orders.address = this.user.address
                        this.orders.phoneNumber = this.user.phoneNumber
                    }
                })
            this.listCart = this.$store.state.cart.items;
        }, 500);
    },
    /**
     * Theo dõi sự thay đổi
     */
    watch: {
    },
    computed: {
        totalAmount() {
            return this.$store.state.cart.items.reduce((total, item) => total + (item.price * item.quantitys), 0);
        },
    }
}
</script>
  
<style>
@import url(../../css/purcharse.css);
</style>