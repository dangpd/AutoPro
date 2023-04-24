<template>
    <div class="number">
        <i class="fa-solid fa-minus" @click="minusQuantity"></i>
        <input class="m-input" style="width: 50px;border-radius: 0px" v-model="value">
        <i class="fa-solid fa-plus" @click="addQuantity"></i>
    </div>
</template>
  
<script>
export default {
    /**
     * Tên component
     */
    name: 'MQuantity',
    /**
     * Hứng nhận
     */
    props: ["modelValue"],
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
        minusQuantity(){
            this.value -= 1;
        },

        addQuantity(){
            this.value += 1;
        }
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
            // this.$emit("update:modelValue", newVal);
        }
    }
}
</script>
  
<style>
@import url(../css/components/input.css);
</style>