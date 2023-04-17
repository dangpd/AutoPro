<template>
    <div class="nav">
        <div class="anav-list">
            <router-link to="/admin/dashload" style="text-decoration: none;">
                <div class="anav-item">
                    <div class="anav__text">Tổng quan</div>
                </div>
            </router-link>
            <router-link to="/admin/brand" style="text-decoration: none;">
                <div class="anav-item">
                    <div class="anav__text">Quản lí nhãn hàng</div>
                    <i class="fa-solid fa-caret-down"></i>
                </div>
            </router-link>
            <router-link to="/admin/category" style="text-decoration: none;">
                <div class="anav-item">
                    <div class="anav__text">Quản lí danh mục</div>
                    <i class="fa-solid fa-caret-down"></i>
                </div>
            </router-link>
            <!-- <router-link to="/admin/" style="text-decoration: none;">
                <div class="anav-item">
                    <div class="anav__text">Quản lí nhà sản xuất</div>
                    <i class="fa-solid fa-caret-down"></i>
                </div>
            </router-link> -->
            <router-link to="/admin/order" style="text-decoration: none;">
                <div class="anav-item">
                    <div class="anav__text">Quản lí đơn hàng</div>
                    <i class="fa-solid fa-caret-down"></i>
                </div>
            </router-link>
            <router-link to="/admin/account" style="text-decoration: none;">
                <div class="anav-item">
                    <div class="anav__text">Quản lí tài khoản</div>
                    <i class="fa-solid fa-caret-down"></i>
                </div>
            </router-link>
            <router-link to="/admin/news" style="text-decoration: none;">
                <div class="anav-item">
                    <div class="anav__text">Quản lí tin tức</div>
                    <i class="fa-solid fa-caret-down"></i>
                </div>
            </router-link>
            <router-link to="/admin/contact" style="text-decoration: none;">
                <div class="anav-item">
                    <div class="anav__text">Quản lí liên hệ</div>
                    <i class="fa-solid fa-caret-down"></i>
                </div>
            </router-link>
            <router-link to="/admin/revenue-statistics" style="text-decoration: none;">
                <div class="anav-item">
                    <div class="anav__text">Thống kê doanh thu</div>
                    <i class="fa-solid fa-caret-down"></i>
                </div>
            </router-link>
            <router-link to="/admin/product" style="text-decoration: none;">
                <div class="anav-item">
                    <div class="anav__text">Quản lí sản phẩm</div>
                    <i class="fa-solid fa-caret-down"></i>
                </div>
            </router-link>

        </div>
    </div>
</template>

<script>
export default {
    /**
           * Tên component
           */
    name: 'AdminNavbar',
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

<style>@import url(../css/admin/adminnavbar.css);</style>