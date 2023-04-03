<template>
    <div>
        <div class="header">
            <div class="header-left">
                <div class="logo">
                    <img src="../assets/Image/logo3.jpg" alt="">
                    <h6>Hệ thống ô tô phụ tùng uy tín chính hãng</h6>
                </div>
                <div class="search">
                    <MInput placeholder="Nhập từ khóa tìm kiếm"
                        styleInput="width:600px; height:36px; font-size:13px; padding-left:15px; border-radius:4px;border:1px solid black;box-sizing: border-box;">
                    </MInput>
                    <div class="icon">
                        <i class="fa-solid fa-magnifying-glass"></i>
                    </div>
                </div>
            </div>
            <div class="header-right">
                <div class="user">
                    <i class="fa-regular fa-user fa-xl" style=""></i>
                    <div class="info">Tài khoản</div>
                </div>
                <div class="cart">
                    <i class="fa-solid fa-cart-plus fa-xl"></i>
                    <div class="info-cart">Giỏ hàng của bạn</div>
                </div>
            </div>
        </div>
        <div class="line-header"></div>
    </div>
</template>

<script>
import MInput from '@/components/MInput.vue'
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
@import url(../css/header.css);
</style>