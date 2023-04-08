<template>
    <div class="navbar">
        <div class="nav-list">
            <router-link to="/" class="nav-item" style="display: flex;">
                <i class="fa-solid fa-house"></i>
                <div class="nav-text" style="padding-left: 8px;">Trang chủ</div>
            </router-link>
            <div class="nav-item" style="display: flex;">
                <i class="fa-solid fa-bars"></i>
                <div class="nav-text" style="padding-left: 8px;">Danh mục sản phẩm</div>
                <div class="sub-menu">
                    <router-link to="/category/:id" class="no-link">
                        <div class="nav-item-submenu">
                            <div class="nav-text">Hệ thống gầm, phanh</div>
                        </div>
                    </router-link>
                    <div class="nav-item-submenu">
                        <div class="nav-text">Hệ thống động cơ, hộp số</div>
                    </div>
                    <div class="nav-item-submenu">
                        <div class="nav-text">Hệ thống điện, điều hòa</div>
                    </div>
                    <div class="nav-item-submenu">
                        <div class="nav-text">Hệ thống làm mát, nhiên liệu</div>
                    </div>
                    <div class="nav-item-submenu">
                        <div class="nav-text">Hệ thống thân, vỏ , gương đèn</div>
                    </div>
                    <div class="nav-item-submenu">
                        <div class="nav-text">Nội thất ,phụ kiện </div>
                    </div>

                </div>
            </div>
            <router-link to="/about" class="nav-item">Giới thiệu</router-link>
            <router-link to="/news" class="nav-item" style="display: flex;">
                <i class="fa-solid fa-newspaper"></i>
                <div class="nav-text" style="padding-left: 8px;">Tin tức</div>
            </router-link>
            <router-link to="/helps" class="nav-item" style="display: flex;">
                <i class="fa-solid fa-headset"></i>
                <div class="nav-text" style="padding-left: 8px;">Trợ giúp</div>
            </router-link>
            <router-link to="/contact" class="nav-item" style="display: flex;">
                <i class="fa-solid fa-circle-info"></i>
                <div class="nav-text" style="padding-left: 8px;">Liên hệ</div>
            </router-link>
        </div>
    </div>
</template>

<script>
export default {
    /**
     * Tên component
     */
    name: "TheNavbar",
    /**
     * Hứng nhận
     */
    props: [""],
    /**
     * Component được sử dụng
     */
    components: {},
    /**
     * Emit sự thay đổi
     */
    emits: [""],
    directives: {},
    /**
     * Data
     */
    data() {
        return {};
    },
    /**
     * Phương thức
     */
    methods: {},
    created() { },
    /**
     * Theo dõi sự thay đổi
     */
    watch: {}
};
</script>

<style>
@import url(../css/navbar.css);
</style>