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
                        <div class="details-text">Account :</div>
                        <MInput type="text"
                            styleInput="width: 600px; height: 30px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;"
                            v-model="this.userDetail.account">
                        </MInput>
                    </div>
                    <div class="details-user-firstname">
                        <div class="details-text">Họ :</div>
                        <MInput type="text"
                            styleInput="width: 600px; height: 30px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;"
                            v-model="this.userDetail.firstName">
                        </MInput>
                    </div>
                    <div class="details-user-lastname">
                        <div class="details-text">Tên :</div>
                        <MInput type="text"
                            styleInput="width: 600px; height: 30px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;"
                            v-model="this.userDetail.lastName">
                        </MInput>
                    </div>
                    <div class="details-user-fullName">
                        <div class="details-text">Họ và tên :</div>
                        <MInput type="text"
                            styleInput="width: 600px; height: 30px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;"
                            v-model="this.userDetail.fullName">
                        </MInput>
                    </div>
                    <div class="details-user-address">
                        <div class="details-text">Địa chỉ :</div>
                        <MInput type="text"
                            styleInput="width: 600px; height: 30px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;"
                            v-model="this.userDetail.address">
                        </MInput>
                    </div>
                    <div class="details-user-birth">
                        <div class="details-text">Ngày sinh :</div>
                        <MInput type="text"
                            styleInput="width: 600px; height: 30px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;"
                            v-model="this.userDetail.dateOfBirth">
                        </MInput>
                    </div>
                    <div class="details-user-gender">
                        <div class="details-text">Giới tính :</div>
                        <MInput type="text"
                            styleInput="width: 600px; height: 30px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;"
                            v-model="this.userDetail.gender">
                        </MInput>
                    </div>
                    <div class="details-user-firstname">
                        <div class="details-text">Email :</div>
                        <MInput type="text"
                            styleInput="width: 600px; height: 30px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;"
                            v-model="this.userDetail.email">
                        </MInput>
                    </div>
                    <div class="details-user-firstname">
                        <div class="details-text">Số điện thoại :</div>
                        <MInput type="text"
                            styleInput="width: 600px; height: 30px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;"
                            v-model="this.userDetail.phoneNumber">
                        </MInput>
                    </div>
                    <div class="details-user-firstname">
                        <div class="details-text">Ảnh :</div>
                        <MInput type="text"
                            styleInput="width: 600px; height: 30px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;"
                            v-model="this.userDetail.image">
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
import axios from 'axios';
import ApiUser from '../../js/apiUser';

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
    emits: ["clickInfo"],
    directives: {

    },
    /**
     * Data
     */
    data() {
        return {
            userDetail: {},
        }
    },
    /**
     * Phương thức
     */
    methods: {

    },
    created() {
        const userID = localStorage.getItem("UserID");
        axios.get(ApiUser.getUserById(userID))
            .then((res) => {
                if (res.status == 200) {
                    this.userDetail = res.data;
                } else if (res.status == 400) {
                    console.log(res.moreInfo);
                }
            })
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