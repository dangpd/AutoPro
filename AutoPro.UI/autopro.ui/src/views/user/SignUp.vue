<template>
    <div class="login">
        <img src="../../assets/Image/bglogin.png" alt="">
        <div class="form-login">
            <div class="title-form">
                ĐĂNG NHẬP
            </div>
            <div class="form-input">
                <div class="login-account">
                    <div class="text">Tên đăng nhập :</div>
                    <MInput type="text"
                        styleInput="width: 400px; height: 30px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;"
                        v-model="user.account">
                    </MInput>
                </div>
                <div class="login-password">
                    <div class="text">Mật khẩu :</div>
                    <MInput type="password"
                        styleInput="width: 400px; height: 30px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;"
                        v-model="user.password">
                    </MInput>
                </div>
            </div>
            <div class="submit" @click="loginApp">
                <input type="submit" value="Đăng nhập" style="padding: 4px ;">
            </div>
            <div class="orther">
                <router-link to="/account/register" class="register">Đăng kí</router-link>
                hoặc
                <router-link to="/account/forgot-password" class="forgot-password">Quên mật khẩu ?</router-link>
            </div>
        </div>
    </div>
</template>

<script>
import TheHeader from '@/layout/TheHeader.vue';
import TheNavbar from '@/layout/TheNavbar.vue';
import MInput from '@/components/MInput.vue';
import TheFooter from '@/layout/TheFooter.vue';
import TheLineLink from '@/layout/TheLineLink.vue';
import ApiUser from '../../js/apiUser';
import axios from 'axios';

export default {
    /**
     * Tên component
     */
    name: 'SignUp',
    /**
     * Hứng nhận
     */
    props: [""],
    /**
     * Component được sử dụng
     */
    components: { TheHeader, TheNavbar, MInput, TheFooter, TheLineLink },
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
            user: {
                account: "",
                password: ""
            }
        }
    },
    /**
     * Phương thức
     */
    methods: {
        async loginApp() {
            axios.post(ApiUser.login(), { account: this.user.account, password: this.user.password })
                .then((res) => {
                    if (res.status == 200) {
                        localStorage.setItem('UserID', res.data.UserID);
                        localStorage.setItem('Role',res.data.Role);
                        this.$router.push('/');
                    }
                    else if (res.status == 400) {
                        console.log(res.moreInfo);
                    }
                })
                .catch((err) => {
                    console.log(err);
                })
        },
    },
    created() {

    },
    /**
     * Theo dõi sự thay đổi
     */
    watch: {

    }
}
</script>

<style>
@import url(../../css/form.css);
</style>