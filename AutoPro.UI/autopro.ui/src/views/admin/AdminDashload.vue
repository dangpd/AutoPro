<template>
    <div class="admin-content">
        <AdminLineLink name="Tổng quan"></AdminLineLink>
        <table></table>
    </div>
</template>

<script>
import AdminLineLink from '@/layout/AdminLineLink.vue';

export default {
    /**
           * Tên component
           */
    name: 'AdminDashload',
    /**
     * Hứng nhận
     */
    props: [""],
    /**
     * Component được sử dụng
     */
    components: { AdminLineLink },
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
        const role = localStorage.getItem("Role");
        if(role == "User"){
            this.$router.push('/forbidden');
        }
    },
    /**
     * Theo dõi sự thay đổi
     */
    watch: {

    }
}
</script>

<style>
@import url(../../css/admin/admindashload.css);
</style>