<template>
    <div class="div-link" style="margin: 10px 0;">
        <router-link to="/" class="line-link">Trang chủ </router-link>/ {{ this.name }}  {{ this.detail }}
    </div>
</template>

<script>
export default {
    /**
         * Tên component
         */
    name: 'TheLineLink',
    /**
     * Hứng nhận
     */
    props: ["name","detail"],
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
@import url(../css/line-link.css);
</style>