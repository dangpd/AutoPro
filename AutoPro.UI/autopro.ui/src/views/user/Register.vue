<template>
    <div>
        <TheHeader></TheHeader>
        <TheNavbar></TheNavbar>
        <div class="content">
            <div class="line-content"></div>
            <div class="form-register">
                <div class="title-form">
                    ĐĂNG KÍ
                </div>
                <div class="form-input">
                    <div class="account">
                        <div class="text">Tên đăng nhập :</div>
                        <MInput type="text"
                            styleInput="width: 400px; height: 30px; font-size:13px; padding-left:15px; border-radius:4px;border:1px solid black;box-sizing: border-box;">
                        </MInput>
                    </div>
                    <div class="account">
                        <div class="text">Họ và tên :</div>
                        <MInput type="text"
                            styleInput="width: 400px; height: 30px; font-size:13px; padding-left:15px; border-radius:4px;border:1px solid black;box-sizing: border-box;">
                        </MInput>
                    </div>
                    <div class="account">
                        <div class="text">Địa chỉ :</div>
                        <MInput type="text"
                            styleInput="width: 400px; height: 30px; font-size:13px; padding-left:15px; border-radius:4px;border:1px solid black;box-sizing: border-box;">
                        </MInput>
                    </div>
                    <div class="account">
                        <div class="text">Ngày sinh :</div>
                        <MInput type="date"
                            styleInput="width: 400px; height: 30px; font-size:13px; padding-left:15px; border-radius:4px;border:1px solid black;box-sizing: border-box;">
                        </MInput>
                    </div>
                    <div class="account">
                        <div class="text">Giới tính :</div>
                        <MInput type="radio">Nam</MInput>
                        <MInput type="radio">Nữ</MInput>
                        <MInput type="radio">Khác</MInput>
                    </div>
                    <div class="password">
                        <div class="text">Mật khẩu :</div>
                        <MInput type="password"
                            styleInput="width: 400px; height: 30px; font-size:13px; padding-left:15px; border-radius:4px;border:1px solid black;box-sizing: border-box;">
                        </MInput>
                    </div>
                    <div class="password">
                        <div class="text">Nhập lại mật khẩu :</div>
                        <MInput type="password"
                            styleInput="width: 400px; height: 30px; font-size:13px; padding-left:15px; border-radius:4px;border:1px solid black;box-sizing: border-box;">
                        </MInput>
                    </div>
                </div>
                <div class="submit">
                    <input type="submit" value="Đăng kí" style="padding: 4px ;">
                </div>
                <div class="orther">
                    <router-link to="/account/sign-up" class="sign-up">Đăng nhập</router-link>
                    hoặc
                    <router-link to="/account/forgot-password" class="forgot-password">Quên mật khẩu ?</router-link>
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

export default {
    /**
     * Tên component
     */
    name: 'Register',
    /**
     * Hứng nhận
     */
    props: [""],
    /**
     * Component được sử dụng
     */
    components: { TheHeader, TheNavbar, TheFooter, MInput },
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