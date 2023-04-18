<template>
    <div>
        <div class="header">
            <div class="header-left">
                <router-link to="/" class="logo">
                    <img src="../assets/Image/logo3.jpg" alt="">
                    <h6 style="font-weight: 700;">Hệ thống ô tô phụ tùng uy tín chính hãng</h6>
                </router-link>
                <div class="search">
                    <MInput placeholder="Nhập từ khóa tìm kiếm" type="text"
                        styleInput="width:350px; height:36px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;">
                    </MInput>
                    <div class="icon">
                        <i class="fa-solid fa-magnifying-glass"></i>
                    </div>
                </div>
            </div>
            <div class="header-right">
                <div class="user" :class="{ 'isNoLogin': isNoLogin }">
                    <router-link to="/account/sign-up" class="account">
                        <i class="fa-regular fa-user " style=""></i>
                        <div class="info">
                            <div class="">Tài khoản</div>
                        </div>
                    </router-link>
                </div>
                <div class="user" :class="{ 'isLogin': isLogin }">
                    <div class="account">
                        <i class="fa-regular fa-user " style=""></i>
                        <div class="info">
                            <div class="">Xin chào , {{ this.user.role }}</div>
                            <div class="under-user">
                                <router-link :to="'/user/' + userID" class="item-header">
                                    <div class="details-user">Tài khoản của tôi</div>
                                </router-link>
                                <router-link to="/list-product-favorite" class="item-header">
                                    <div class="product-favorite">Sản phẩm yêu thích</div>
                                </router-link>
                                <router-link to="/" class="item-header" @click="logout">
                                    <div class="logout">Đăng xuất</div>
                                </router-link>
                            </div>
                        </div>
                    </div>
                </div>
                <router-link to="/cart" class="cart">
                    <i class="fa-solid fa-cart-plus"></i>
                    <div class="info-cart">Giỏ hàng của bạn</div>
                </router-link>
                <router-link to="/order" class="cart">
                    <i class="fa-solid fa-cart-flatbed-suitcase"></i>
                    <div class="info-cart">Đơn hàng của bạn</div>
                </router-link>
            </div>
        </div>
        <div class="line-header"></div>
    </div>
</template>

<script>
import MInput from '@/components/MInput.vue'
import axios from 'axios';
import ApiUser from '../js/apiUser';
export default {
    /**
       * Tên component
       */
    name: 'TheHeader',
    /**
     * Hứng nhận
     */
    props: [""],
    /**
     * Component được sử dụng
     */
    components: { MInput },
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
            isNoLogin: false,
            isLogin: false,
            user: {},
            userID: '',
        }
    },
    /**
     * Phương thức
     */
    methods: {
        logout() {
            localStorage.removeItem('UserID');
            localStorage.removeItem('Role');
            this.isLogin = true;
            this.isNoLogin = false;
            this.$router.push('/');
        },
    },
    created() {
        const login = localStorage.getItem("UserID");
        this.userID = login;
        // console.log(this.userID);
        if (this.userID != null) {
            this.isLogin = false;
            this.isNoLogin = true;
            axios.get(ApiUser.getUserById(login))
                .then((res) => {
                    if (res.status == 200) {
                        this.user = res.data;
                        // console.log(this.user);
                    } else if (res.status == 400) {
                        console.log(res.moreInfo);
                    }
                })
        } else {
            this.isLogin = true;
            this.isNoLogin = false;
        }
    },
    /**
     * Theo dõi sự thay đổi
     */
    watch: {
        userID(newVal) {
            if (newVal != null) {
                this.isLogin = false;
                this.isNoLogin = true;
            } else {
                // this.userID = newVal;
            }
        }
    }
}
</script>

<style>
@import url(../css/header.css);
</style>