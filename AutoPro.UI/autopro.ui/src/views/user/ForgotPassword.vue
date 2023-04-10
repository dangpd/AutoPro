<template>
    <div>
        <div class="login">
            <img src="../../assets/Image/bglogin.png" alt="">
            <div class="form-login">
                <div class="title-form">
                    QUÊN MẬT KHẨU
                </div>
                <div class="form-input">
                    <div class="forgot-account">
                        <div class="text">Tên đăng nhập :</div>
                        <MInput type="text"
                            styleInput="width: 400px; height: 30px;; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;">
                        </MInput>
                    </div>
                    <div class="forgot-phone">
                        <div class="text">Điện thoại :</div>
                        <MInput type="text"
                            styleInput="width: 400px; height: 30px;; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;">
                        </MInput>
                    </div>
                    <div class="forgot-email">
                        <div class="text">Email :</div>
                        <MInput type="text"
                            styleInput="width: 400px; height: 30px;; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;">
                        </MInput>
                    </div>
                </div>
                <div class="submit">
                    <input type="submit" value="Gửi" style="padding: 4px ;border-radius:4px">
                </div>
                <div class="orther">
                    <router-link to="/account/sign-up" class="sign-up">Đăng nhập</router-link>
                    hoặc
                    <router-link to="/account/register" class="register">Đăng kí</router-link>
                </div>
            </div>
        </div>
        <TheFooter></TheFooter>
    </div>
</template>

<script>
import TheFooter from '@/layout/TheFooter.vue';
import TheHeader from '@/layout/TheHeader.vue';
import TheNavbar from '@/layout/TheNavbar.vue';
import MInput from '@/components/MInput.vue';
import TheLineLink from '@/layout/TheLineLink.vue';
export default {
    /**
         * Tên component
         */
    name: 'ForgotPassword',
    /**
     * Hứng nhận
     */
    props: [""],
    /**
     * Component được sử dụng
     */
    components: { TheHeader, TheNavbar, TheFooter, MInput, TheLineLink },
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