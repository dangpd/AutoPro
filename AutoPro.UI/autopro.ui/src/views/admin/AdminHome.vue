<template>
  <div>
    <AdminHeader></AdminHeader>
    <div class="ahomecontent">
        <AdminNavbar></AdminNavbar>
        <div class="arouter-view-content">
            <router-view></router-view>
        </div>
    </div>
  </div>
</template>

<script>
import AdminHeader from '@/layout/AdminHeader.vue';
import AdminNavbar from '@/layout/AdminNavbar.vue';

export default {
/**
       * Tên component
       */
       name: 'AdminHome',
    /**
     * Hứng nhận
     */
    props: [""],
    /**
     * Component được sử dụng
     */
    components: { AdminHeader, AdminNavbar },
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
@import url(../../css/admin/adminhome.css);
</style>