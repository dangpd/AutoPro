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
                        styleInput="width: 400px; height: 30px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;">
                    </MInput>
                </div>
                <div class="login-password">
                    <div class="text">Mật khẩu :</div>
                    <MInput type="password"
                        styleInput="width: 400px; height: 30px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;">
                    </MInput>
                </div>
            </div>
            <div class="submit">
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

        }
    },
    /**
     * Phương thức
     */
    methods: {

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