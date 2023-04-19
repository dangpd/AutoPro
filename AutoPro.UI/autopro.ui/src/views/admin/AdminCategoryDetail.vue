<template>
    <div class="aform-detail">
        <div class="aform-account">
            <div class="aform-title">
                <div class="aform-title-left">
                    Tiêu đề form
                </div>
                <div class="onClose" @click="onClose">
                    <i class="fa-regular fa-circle-xmark"></i>
                </div>
            </div>
            <div class="agroup1">
                <div class="acol1">
                    <div class="acol1-text">
                        Mã danh mục :
                    </div>
                    <MInput type="text"
                        styleInput="width: 400px; height: 30px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;"
                        v-model="category">
                    </MInput>
                </div>
                <div class="acol2">
                    <div class="acol2-text">
                        Tên danh mục :
                    </div>
                    <MInput type="text"
                        styleInput="width: 400px; height: 30px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;"
                        v-model="category">
                    </MInput>
                </div>
            </div>
            <div class="agroup1">
                <div class="acol1">
                    <div class="acol1-text">
                        Mô tả :
                    </div>
                    <MInput type="text"
                        styleInput="width: 400px; height: 30px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;"
                        v-model="category">
                    </MInput>
                </div>
            </div>
            <div class="aformSave">
                <button>Lưu</button>
            </div>
        </div>
    </div>
</template>
  
<script>
import MInput from '@/components/MInput.vue';
export default {
    /**
     * Tên component
     */
    name: "AdminCategoryDetail",
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
    emits: ["onClose"],
    directives: {},
    /**
     * Data
     */
    data() {
        return {
            category: ''
        };
    },
    /**
     * Phương thức
     */
    methods: {
        onClose() {
            this.$emit("onClose");
        }
    },
    created() { },
    /**
     * Theo dõi sự thay đổi
     */
    watch: {},
};
</script>
  
<style>
@import url(../../css/admin/adminaccount.css);
</style>