<template>
    <div>
        <TheHeader></TheHeader>
        <TheNavbar></TheNavbar>
        <div class="content">
            <TheLineLink name="Thông tin cá nhân"></TheLineLink>
            <div class="details-form-user">
                <div class="details-header">
                    <div>Thông tin cá nhân</div>
                </div>
                <div class="details-form-input">
                    <div class="details-user-firstname">
                        <div class="details-text">Họ :</div>
                        <MInput type="text"
                            styleInput="width: 600px; height: 30px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;">
                        </MInput>
                    </div>
                    <div class="details-user-lastname">
                        <div class="details-text">Tên :</div>
                        <MInput type="text"
                            styleInput="width: 600px; height: 30px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;">
                        </MInput>
                    </div>
                    <div class="details-user-fullName">
                        <div class="details-text">Họ và tên :</div>
                        <MInput type="text"
                            styleInput="width: 600px; height: 30px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;">
                        </MInput>
                    </div>
                    <div class="details-user-address">
                        <div class="details-text">Địa chỉ :</div>
                        <MInput type="text"
                            styleInput="width: 600px; height: 30px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;">
                        </MInput>
                    </div>
                    <div class="details-user-birth">
                        <div class="details-text">Ngày sinh :</div>
                        <MInput type="text"
                            styleInput="width: 600px; height: 30px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;">
                        </MInput>
                    </div>
                    <div class="details-user-gender">
                        <div class="details-text">Giới tính :</div>
                        <MInput type="text"
                            styleInput="width: 600px; height: 30px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;">
                        </MInput>
                    </div>
                </div>
                <div class="details-user-update">
                    <button>Lưu</button>
                </div>
            </div>
        </div>
        <TheFooter></TheFooter>
    </div>
</template>
  
<script>
import MInput from '@/components/MInput.vue';
import TheFooter from '@/layout/TheFooter.vue';
import TheHeader from '@/layout/TheHeader.vue';
import TheLineLink from '@/layout/TheLineLink.vue';
import TheNavbar from '@/layout/TheNavbar.vue';

export default {
    /**
     * Tên component
     */
    name: 'DetailsUser',
    /**
     * Hứng nhận
     */
    props: [""],
    /**
     * Component được sử dụng
     */
    components: { TheHeader, TheNavbar, TheFooter, TheLineLink, MInput },
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
@import url(../../css/detailsuser.css);
</style>