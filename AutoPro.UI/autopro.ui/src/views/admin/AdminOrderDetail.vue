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
                        Mã đơn hàng :
                    </div>
                    <MInput type="text"
                        styleInput="width: 400px; height: 30px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;"
                        v-model="brand">
                    </MInput>
                </div>
                <div class="acol2">
                    <div class="acol2-text">
                        Ngày tạo :
                    </div>
                    <MInput type="text"
                        styleInput="width: 400px; height: 30px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;"
                        v-model="brand">
                    </MInput>
                </div>
            </div>
            <div class="agroup1">
                <div class="acol1">
                    <div class="acol1-text">
                        Sản phẩm :
                    </div>
                    <MInput type="text"
                        styleInput="width: 400px; height: 30px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;"
                        v-model="brand">
                    </MInput>
                </div>
                <div class="acol2">
                    <div class="acol2-text">
                        Giá :
                    </div>
                    <MInput type="text"
                        styleInput="width: 400px; height: 30px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;"
                        v-model="brand">
                    </MInput>
                </div>
            </div>
            <div class="agroup1">
                <div class="acol1">
                    <div class="acol1-text">
                        Số lượng :
                    </div>
                    <MInput type="text"
                        styleInput="width: 400px; height: 30px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;"
                        v-model="brand">
                    </MInput>
                </div>
                <div class="acol2">
                    <div class="acol2-text">
                        Tổng tiền :
                    </div>
                    <MInput type="text"
                        styleInput="width: 400px; height: 30px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;"
                        v-model="brand">
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
    name: "AdminOrderDetail",
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
            brand: ''
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