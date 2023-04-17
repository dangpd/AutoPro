<template>
    <div>
        <input class="m-input" :type="type" :placeholder="placeholder" :style="styleInput" v-model="value">
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
    props: ["placeholder", "styleInput", "type", "modelValue"],
    /**
     * Component được sử dụng
     */
    components: {},
    /**
     * Emit sự thay đổi
     */
    emits: ["update:modelValue"],
    directives: {

    },
    /**
     * Data
     */
    data() {
        return {
            value: "",
        }
    },
    /**
     * Phương thức
     */
    methods: {

    },
    created() {
        this.value = this.modelValue
    },
    /**
     * Theo dõi sự thay đổi
     */
    watch: {
        value(newVal) {
            this.$emit("update:modelValue", newVal);
        },
        modelValue(newVal) {
            this.value = newVal;
        }
    }
}
</script>
  
<style>
@import url(../css/input.css);
</style>