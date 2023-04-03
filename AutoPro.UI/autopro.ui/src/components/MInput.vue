<template>
    <div class="m-input">
        <input type="text" :placeholder="placeholder" :style="styleInput">
    </div>
</template>
  
<script>
export default {
    /**
     * Tên component
     */
    name: 'MInput',
    /**
     * Hứng nhận
     */
    props: ["placeholder","styleInput"],
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
@import url(../css/input.css);
</style>