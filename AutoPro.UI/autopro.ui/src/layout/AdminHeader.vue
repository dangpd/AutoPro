<template>
    <div class="aheader">
        <router-link to="/admin/dashload">
            <div class="aheader-left">
                <img src="../assets/Image/logo4.jpg" alt="">
            </div>
        </router-link>
        <div class="aheader-right">
            <i class="fa-regular fa-bell"></i>
            <div class="a-account">
                <i class="fa-regular fa-circle-user"></i>
                Xin chào Đăng
            </div>
        </div>
    </div>
</template>

<script>
export default {
    /**
           * Tên component
           */
    name: 'AdminHeader',
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

<style>
@import url(../css/admin/adminheader.css);
</style>